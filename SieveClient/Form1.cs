using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace SieveClient
{
    public enum State
    {
        ST_LEARN = 0,           // 学习状态
        ST_CLASS = 1,           // 分级状态
        ST_COUNT = 2,
    }

    public partial class PrimaryForm : Form
    {
        private NetIO.ServerClient serverClient;
        private NetIO.CtrlClient ctrlClient;

        private bool isInProcess;                       // 是否正在批次处理中
        private int tabIdx;                             // 当前选择的tab页的索引
        private State curState;                         // 当前状态
        private string webRoot;                         // web root地址
        private List<LeafGrade> learnResults;           // 学习的结果
        private List<LeafGrade> classifyResults;        // 分类的结果

        void RegisterProtocol()
        {
            // 注册协议
            serverClient.AddProtocol((int)NetIO.ProtocolID.PROTOCOL_ID_FVALIDATEPOSREQP, new NetIO.FValidatePosReqp());
            serverClient.AddProtocol((int)NetIO.ProtocolID.PROTOCOL_ID_SENDBATCHPROCESSREP, new NetIO.SEndBatchProcessRep());
            serverClient.AddProtocol((int)NetIO.ProtocolID.PROTOCOL_ID_SPROCESSRESULT, new NetIO.SProcessResult());
            serverClient.AddProtocol((int)NetIO.ProtocolID.PROTOCOL_ID_SREGISTERCLIENTREP, new NetIO.SRegisterClientRep());
            serverClient.AddProtocol((int)NetIO.ProtocolID.PROTOCOL_ID_SSETPROCESSSTATEREP, new NetIO.SSetProcessStateRep());
            serverClient.AddProtocol((int)NetIO.ProtocolID.PROTOCOL_ID_SLEARNSAMPLEREP, new NetIO.SLearnSampleRep());

            // 注册事件响应函数
            serverClient.FValidatePosReqp += new NetIO.FValidatePosReqpEventHandler(OnFValidatePosReqp);
            serverClient.SEndBatchProcessRep += new NetIO.SEndBatchProcessRepEventHandler(OnSEndBatchProcessRep);
            serverClient.SProcessResult += new NetIO.SProcessResultEventHandler(OnSProcessResult);
            serverClient.SRegisterClientRep += new NetIO.SRegisterClientRepEventHandler(OnSRegisterClientRep);
            serverClient.SSetProcessStateRep += new NetIO.SSetProcessStateRepEventHandler(OnSSetProcessStateRep);
            serverClient.SLearnSampleRep += new NetIO.SLearnSampleRepEventHandler(OnSLearnSampleRep);
        }

        public PrimaryForm()
        {
            InitializeComponent();
            InitServerClient();
            InitCtrlClient();
            // TODO:  线程间操作无效: 从不是创建控件的线程访问它
            CheckForIllegalCrossThreadCalls = false; 

            // 初始化成员变量
            isInProcess = false;
            tabIdx = 0;
            webRoot = ConfigurationManager.AppSettings["WebAddress"];
            curState = State.ST_CLASS;
            learnResults = new List<LeafGrade>();
            classifyResults = new List<LeafGrade>();

            // 初始化ui
            // 分类ui的设置
            panelClassfigy.Visible = true;
            panelStatistics.Visible = false;
            btnBeginBatchClassify.Enabled = true;
            btnClassify.Enabled = false;
            btnEndBatchClassify.Enabled = false;
            labelClassifyState.Text = TextRes.text["WaitBatchClassifyBegin"];
            // 学习ui的设置
            panelLearn.Visible = true;
            panelLearnStatistics.Visible = false;
            btnBeginBatchLearn.Enabled = true;
            btnLearn.Enabled = false;
            btnEndBatchLearn.Enabled = false;
            labelLearnState.Text = TextRes.text["WaitBatchLearnBegin"];

            // 发送注册客户端的协议
            SendRegisterClient();
        }

        private void OnFValidatePosReqp(UInt32 result, string image_path)
        {
            string url = string.Format("{0}/{1}", webRoot, image_path);
            if (curState == State.ST_CLASS)
            {
                // 当前状态是分级
                picBoxClassify.LoadCompleted += new AsyncCompletedEventHandler(picBoxClassify_LoadComplete);
                picBoxClassify.UseWaitCursor = true;
                picBoxClassify.WaitOnLoad = false;
                picBoxClassify.LoadAsync(url);

                if(result != 0)
                {
                    // 摆放不正确
                    labelClassifyState.Text = TextRes.text["ValidatePosErr"];
                    btnClassify.Enabled = true;
                }
            }
            else if (curState == State.ST_LEARN)
            {
                // 当前状态是学习
                picBoxLearn.LoadCompleted += new AsyncCompletedEventHandler(picBoxLearn_LoadComplete);
                picBoxLearn.UseWaitCursor = true;
                picBoxLearn.WaitOnLoad = false;
                picBoxLearn.LoadAsync(url);

                if (result != 0)
                {
                    // 摆放不正确
                    labelLearnState.Text = TextRes.text["ValidatePosErr"];
                    btnLearn.Enabled = true;
                }
            }
            
            if (result == 0)
            {
                // 向控制器发送控制命令，触发连续拍照
                byte[] ctrlMsg = new byte[1];
                ctrlMsg[0] = 0x02;
                ctrlClient.Send(ctrlMsg);
            }
        }

        private void OnSProcessResult(UInt32 result, int group, int rank)
        {
            LeafGrade lg = new LeafGrade(group, rank);
            if(curState == State.ST_CLASS)
            {
                // 当前状态是分级
                labelClassifyState.Text = TextRes.text["SingleClassifyEnd"];
                btnClassify.Enabled = true;
                
                classifyResults.Add(lg);
                textBoxClassifyCount.Text = classifyResults.Count.ToString();
                textBoxClassfiyResult.Text += String.Format(TextRes.text["SingleClassResult"], classifyResults.Count, lg.ToString()); 
            }
            else if (curState == State.ST_LEARN)
            {
                // 当前状态是学习
                labelLearnState.Text = TextRes.text["SingleLearnEnd"];
                btnLearn.Enabled = true;

                learnResults.Add(lg);
                textBoxLearnCnt.Text = learnResults.Count.ToString();
                textBoxLearnResult.Text += String.Format(TextRes.text["SingleLearnResult"], learnResults.Count, lg.ToString()); 
            }
        }

        private void OnSEndBatchProcessRep(UInt32 result, List<netmessage.LeafGradeCount> leaf_grade_counts)
        {
            string resStr = "";
            int totalCount = 0;
            Dictionary<string, int> grade2count = new Dictionary<string, int>();
            if (curState == State.ST_CLASS)
            {
                panelClassfigy.Visible = false;
                panelStatistics.Visible = true;

                btnBeginBatchClassify.Enabled = true;

                // 分级的统计报表生成
                foreach (LeafGrade lg in classifyResults)
                {
                    string grade = lg.ToString();
                    if (grade2count.ContainsKey(grade))
                    {
                        grade2count[grade]++;
                    }
                    else
                    {
                        grade2count.Add(grade, 1);
                    }
                }
                foreach (string grade in grade2count.Keys)
                {
                    resStr += string.Format(TextRes.text["StatisticsClassResult"], grade, grade2count[grade], (double)grade2count[grade] / grade2count.Count);
                }
                textBoxClassfyGradeCnt.Text = grade2count.Count.ToString();
                textBoxClassifyStatistics.Text = resStr;
            }
            else if (curState == State.ST_LEARN)
            {
                panelLearn.Visible = false;
                panelLearnStatistics.Visible = true;

                btnBeginBatchLearn.Enabled = true;

                // 学习的统计报表生成
                foreach (netmessage.LeafGradeCount lgc in leaf_grade_counts)
                {
                    LeafGrade lg = new LeafGrade(lgc.group, lgc.rank);
                    grade2count.Add(lg.ToString(), lgc.count);
                    totalCount += lgc.count;
                }
                foreach (KeyValuePair<string, int> kv in grade2count)
                {
                    resStr += string.Format(TextRes.text["StatisticsLearnResult"], kv.Key, kv.Value, (double)kv.Value / totalCount);
                }
                textBoxLearnTotalCount.Text = totalCount.ToString();
                textBoxLearnStatistics.Text = resStr;
            }
            isInProcess = false;
        }

        private void OnSRegisterClientRep(UInt32 result)
        {
            // TODO:
        }

        private void OnSSetProcessStateRep(UInt32 result)
        {
            // TODO:
        }

        private void OnSLearnSampleRep(UInt32 result, int group, int rank)
        {
            // TODO:
        }

        private void InitServerClient()
        {
            // 初始化serverClient
            byte head = 0xf0;
            byte tail = 0x0f;
            serverClient = new NetIO.ServerClient(head, tail);
            string casd_ip = ConfigurationManager.AppSettings["CasdAddress"];
            short casd_port = Convert.ToInt16(ConfigurationManager.AppSettings["CasdPort"]);
            if (!serverClient.Connect(casd_ip, casd_port))
            {
                string err_msg = string.Format(TextRes.text["ConnectCasdErr"], casd_ip, casd_port);
                MessageBox.Show(err_msg);
            }
            RegisterProtocol();
        }

        private void InitCtrlClient()
        {
            // 初始化ctrlClient
            ctrlClient = new NetIO.CtrlClient();
            string ctrl_ip = ConfigurationManager.AppSettings["CtrlAddress"];
            short ctrl_port = Convert.ToInt16(ConfigurationManager.AppSettings["CtrlPort"]);
            if (!ctrlClient.Connect(ctrl_ip, ctrl_port))
            {
                string err_msg = string.Format(TextRes.text["ConnectCtrlErr"], ctrl_ip, ctrl_port);
                MessageBox.Show(err_msg);
            }
        }

        private void SendRegisterClient()
        {
            // 向casd发送注册客户端的协议
            NetIO.CRegisterClientReq req = new NetIO.CRegisterClientReq();
            req.seq = Convert.ToUInt32(ConfigurationManager.AppSettings["ChannelSeq"]);
            req.Marshal();
            serverClient.Send(req.marshalData);
        }

        private void btnBeginBatchClassify_Click(object sender, EventArgs e)
        {
            classifyResults.Clear();

            isInProcess = true;
            panelClassfigy.Visible = true;
            panelStatistics.Visible = false;
            
            btnBeginBatchClassify.Enabled = false;
            btnClassify.Enabled = true;
            btnEndBatchClassify.Enabled = true;
            
            labelClassifyState.Text = TextRes.text["WaitSingleClassifyBegin"];
            textBoxClassfyGradeCnt.Text = "";
            textBoxClassifyStatistics.Text = "";
            textBoxClassifyCount.Text = "";
            textBoxClassfiyResult.Text = ""; 

            SendSetProcessStateProtocol((int)curState);
        }

        private void btnEndBatchClassify_Click(object sender, EventArgs e)
        {
            btnClassify.Enabled = false;
            btnEndBatchClassify.Enabled = false;
            SendEndBatchProcessPotocol((int)curState);
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            btnClassify.Enabled = false;
            labelClassifyState.Text = TextRes.text["InClassifying"];

            // 向控制器发送控制命令，用来触发相机
            byte[] ctrlMsg = new byte[1];
            ctrlMsg[0] = 0x01;
            ctrlClient.Send(ctrlMsg);
        }

        private void picBoxClassify_LoadComplete(object sender, AsyncCompletedEventArgs e)
        {
            picBoxClassify.UseWaitCursor = false;
        }

        private void picBoxLearn_LoadComplete(object sender, AsyncCompletedEventArgs e)
        {
            picBoxLearn.UseWaitCursor = false;
        }

        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInProcess)
            {
                // 正在批次处理中的程序不可更换tab页
                tabCtrl.SelectedIndex = tabIdx;
                return;
            }
            
            string curTabTag = tabCtrl.SelectedTab.Tag.ToString();
            tabIdx = tabCtrl.SelectedIndex;
            if (curTabTag == "Classify")
            {
                curState = State.ST_CLASS;
            }
            else if (curTabTag == "Learn")
            {
                curState = State.ST_LEARN;
            }
        }

        private void btnBeginBatchLearn_Click(object sender, EventArgs e)
        {
            learnResults.Clear();

            isInProcess = true;
            panelLearn.Visible = true;
            panelLearnStatistics.Visible = false;

            btnBeginBatchLearn.Enabled = false;
            btnLearn.Enabled = true;
            btnEndBatchLearn.Enabled = true;

            labelLearnState.Text = TextRes.text["WaitSingleLearnBegin"];
            textBoxLearnTotalCount.Text = "";
            textBoxLearnStatistics.Text = "";
            textBoxLearnCnt.Text = "";
            textBoxLearnResult.Text = ""; 

            SendSetProcessStateProtocol((int)curState);
        }

        private void btnEndBatchLearn_Click(object sender, EventArgs e)
        {
            btnLearn.Enabled = false;
            btnEndBatchLearn.Enabled = false;
            SendEndBatchProcessPotocol((int)curState);
        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLearnCurGrade.Text))
            {
                MessageBox.Show(TextRes.text["EmptyLearnGradeErr"]);
                return;
            }
            LeafGrade lg = LeafGrade.BuildLeafGrade(textBoxLearnCurGrade.Text.ToUpper());
            if (lg == null)
            {
                MessageBox.Show(TextRes.text["InvalidLearnGradeErr"]);
                return;
            }
            // 发送学习样本协议
            NetIO.CLearnSampleReq req = new NetIO.CLearnSampleReq();
            btnLearn.Enabled = false;
            labelClassifyState.Text = TextRes.text["InClassifying"];
            req.group = lg.group;
            req.rank = lg.rank;
            req.Marshal();
            serverClient.Send(req.marshalData);

            // 向控制器发送控制命令，用来触发相机
            byte[] ctrlMsg = new byte[1];
            ctrlMsg[0] = 0x01;
            ctrlClient.Send(ctrlMsg);
        }

        private void SendSetProcessStateProtocol(int state)
        {
            NetIO.CSetProcessStateReq req = new NetIO.CSetProcessStateReq();
            req.state = state;
            req.Marshal();
            serverClient.Send(req.marshalData);
        }

        private void SendEndBatchProcessPotocol(int state)
        {
            NetIO.CEndBatchProcessReq req = new NetIO.CEndBatchProcessReq();
            req.state = state;
            req.Marshal();
            serverClient.Send(req.marshalData);
        }

        private void tabCtrl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (isInProcess)
            {
                // 正在批次处理中的程序不可更换tab页
                e.Cancel = true;
            }
        }
    }
}
