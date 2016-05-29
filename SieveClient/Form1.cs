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
using System.Threading;
using System.Drawing.Imaging;

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

            // picturebox的设置
            picBoxLearn.LoadCompleted += new AsyncCompletedEventHandler(picBoxLearn_LoadComplete);
            picBoxLearn.UseWaitCursor = true;
            picBoxLearn.WaitOnLoad = true;
            picBoxClassify.LoadCompleted += new AsyncCompletedEventHandler(picBoxClassify_LoadComplete);
            picBoxClassify.UseWaitCursor = true;
            picBoxClassify.WaitOnLoad = true;

            // 初始化combox
            int i = 0;
            foreach (string lg in LeafGrade.leafgrades)
            {
                comboBoxLearn.Items.Insert(i, lg);
                i++;
            }

            // 发送注册客户端的协议
            SendRegisterClient();
        }

        private void OnFValidatePosReqp(UInt32 result, string image_path)
        {
            string url = string.Format("{0}/{1}", webRoot, image_path);
            if (curState == State.ST_CLASS)
            {
                // 当前状态是分级
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    picBoxClassify.LoadAsync(url);
                    if (result != 0)
                    {
                        // 摆放不正确
                        labelClassifyState.Text = TextRes.text["ValidatePosErr"];
                        btnClassify.Enabled = true;
                    }
                });                
            }
            else if (curState == State.ST_LEARN)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    // 当前状态是学习
                    picBoxLearn.LoadAsync(url);

                    if (result != 0)
                    {
                        // 摆放不正确
                        labelLearnState.Text = TextRes.text["ValidatePosErr"];
                        btnLearn.Enabled = true;
                    }
                });
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
                classifyResults.Add(lg);
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    labelClassifyState.Text = TextRes.text["SingleClassifyEnd"];
                    btnClassify.Enabled = true;
                    textBoxClassifyCount.Text = classifyResults.Count.ToString();
                    textBoxClassfiyResult.AppendText(String.Format(TextRes.text["SingleClassResult"], classifyResults.Count, lg.ToString()));
                });
            }
            else if (curState == State.ST_LEARN)
            {
                // 当前状态是学习
                learnResults.Add(lg);
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    labelLearnState.Text = TextRes.text["SingleLearnEnd"];
                    btnLearn.Enabled = true;
                    textBoxLearnCnt.Text = learnResults.Count.ToString();
                    textBoxLearnResult.AppendText(String.Format(TextRes.text["SingleLearnResult"], learnResults.Count, lg.ToString()));
                });
            }
        }

        private void OnSEndBatchProcessRep(UInt32 result, List<netmessage.LeafGradeCount> leaf_grade_counts)
        {
            string resStr = "";
            int totalCount = 0;
            Dictionary<string, int> grade2count = new Dictionary<string, int>();
            if (curState == State.ST_CLASS)
            {
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
                    totalCount += grade2count[grade];
                }
                foreach (string grade in grade2count.Keys)
                {
                    resStr += string.Format(TextRes.text["StatisticsClassResult"], grade, grade2count[grade], (double)grade2count[grade] / totalCount);
                }

                this.BeginInvoke((MethodInvoker)delegate()
                {
                    panelClassfigy.Visible = false;
                    panelStatistics.Visible = true;
                    btnBeginBatchClassify.Enabled = true;
                    textBoxClassfyGradeCnt.Text = totalCount.ToString();
                    textBoxClassifyStatistics.Text = resStr;
                });
            }
            else if (curState == State.ST_LEARN)
            {
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

                this.BeginInvoke((MethodInvoker)delegate()
                {
                    panelLearn.Visible = false;
                    panelLearnStatistics.Visible = true;
                    btnBeginBatchLearn.Enabled = true;
                    textBoxLearnTotalCount.Text = totalCount.ToString();
                    textBoxLearnStatistics.Text = resStr;
                });
            }
            isInProcess = false;
        }

        private void OnSRegisterClientRep(UInt32 result, Int32 samples_count)
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
            serverClient.CreateCheckStateThread();
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
            ctrlClient.CreateCheckStateThread();
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
            ClearClassifyPicBox();

            SendSetProcessStateProtocol((int)curState);
        }

        private void btnEndBatchClassify_Click(object sender, EventArgs e)
        {
            btnClassify.Enabled = false;
            btnEndBatchClassify.Enabled = false;
            ClearClassifyPicBox();
            SendEndBatchProcessPotocol((int)curState);
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            btnClassify.Enabled = false;
            labelClassifyState.Text = TextRes.text["InClassifying"];

            ClearClassifyPicBox();

            // 向控制器发送控制命令，用来触发相机
            byte[] ctrlMsg = new byte[1];
            ctrlMsg[0] = 0x01;
            ctrlClient.Send(ctrlMsg);

            //TODO: just 4 test, to be deleted
            /*
            ThreadStart ts = new ThreadStart(delegate()
            {
                OnFValidatePosReqp(0, "https://ss0.bdstatic.com/5aV1bjqh_Q23odCf/static/superman/img/logo_top_ca79a146.png");
            });
            Thread th = new Thread(ts);
            th.Start();
            */
        }

        private void picBoxClassify_LoadComplete(object sender, AsyncCompletedEventArgs e)
        {
            picBoxClassify.Image = ZoomPicture(picBoxClassify.Image, picBoxClassify.Width, picBoxClassify.Height);
            picBoxClassify.UseWaitCursor = false;
        }

        private void picBoxLearn_LoadComplete(object sender, AsyncCompletedEventArgs e)
        {
            picBoxLearn.Image = ZoomPicture(picBoxLearn.Image, picBoxLearn.Width, picBoxLearn.Height);
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
            ClearLearnPicBox();

            SendSetProcessStateProtocol((int)curState);
        }

        private void btnEndBatchLearn_Click(object sender, EventArgs e)
        {
            btnLearn.Enabled = false;
            btnEndBatchLearn.Enabled = false;
            ClearLearnPicBox();
            SendEndBatchProcessPotocol((int)curState);

            //TODO: to be deleted
            /*
            ThreadStart ts = new ThreadStart(delegate()
            {
                List<netmessage.LeafGradeCount> leaf_grade_counts = new List<netmessage.LeafGradeCount>(){
                    new netmessage.LeafGradeCount
                    {
                        group = 1,
                        rank = 2,
                        count = 3,
                    },
                    new netmessage.LeafGradeCount
                    {
                        group = 2,
                        rank = 3,
                        count = 4,
                    },
                };
                OnSEndBatchProcessRep(0, leaf_grade_counts);
            });
            Thread th = new Thread(ts);
            th.Start();
            */
        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            if (comboBoxLearn.SelectedItem == null)
            {
                MessageBox.Show(TextRes.text["EmptyLearnGradeErr"]);
                return;
            }
            string cur_item = comboBoxLearn.SelectedItem.ToString();
            LeafGrade lg = LeafGrade.BuildLeafGrade(cur_item.ToUpper());
            if (lg == null)
            {
                MessageBox.Show(TextRes.text["InvalidLearnGradeErr"]);
                return;
            }
            ClearLearnPicBox();
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

        // 按比例缩放图片
        public Image ZoomPicture(Image SourceImage, int TargetWidth, int TargetHeight)
        {
            int IntWidth; //新的图片宽
            int IntHeight; //新的图片高
            try
            {
                System.Drawing.Imaging.ImageFormat format = SourceImage.RawFormat;
                System.Drawing.Bitmap SaveImage = new System.Drawing.Bitmap(TargetWidth, TargetHeight);
                Graphics g = Graphics.FromImage(SaveImage);
                g.Clear(Color.White);

                //计算缩放图片的大小

                if (SourceImage.Width > TargetWidth && SourceImage.Height <= TargetHeight)//宽度比目的图片宽度大，长度比目的图片长度小
                {
                    IntWidth = TargetWidth;
                    IntHeight = (IntWidth * SourceImage.Height) / SourceImage.Width;
                }
                else if (SourceImage.Width <= TargetWidth && SourceImage.Height > TargetHeight)//宽度比目的图片宽度小，长度比目的图片长度大
                {
                    IntHeight = TargetHeight;
                    IntWidth = (IntHeight * SourceImage.Width) / SourceImage.Height;
                }
                else if (SourceImage.Width <= TargetWidth && SourceImage.Height <= TargetHeight) //长宽比目的图片长宽都小
                {
                    IntHeight = SourceImage.Width;
                    IntWidth = SourceImage.Height;
                }
                else//长宽比目的图片的长宽都大
                {
                    IntWidth = TargetWidth;
                    IntHeight = (IntWidth * SourceImage.Height) / SourceImage.Width;
                    if (IntHeight > TargetHeight)//重新计算
                    {
                        IntHeight = TargetHeight;
                        IntWidth = (IntHeight * SourceImage.Width) / SourceImage.Height;
                    }
                }

                g.DrawImage(SourceImage, (TargetWidth - IntWidth) / 2, (TargetHeight - IntHeight) / 2, IntWidth, IntHeight);
                SourceImage.Dispose();

                return SaveImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        private void ClearLearnPicBox()
        {
            if (picBoxLearn.Image != null)
            {
                picBoxLearn.Image.Dispose();
                picBoxLearn.Image = null;
                if (picBoxLearn.InitialImage != null)
                {
                    picBoxLearn.InitialImage.Dispose();
                    picBoxLearn.InitialImage = null;
                }
                picBoxLearn.ImageLocation = null;
                picBoxLearn.Refresh();
            }
        }

        private void ClearClassifyPicBox()
        {
            if (picBoxClassify.Image != null)
            {
                picBoxClassify.Image.Dispose();
                picBoxClassify.Image = null;
                if (picBoxClassify.InitialImage != null)
                {
                    picBoxClassify.InitialImage.Dispose();
                    picBoxClassify.InitialImage = null;
                }
                picBoxClassify.ImageLocation = null;
                picBoxClassify.Refresh();
            }
        }
    }
}
