namespace SieveClient
{
    partial class PrimaryForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimaryForm));
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPageClassify = new System.Windows.Forms.TabPage();
            this.labelClassifyState = new System.Windows.Forms.Label();
            this.panelStatistics = new System.Windows.Forms.Panel();
            this.textBoxClassifyStatistics = new System.Windows.Forms.TextBox();
            this.panelClassfigy = new System.Windows.Forms.Panel();
            this.panelClassifyResult = new System.Windows.Forms.Panel();
            this.labelClassfyCnt = new System.Windows.Forms.Label();
            this.labelClassCurGrade = new System.Windows.Forms.Label();
            this.labelClassCurGradeDesc = new System.Windows.Forms.Label();
            this.textBoxClassfiyResult = new System.Windows.Forms.TextBox();
            this.labelGradeCount = new System.Windows.Forms.Label();
            this.tabPageLearn = new System.Windows.Forms.TabPage();
            this.panelLearnStatistics = new System.Windows.Forms.Panel();
            this.labelLearnTotoalCount = new System.Windows.Forms.Label();
            this.textBoxLearnStatistics = new System.Windows.Forms.TextBox();
            this.labelLearnStatistics = new System.Windows.Forms.Label();
            this.panelLearnResult = new System.Windows.Forms.Panel();
            this.comboBoxLearn = new System.Windows.Forms.ComboBox();
            this.labelLearnCnt = new System.Windows.Forms.Label();
            this.labelLearnCurGrade = new System.Windows.Forms.Label();
            this.labelLearnCntDesc = new System.Windows.Forms.Label();
            this.textBoxLearnResult = new System.Windows.Forms.TextBox();
            this.labelLearnCurGradeDesc = new System.Windows.Forms.Label();
            this.panelLearn = new System.Windows.Forms.Panel();
            this.labelLearnState = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.picBoxClassify = new System.Windows.Forms.PictureBox();
            this.pictureBoxGradeCntDesc = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurGradeCntBack = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurGradeDesc = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurLevelBack = new System.Windows.Forms.PictureBox();
            this.btnClassify = new System.Windows.Forms.Button();
            this.btnEndBatchClassify = new System.Windows.Forms.Button();
            this.btnBeginBatchClassify = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurGradeBack = new System.Windows.Forms.PictureBox();
            this.pbCurGradeLearnDesc = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurCount = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picBoxLearn = new System.Windows.Forms.PictureBox();
            this.btnEndBatchLearn = new System.Windows.Forms.Button();
            this.btnLearn = new System.Windows.Forms.Button();
            this.btnBeginBatchLearn = new System.Windows.Forms.Button();
            this.tabCtrl.SuspendLayout();
            this.tabPageClassify.SuspendLayout();
            this.panelStatistics.SuspendLayout();
            this.panelClassfigy.SuspendLayout();
            this.panelClassifyResult.SuspendLayout();
            this.tabPageLearn.SuspendLayout();
            this.panelLearnStatistics.SuspendLayout();
            this.panelLearnResult.SuspendLayout();
            this.panelLearn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClassify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGradeCntDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurGradeCntBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurGradeDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurLevelBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurGradeBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurGradeLearnDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLearn)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPageClassify);
            this.tabCtrl.Controls.Add(this.tabPageLearn);
            this.tabCtrl.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCtrl.Location = new System.Drawing.Point(12, 108);
            this.tabCtrl.Multiline = true;
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabCtrl.RightToLeftLayout = true;
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(760, 417);
            this.tabCtrl.TabIndex = 0;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
            this.tabCtrl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabCtrl_Selecting);
            // 
            // tabPageClassify
            // 
            this.tabPageClassify.Controls.Add(this.labelClassifyState);
            this.tabPageClassify.Controls.Add(this.panelStatistics);
            this.tabPageClassify.Controls.Add(this.panelClassfigy);
            this.tabPageClassify.Controls.Add(this.panelClassifyResult);
            this.tabPageClassify.Controls.Add(this.btnClassify);
            this.tabPageClassify.Controls.Add(this.btnEndBatchClassify);
            this.tabPageClassify.Controls.Add(this.btnBeginBatchClassify);
            this.tabPageClassify.Location = new System.Drawing.Point(4, 35);
            this.tabPageClassify.Name = "tabPageClassify";
            this.tabPageClassify.Size = new System.Drawing.Size(752, 378);
            this.tabPageClassify.TabIndex = 0;
            this.tabPageClassify.Tag = "Classify";
            this.tabPageClassify.Text = "分级";
            this.tabPageClassify.UseVisualStyleBackColor = true;
            // 
            // labelClassifyState
            // 
            this.labelClassifyState.AutoSize = true;
            this.labelClassifyState.Location = new System.Drawing.Point(341, 368);
            this.labelClassifyState.Name = "labelClassifyState";
            this.labelClassifyState.Size = new System.Drawing.Size(88, 26);
            this.labelClassifyState.TabIndex = 7;
            this.labelClassifyState.Text = "当前状态";
            this.labelClassifyState.Visible = false;
            // 
            // panelStatistics
            // 
            this.panelStatistics.Controls.Add(this.textBoxClassifyStatistics);
            this.panelStatistics.Location = new System.Drawing.Point(373, 8);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.Size = new System.Drawing.Size(372, 287);
            this.panelStatistics.TabIndex = 9;
            // 
            // textBoxClassifyStatistics
            // 
            this.textBoxClassifyStatistics.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxClassifyStatistics.ForeColor = System.Drawing.SystemColors.Control;
            this.textBoxClassifyStatistics.Location = new System.Drawing.Point(3, 11);
            this.textBoxClassifyStatistics.Multiline = true;
            this.textBoxClassifyStatistics.Name = "textBoxClassifyStatistics";
            this.textBoxClassifyStatistics.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxClassifyStatistics.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxClassifyStatistics.Size = new System.Drawing.Size(366, 268);
            this.textBoxClassifyStatistics.TabIndex = 0;
            // 
            // panelClassfigy
            // 
            this.panelClassfigy.Controls.Add(this.picBoxClassify);
            this.panelClassfigy.Location = new System.Drawing.Point(370, 10);
            this.panelClassfigy.Name = "panelClassfigy";
            this.panelClassfigy.Size = new System.Drawing.Size(380, 280);
            this.panelClassfigy.TabIndex = 8;
            // 
            // panelClassifyResult
            // 
            this.panelClassifyResult.Controls.Add(this.labelClassfyCnt);
            this.panelClassifyResult.Controls.Add(this.labelClassCurGrade);
            this.panelClassifyResult.Controls.Add(this.labelClassCurGradeDesc);
            this.panelClassifyResult.Controls.Add(this.textBoxClassfiyResult);
            this.panelClassifyResult.Controls.Add(this.labelGradeCount);
            this.panelClassifyResult.Controls.Add(this.pictureBoxGradeCntDesc);
            this.panelClassifyResult.Controls.Add(this.pictureBoxCurGradeCntBack);
            this.panelClassifyResult.Controls.Add(this.pictureBoxCurGradeDesc);
            this.panelClassifyResult.Controls.Add(this.pictureBoxCurLevelBack);
            this.panelClassifyResult.Location = new System.Drawing.Point(3, 10);
            this.panelClassifyResult.Name = "panelClassifyResult";
            this.panelClassifyResult.Size = new System.Drawing.Size(361, 352);
            this.panelClassifyResult.TabIndex = 6;
            // 
            // labelClassfyCnt
            // 
            this.labelClassfyCnt.AutoSize = true;
            this.labelClassfyCnt.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelClassfyCnt.ForeColor = System.Drawing.SystemColors.Control;
            this.labelClassfyCnt.Location = new System.Drawing.Point(30, 211);
            this.labelClassfyCnt.Name = "labelClassfyCnt";
            this.labelClassfyCnt.Size = new System.Drawing.Size(0, 46);
            this.labelClassfyCnt.TabIndex = 11;
            // 
            // labelClassCurGrade
            // 
            this.labelClassCurGrade.AutoSize = true;
            this.labelClassCurGrade.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelClassCurGrade.ForeColor = System.Drawing.SystemColors.Control;
            this.labelClassCurGrade.Location = new System.Drawing.Point(24, 42);
            this.labelClassCurGrade.Name = "labelClassCurGrade";
            this.labelClassCurGrade.Size = new System.Drawing.Size(0, 42);
            this.labelClassCurGrade.TabIndex = 10;
            // 
            // labelClassCurGradeDesc
            // 
            this.labelClassCurGradeDesc.AutoSize = true;
            this.labelClassCurGradeDesc.ForeColor = System.Drawing.SystemColors.Control;
            this.labelClassCurGradeDesc.Location = new System.Drawing.Point(17, 134);
            this.labelClassCurGradeDesc.Name = "labelClassCurGradeDesc";
            this.labelClassCurGradeDesc.Size = new System.Drawing.Size(88, 26);
            this.labelClassCurGradeDesc.TabIndex = 4;
            this.labelClassCurGradeDesc.Text = "当前级别";
            // 
            // textBoxClassfiyResult
            // 
            this.textBoxClassfiyResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClassfiyResult.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxClassfiyResult.Location = new System.Drawing.Point(127, 7);
            this.textBoxClassfiyResult.Multiline = true;
            this.textBoxClassfiyResult.Name = "textBoxClassfiyResult";
            this.textBoxClassfiyResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxClassfiyResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxClassfiyResult.Size = new System.Drawing.Size(219, 340);
            this.textBoxClassfiyResult.TabIndex = 2;
            // 
            // labelGradeCount
            // 
            this.labelGradeCount.AutoSize = true;
            this.labelGradeCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGradeCount.ForeColor = System.Drawing.SystemColors.Control;
            this.labelGradeCount.Location = new System.Drawing.Point(6, 312);
            this.labelGradeCount.Name = "labelGradeCount";
            this.labelGradeCount.Size = new System.Drawing.Size(104, 17);
            this.labelGradeCount.TabIndex = 0;
            this.labelGradeCount.Text = "样本包含等级数量";
            // 
            // tabPageLearn
            // 
            this.tabPageLearn.Controls.Add(this.panelLearnStatistics);
            this.tabPageLearn.Controls.Add(this.panelLearnResult);
            this.tabPageLearn.Controls.Add(this.panelLearn);
            this.tabPageLearn.Controls.Add(this.labelLearnState);
            this.tabPageLearn.Controls.Add(this.btnEndBatchLearn);
            this.tabPageLearn.Controls.Add(this.btnLearn);
            this.tabPageLearn.Controls.Add(this.btnBeginBatchLearn);
            this.tabPageLearn.Location = new System.Drawing.Point(4, 35);
            this.tabPageLearn.Name = "tabPageLearn";
            this.tabPageLearn.Size = new System.Drawing.Size(752, 378);
            this.tabPageLearn.TabIndex = 1;
            this.tabPageLearn.Tag = "Learn";
            this.tabPageLearn.Text = "学习";
            this.tabPageLearn.UseVisualStyleBackColor = true;
            // 
            // panelLearnStatistics
            // 
            this.panelLearnStatistics.Controls.Add(this.labelLearnTotoalCount);
            this.panelLearnStatistics.Controls.Add(this.textBoxLearnStatistics);
            this.panelLearnStatistics.Controls.Add(this.labelLearnStatistics);
            this.panelLearnStatistics.Controls.Add(this.pictureBox2);
            this.panelLearnStatistics.Location = new System.Drawing.Point(373, 8);
            this.panelLearnStatistics.Name = "panelLearnStatistics";
            this.panelLearnStatistics.Size = new System.Drawing.Size(372, 287);
            this.panelLearnStatistics.TabIndex = 6;
            // 
            // labelLearnTotoalCount
            // 
            this.labelLearnTotoalCount.AutoSize = true;
            this.labelLearnTotoalCount.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLearnTotoalCount.Location = new System.Drawing.Point(212, 241);
            this.labelLearnTotoalCount.Name = "labelLearnTotoalCount";
            this.labelLearnTotoalCount.Size = new System.Drawing.Size(71, 39);
            this.labelLearnTotoalCount.TabIndex = 4;
            this.labelLearnTotoalCount.Text = "100";
            // 
            // textBoxLearnStatistics
            // 
            this.textBoxLearnStatistics.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxLearnStatistics.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxLearnStatistics.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxLearnStatistics.Location = new System.Drawing.Point(3, 11);
            this.textBoxLearnStatistics.Multiline = true;
            this.textBoxLearnStatistics.Name = "textBoxLearnStatistics";
            this.textBoxLearnStatistics.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLearnStatistics.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLearnStatistics.Size = new System.Drawing.Size(366, 228);
            this.textBoxLearnStatistics.TabIndex = 2;
            // 
            // labelLearnStatistics
            // 
            this.labelLearnStatistics.AutoSize = true;
            this.labelLearnStatistics.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLearnStatistics.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLearnStatistics.Location = new System.Drawing.Point(20, 250);
            this.labelLearnStatistics.Name = "labelLearnStatistics";
            this.labelLearnStatistics.Size = new System.Drawing.Size(138, 22);
            this.labelLearnStatistics.TabIndex = 0;
            this.labelLearnStatistics.Text = "总共学习样本数量";
            // 
            // panelLearnResult
            // 
            this.panelLearnResult.Controls.Add(this.comboBoxLearn);
            this.panelLearnResult.Controls.Add(this.labelLearnCnt);
            this.panelLearnResult.Controls.Add(this.labelLearnCurGrade);
            this.panelLearnResult.Controls.Add(this.labelLearnCntDesc);
            this.panelLearnResult.Controls.Add(this.textBoxLearnResult);
            this.panelLearnResult.Controls.Add(this.labelLearnCurGradeDesc);
            this.panelLearnResult.Controls.Add(this.pictureBoxCurGradeBack);
            this.panelLearnResult.Controls.Add(this.pbCurGradeLearnDesc);
            this.panelLearnResult.Controls.Add(this.pictureBoxCurCount);
            this.panelLearnResult.Controls.Add(this.pictureBox1);
            this.panelLearnResult.Location = new System.Drawing.Point(3, 10);
            this.panelLearnResult.Name = "panelLearnResult";
            this.panelLearnResult.Size = new System.Drawing.Size(361, 352);
            this.panelLearnResult.TabIndex = 4;
            // 
            // comboBoxLearn
            // 
            this.comboBoxLearn.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxLearn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLearn.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxLearn.FormattingEnabled = true;
            this.comboBoxLearn.Location = new System.Drawing.Point(27, 45);
            this.comboBoxLearn.Name = "comboBoxLearn";
            this.comboBoxLearn.Size = new System.Drawing.Size(67, 36);
            this.comboBoxLearn.TabIndex = 5;
            // 
            // labelLearnCnt
            // 
            this.labelLearnCnt.AutoSize = true;
            this.labelLearnCnt.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLearnCnt.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLearnCnt.Location = new System.Drawing.Point(33, 203);
            this.labelLearnCnt.Name = "labelLearnCnt";
            this.labelLearnCnt.Size = new System.Drawing.Size(0, 64);
            this.labelLearnCnt.TabIndex = 11;
            // 
            // labelLearnCurGrade
            // 
            this.labelLearnCurGrade.AutoSize = true;
            this.labelLearnCurGrade.BackColor = System.Drawing.Color.Transparent;
            this.labelLearnCurGrade.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLearnCurGrade.ForeColor = System.Drawing.SystemColors.Window;
            this.labelLearnCurGrade.Location = new System.Drawing.Point(35, 28);
            this.labelLearnCurGrade.Name = "labelLearnCurGrade";
            this.labelLearnCurGrade.Size = new System.Drawing.Size(50, 28);
            this.labelLearnCurGrade.TabIndex = 7;
            this.labelLearnCurGrade.Text = "B1L";
            this.labelLearnCurGrade.Visible = false;
            // 
            // labelLearnCntDesc
            // 
            this.labelLearnCntDesc.AutoSize = true;
            this.labelLearnCntDesc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLearnCntDesc.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLearnCntDesc.Location = new System.Drawing.Point(9, 310);
            this.labelLearnCntDesc.Name = "labelLearnCntDesc";
            this.labelLearnCntDesc.Size = new System.Drawing.Size(106, 22);
            this.labelLearnCntDesc.TabIndex = 3;
            this.labelLearnCntDesc.Text = "本次学习数量";
            // 
            // textBoxLearnResult
            // 
            this.textBoxLearnResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLearnResult.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxLearnResult.Location = new System.Drawing.Point(127, 7);
            this.textBoxLearnResult.Multiline = true;
            this.textBoxLearnResult.Name = "textBoxLearnResult";
            this.textBoxLearnResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLearnResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLearnResult.Size = new System.Drawing.Size(219, 340);
            this.textBoxLearnResult.TabIndex = 2;
            // 
            // labelLearnCurGradeDesc
            // 
            this.labelLearnCurGradeDesc.AutoSize = true;
            this.labelLearnCurGradeDesc.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLearnCurGradeDesc.ForeColor = System.Drawing.SystemColors.Window;
            this.labelLearnCurGradeDesc.Location = new System.Drawing.Point(15, 134);
            this.labelLearnCurGradeDesc.Name = "labelLearnCurGradeDesc";
            this.labelLearnCurGradeDesc.Size = new System.Drawing.Size(92, 27);
            this.labelLearnCurGradeDesc.TabIndex = 0;
            this.labelLearnCurGradeDesc.Text = "当前级别";
            // 
            // panelLearn
            // 
            this.panelLearn.Controls.Add(this.picBoxLearn);
            this.panelLearn.Location = new System.Drawing.Point(370, 10);
            this.panelLearn.Name = "panelLearn";
            this.panelLearn.Size = new System.Drawing.Size(380, 280);
            this.panelLearn.TabIndex = 0;
            // 
            // labelLearnState
            // 
            this.labelLearnState.AutoSize = true;
            this.labelLearnState.Location = new System.Drawing.Point(361, 370);
            this.labelLearnState.Name = "labelLearnState";
            this.labelLearnState.Size = new System.Drawing.Size(88, 26);
            this.labelLearnState.TabIndex = 5;
            this.labelLearnState.Text = "当前状态";
            this.labelLearnState.Visible = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::SieveClient.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(16, 13);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(459, 49);
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // picBoxClassify
            // 
            this.picBoxClassify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxClassify.Location = new System.Drawing.Point(0, 13);
            this.picBoxClassify.Name = "picBoxClassify";
            this.picBoxClassify.Size = new System.Drawing.Size(375, 264);
            this.picBoxClassify.TabIndex = 3;
            this.picBoxClassify.TabStop = false;
            // 
            // pictureBoxGradeCntDesc
            // 
            this.pictureBoxGradeCntDesc.BackgroundImage = global::SieveClient.Properties.Resources.CurClassCntDescBack;
            this.pictureBoxGradeCntDesc.Location = new System.Drawing.Point(3, 300);
            this.pictureBoxGradeCntDesc.Name = "pictureBoxGradeCntDesc";
            this.pictureBoxGradeCntDesc.Size = new System.Drawing.Size(118, 40);
            this.pictureBoxGradeCntDesc.TabIndex = 8;
            this.pictureBoxGradeCntDesc.TabStop = false;
            // 
            // pictureBoxCurGradeCntBack
            // 
            this.pictureBoxCurGradeCntBack.BackgroundImage = global::SieveClient.Properties.Resources.CurClassCntBack;
            this.pictureBoxCurGradeCntBack.Location = new System.Drawing.Point(14, 185);
            this.pictureBoxCurGradeCntBack.Name = "pictureBoxCurGradeCntBack";
            this.pictureBoxCurGradeCntBack.Size = new System.Drawing.Size(97, 98);
            this.pictureBoxCurGradeCntBack.TabIndex = 9;
            this.pictureBoxCurGradeCntBack.TabStop = false;
            // 
            // pictureBoxCurGradeDesc
            // 
            this.pictureBoxCurGradeDesc.BackgroundImage = global::SieveClient.Properties.Resources.CurClassGradeDescBack;
            this.pictureBoxCurGradeDesc.Location = new System.Drawing.Point(14, 126);
            this.pictureBoxCurGradeDesc.Name = "pictureBoxCurGradeDesc";
            this.pictureBoxCurGradeDesc.Size = new System.Drawing.Size(94, 40);
            this.pictureBoxCurGradeDesc.TabIndex = 7;
            this.pictureBoxCurGradeDesc.TabStop = false;
            // 
            // pictureBoxCurLevelBack
            // 
            this.pictureBoxCurLevelBack.BackgroundImage = global::SieveClient.Properties.Resources.CurClassGradeBack;
            this.pictureBoxCurLevelBack.Location = new System.Drawing.Point(14, 14);
            this.pictureBoxCurLevelBack.Name = "pictureBoxCurLevelBack";
            this.pictureBoxCurLevelBack.Size = new System.Drawing.Size(97, 97);
            this.pictureBoxCurLevelBack.TabIndex = 6;
            this.pictureBoxCurLevelBack.TabStop = false;
            // 
            // btnClassify
            // 
            this.btnClassify.FlatAppearance.BorderSize = 0;
            this.btnClassify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassify.Image = global::SieveClient.Properties.Resources.SingleClassBtn;
            this.btnClassify.Location = new System.Drawing.Point(636, 305);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(108, 56);
            this.btnClassify.TabIndex = 5;
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
            // 
            // btnEndBatchClassify
            // 
            this.btnEndBatchClassify.FlatAppearance.BorderSize = 0;
            this.btnEndBatchClassify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndBatchClassify.Image = global::SieveClient.Properties.Resources.EndBatchClassBtn;
            this.btnEndBatchClassify.Location = new System.Drawing.Point(508, 305);
            this.btnEndBatchClassify.Name = "btnEndBatchClassify";
            this.btnEndBatchClassify.Size = new System.Drawing.Size(111, 56);
            this.btnEndBatchClassify.TabIndex = 4;
            this.btnEndBatchClassify.UseVisualStyleBackColor = true;
            this.btnEndBatchClassify.Click += new System.EventHandler(this.btnEndBatchClassify_Click);
            // 
            // btnBeginBatchClassify
            // 
            this.btnBeginBatchClassify.FlatAppearance.BorderSize = 0;
            this.btnBeginBatchClassify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeginBatchClassify.Image = global::SieveClient.Properties.Resources.StartBatchClassBtn;
            this.btnBeginBatchClassify.Location = new System.Drawing.Point(370, 305);
            this.btnBeginBatchClassify.Name = "btnBeginBatchClassify";
            this.btnBeginBatchClassify.Size = new System.Drawing.Size(113, 56);
            this.btnBeginBatchClassify.TabIndex = 3;
            this.btnBeginBatchClassify.UseVisualStyleBackColor = true;
            this.btnBeginBatchClassify.Click += new System.EventHandler(this.btnBeginBatchClassify_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SieveClient.Properties.Resources.TotalLearnCntDescBack;
            this.pictureBox2.Location = new System.Drawing.Point(3, 245);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(174, 31);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBoxCurGradeBack
            // 
            this.pictureBoxCurGradeBack.BackgroundImage = global::SieveClient.Properties.Resources.CurLearnGradeBack;
            this.pictureBoxCurGradeBack.Location = new System.Drawing.Point(14, 14);
            this.pictureBoxCurGradeBack.Name = "pictureBoxCurGradeBack";
            this.pictureBoxCurGradeBack.Size = new System.Drawing.Size(97, 97);
            this.pictureBoxCurGradeBack.TabIndex = 6;
            this.pictureBoxCurGradeBack.TabStop = false;
            // 
            // pbCurGradeLearnDesc
            // 
            this.pbCurGradeLearnDesc.BackgroundImage = global::SieveClient.Properties.Resources.CurLearnGradeDescBack;
            this.pbCurGradeLearnDesc.Location = new System.Drawing.Point(14, 126);
            this.pbCurGradeLearnDesc.Name = "pbCurGradeLearnDesc";
            this.pbCurGradeLearnDesc.Size = new System.Drawing.Size(94, 41);
            this.pbCurGradeLearnDesc.TabIndex = 9;
            this.pbCurGradeLearnDesc.TabStop = false;
            // 
            // pictureBoxCurCount
            // 
            this.pictureBoxCurCount.BackgroundImage = global::SieveClient.Properties.Resources.CurLearnCntBack;
            this.pictureBoxCurCount.Location = new System.Drawing.Point(14, 185);
            this.pictureBoxCurCount.Name = "pictureBoxCurCount";
            this.pictureBoxCurCount.Size = new System.Drawing.Size(97, 98);
            this.pictureBoxCurCount.TabIndex = 8;
            this.pictureBoxCurCount.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SieveClient.Properties.Resources.CurLearnCntDescBack;
            this.pictureBox1.Location = new System.Drawing.Point(3, 300);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 40);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // picBoxLearn
            // 
            this.picBoxLearn.BackColor = System.Drawing.SystemColors.WindowText;
            this.picBoxLearn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxLearn.Location = new System.Drawing.Point(0, 13);
            this.picBoxLearn.Name = "picBoxLearn";
            this.picBoxLearn.Size = new System.Drawing.Size(375, 264);
            this.picBoxLearn.TabIndex = 0;
            this.picBoxLearn.TabStop = false;
            // 
            // btnEndBatchLearn
            // 
            this.btnEndBatchLearn.FlatAppearance.BorderSize = 0;
            this.btnEndBatchLearn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEndBatchLearn.Image = global::SieveClient.Properties.Resources.EndBatchLearnBtn;
            this.btnEndBatchLearn.Location = new System.Drawing.Point(508, 305);
            this.btnEndBatchLearn.Name = "btnEndBatchLearn";
            this.btnEndBatchLearn.Size = new System.Drawing.Size(105, 54);
            this.btnEndBatchLearn.TabIndex = 3;
            this.btnEndBatchLearn.UseVisualStyleBackColor = true;
            this.btnEndBatchLearn.Click += new System.EventHandler(this.btnEndBatchLearn_Click);
            // 
            // btnLearn
            // 
            this.btnLearn.FlatAppearance.BorderSize = 0;
            this.btnLearn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLearn.Image = global::SieveClient.Properties.Resources.SingleLearnBtn;
            this.btnLearn.Location = new System.Drawing.Point(636, 305);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(109, 55);
            this.btnLearn.TabIndex = 2;
            this.btnLearn.UseVisualStyleBackColor = true;
            this.btnLearn.Click += new System.EventHandler(this.btnLearn_Click);
            // 
            // btnBeginBatchLearn
            // 
            this.btnBeginBatchLearn.FlatAppearance.BorderSize = 0;
            this.btnBeginBatchLearn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeginBatchLearn.Image = ((System.Drawing.Image)(resources.GetObject("btnBeginBatchLearn.Image")));
            this.btnBeginBatchLearn.Location = new System.Drawing.Point(370, 301);
            this.btnBeginBatchLearn.Name = "btnBeginBatchLearn";
            this.btnBeginBatchLearn.Size = new System.Drawing.Size(118, 63);
            this.btnBeginBatchLearn.TabIndex = 1;
            this.btnBeginBatchLearn.UseVisualStyleBackColor = true;
            this.btnBeginBatchLearn.Click += new System.EventHandler(this.btnBeginBatchLearn_Click);
            // 
            // PrimaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.tabCtrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrimaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "烤烟质量智能分级系统 v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrimaryForm_FormClosing);
            this.tabCtrl.ResumeLayout(false);
            this.tabPageClassify.ResumeLayout(false);
            this.tabPageClassify.PerformLayout();
            this.panelStatistics.ResumeLayout(false);
            this.panelStatistics.PerformLayout();
            this.panelClassfigy.ResumeLayout(false);
            this.panelClassifyResult.ResumeLayout(false);
            this.panelClassifyResult.PerformLayout();
            this.tabPageLearn.ResumeLayout(false);
            this.tabPageLearn.PerformLayout();
            this.panelLearnStatistics.ResumeLayout(false);
            this.panelLearnStatistics.PerformLayout();
            this.panelLearnResult.ResumeLayout(false);
            this.panelLearnResult.PerformLayout();
            this.panelLearn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClassify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGradeCntDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurGradeCntBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurGradeDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurLevelBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurGradeBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurGradeLearnDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLearn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPageClassify;
        private System.Windows.Forms.TabPage tabPageLearn;
        private System.Windows.Forms.Panel panelClassifyResult;
        private System.Windows.Forms.TextBox textBoxClassfiyResult;
        private System.Windows.Forms.Label labelGradeCount;
        private System.Windows.Forms.Button btnClassify;
        private System.Windows.Forms.Button btnEndBatchClassify;
        private System.Windows.Forms.Button btnBeginBatchClassify;
        private System.Windows.Forms.Label labelClassifyState;
        private System.Windows.Forms.Panel panelClassfigy;
        private System.Windows.Forms.Label labelClassCurGradeDesc;
        private System.Windows.Forms.PictureBox picBoxClassify;
        private System.Windows.Forms.Panel panelStatistics;
        private System.Windows.Forms.TextBox textBoxClassifyStatistics;
        private System.Windows.Forms.Panel panelLearnStatistics;
        private System.Windows.Forms.TextBox textBoxLearnStatistics;
        private System.Windows.Forms.Label labelLearnStatistics;
        private System.Windows.Forms.Label labelLearnState;
        private System.Windows.Forms.Panel panelLearnResult;
        private System.Windows.Forms.TextBox textBoxLearnResult;
        private System.Windows.Forms.Label labelLearnCurGradeDesc;
        private System.Windows.Forms.Button btnEndBatchLearn;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.Button btnBeginBatchLearn;
        private System.Windows.Forms.Panel panelLearn;
        private System.Windows.Forms.Label labelLearnCntDesc;
        private System.Windows.Forms.ComboBox comboBoxLearn;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxCurGradeBack;
        private System.Windows.Forms.PictureBox picBoxLearn;
        private System.Windows.Forms.Label labelLearnCurGrade;
        private System.Windows.Forms.PictureBox pictureBoxCurCount;
        private System.Windows.Forms.PictureBox pictureBoxCurLevelBack;
        private System.Windows.Forms.PictureBox pictureBoxCurGradeDesc;
        private System.Windows.Forms.PictureBox pictureBoxGradeCntDesc;
        private System.Windows.Forms.PictureBox pictureBoxCurGradeCntBack;
        private System.Windows.Forms.PictureBox pbCurGradeLearnDesc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelLearnCnt;
        private System.Windows.Forms.Label labelLearnTotoalCount;
        private System.Windows.Forms.Label labelClassCurGrade;
        private System.Windows.Forms.Label labelClassfyCnt;
    }
}

