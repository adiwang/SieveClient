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
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPageClassify = new System.Windows.Forms.TabPage();
            this.panelStatistics = new System.Windows.Forms.Panel();
            this.textBoxClassfyGradeCnt = new System.Windows.Forms.TextBox();
            this.labelClassfyGradeCnt = new System.Windows.Forms.Label();
            this.textBoxClassifyStatistics = new System.Windows.Forms.TextBox();
            this.panelClassfigy = new System.Windows.Forms.Panel();
            this.textBoxCurGrade = new System.Windows.Forms.TextBox();
            this.labelCurGrade = new System.Windows.Forms.Label();
            this.picBoxClassify = new System.Windows.Forms.PictureBox();
            this.labelClassifyState = new System.Windows.Forms.Label();
            this.panelClassifyResult = new System.Windows.Forms.Panel();
            this.textBoxClassfiyResult = new System.Windows.Forms.TextBox();
            this.textBoxClassifyCount = new System.Windows.Forms.TextBox();
            this.labelGradeCount = new System.Windows.Forms.Label();
            this.btnClassify = new System.Windows.Forms.Button();
            this.btnEndBatchClassify = new System.Windows.Forms.Button();
            this.btnBeginBatchClassify = new System.Windows.Forms.Button();
            this.tabPageLearn = new System.Windows.Forms.TabPage();
            this.panelLearnStatistics = new System.Windows.Forms.Panel();
            this.textBoxLearnStatistics = new System.Windows.Forms.TextBox();
            this.textBoxLearnTotalCount = new System.Windows.Forms.TextBox();
            this.labelLearnStatistics = new System.Windows.Forms.Label();
            this.panelLearn = new System.Windows.Forms.Panel();
            this.picBoxLearn = new System.Windows.Forms.PictureBox();
            this.labelLearnState = new System.Windows.Forms.Label();
            this.panelLearnResult = new System.Windows.Forms.Panel();
            this.textBoxLearnCnt = new System.Windows.Forms.TextBox();
            this.labelLearnCnt = new System.Windows.Forms.Label();
            this.textBoxLearnResult = new System.Windows.Forms.TextBox();
            this.labelLearnCurGrade = new System.Windows.Forms.Label();
            this.btnEndBatchLearn = new System.Windows.Forms.Button();
            this.btnLearn = new System.Windows.Forms.Button();
            this.btnBeginBatchLearn = new System.Windows.Forms.Button();
            this.comboBoxLearn = new System.Windows.Forms.ComboBox();
            this.tabCtrl.SuspendLayout();
            this.tabPageClassify.SuspendLayout();
            this.panelStatistics.SuspendLayout();
            this.panelClassfigy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClassify)).BeginInit();
            this.panelClassifyResult.SuspendLayout();
            this.tabPageLearn.SuspendLayout();
            this.panelLearnStatistics.SuspendLayout();
            this.panelLearn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLearn)).BeginInit();
            this.panelLearnResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPageClassify);
            this.tabCtrl.Controls.Add(this.tabPageLearn);
            this.tabCtrl.Location = new System.Drawing.Point(12, 66);
            this.tabCtrl.Multiline = true;
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(727, 415);
            this.tabCtrl.TabIndex = 0;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
            this.tabCtrl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabCtrl_Selecting);
            // 
            // tabPageClassify
            // 
            this.tabPageClassify.Controls.Add(this.panelStatistics);
            this.tabPageClassify.Controls.Add(this.panelClassfigy);
            this.tabPageClassify.Controls.Add(this.labelClassifyState);
            this.tabPageClassify.Controls.Add(this.panelClassifyResult);
            this.tabPageClassify.Controls.Add(this.btnClassify);
            this.tabPageClassify.Controls.Add(this.btnEndBatchClassify);
            this.tabPageClassify.Controls.Add(this.btnBeginBatchClassify);
            this.tabPageClassify.Location = new System.Drawing.Point(4, 22);
            this.tabPageClassify.Name = "tabPageClassify";
            this.tabPageClassify.Size = new System.Drawing.Size(719, 389);
            this.tabPageClassify.TabIndex = 0;
            this.tabPageClassify.Tag = "Classify";
            this.tabPageClassify.Text = "分级";
            this.tabPageClassify.UseVisualStyleBackColor = true;
            // 
            // panelStatistics
            // 
            this.panelStatistics.Controls.Add(this.textBoxClassfyGradeCnt);
            this.panelStatistics.Controls.Add(this.labelClassfyGradeCnt);
            this.panelStatistics.Controls.Add(this.textBoxClassifyStatistics);
            this.panelStatistics.Location = new System.Drawing.Point(3, 14);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.Size = new System.Drawing.Size(302, 363);
            this.panelStatistics.TabIndex = 9;
            // 
            // textBoxClassfyGradeCnt
            // 
            this.textBoxClassfyGradeCnt.Location = new System.Drawing.Point(170, 24);
            this.textBoxClassfyGradeCnt.Name = "textBoxClassfyGradeCnt";
            this.textBoxClassfyGradeCnt.Size = new System.Drawing.Size(53, 21);
            this.textBoxClassfyGradeCnt.TabIndex = 2;
            // 
            // labelClassfyGradeCnt
            // 
            this.labelClassfyGradeCnt.AutoSize = true;
            this.labelClassfyGradeCnt.Location = new System.Drawing.Point(13, 27);
            this.labelClassfyGradeCnt.Name = "labelClassfyGradeCnt";
            this.labelClassfyGradeCnt.Size = new System.Drawing.Size(137, 12);
            this.labelClassfyGradeCnt.TabIndex = 1;
            this.labelClassfyGradeCnt.Text = "本批检测包含等级数量: ";
            // 
            // textBoxClassifyStatistics
            // 
            this.textBoxClassifyStatistics.Location = new System.Drawing.Point(3, 71);
            this.textBoxClassifyStatistics.Multiline = true;
            this.textBoxClassifyStatistics.Name = "textBoxClassifyStatistics";
            this.textBoxClassifyStatistics.Size = new System.Drawing.Size(283, 289);
            this.textBoxClassifyStatistics.TabIndex = 0;
            // 
            // panelClassfigy
            // 
            this.panelClassfigy.Controls.Add(this.textBoxCurGrade);
            this.panelClassfigy.Controls.Add(this.labelCurGrade);
            this.panelClassfigy.Controls.Add(this.picBoxClassify);
            this.panelClassfigy.Location = new System.Drawing.Point(0, 14);
            this.panelClassfigy.Name = "panelClassfigy";
            this.panelClassfigy.Size = new System.Drawing.Size(308, 366);
            this.panelClassfigy.TabIndex = 8;
            // 
            // textBoxCurGrade
            // 
            this.textBoxCurGrade.Location = new System.Drawing.Point(98, 331);
            this.textBoxCurGrade.Name = "textBoxCurGrade";
            this.textBoxCurGrade.Size = new System.Drawing.Size(191, 21);
            this.textBoxCurGrade.TabIndex = 5;
            // 
            // labelCurGrade
            // 
            this.labelCurGrade.AutoSize = true;
            this.labelCurGrade.Location = new System.Drawing.Point(20, 334);
            this.labelCurGrade.Name = "labelCurGrade";
            this.labelCurGrade.Size = new System.Drawing.Size(59, 12);
            this.labelCurGrade.TabIndex = 4;
            this.labelCurGrade.Text = "当前级别:";
            // 
            // picBoxClassify
            // 
            this.picBoxClassify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxClassify.Location = new System.Drawing.Point(22, 15);
            this.picBoxClassify.Name = "picBoxClassify";
            this.picBoxClassify.Size = new System.Drawing.Size(267, 289);
            this.picBoxClassify.TabIndex = 3;
            this.picBoxClassify.TabStop = false;
            // 
            // labelClassifyState
            // 
            this.labelClassifyState.AutoSize = true;
            this.labelClassifyState.Location = new System.Drawing.Point(471, 333);
            this.labelClassifyState.Name = "labelClassifyState";
            this.labelClassifyState.Size = new System.Drawing.Size(53, 12);
            this.labelClassifyState.TabIndex = 7;
            this.labelClassifyState.Text = "当前状态";
            // 
            // panelClassifyResult
            // 
            this.panelClassifyResult.Controls.Add(this.textBoxClassfiyResult);
            this.panelClassifyResult.Controls.Add(this.textBoxClassifyCount);
            this.panelClassifyResult.Controls.Add(this.labelGradeCount);
            this.panelClassifyResult.Location = new System.Drawing.Point(318, 52);
            this.panelClassifyResult.Name = "panelClassifyResult";
            this.panelClassifyResult.Size = new System.Drawing.Size(386, 269);
            this.panelClassifyResult.TabIndex = 6;
            // 
            // textBoxClassfiyResult
            // 
            this.textBoxClassfiyResult.Location = new System.Drawing.Point(17, 44);
            this.textBoxClassfiyResult.Multiline = true;
            this.textBoxClassfiyResult.Name = "textBoxClassfiyResult";
            this.textBoxClassfiyResult.Size = new System.Drawing.Size(352, 207);
            this.textBoxClassfiyResult.TabIndex = 2;
            // 
            // textBoxClassifyCount
            // 
            this.textBoxClassifyCount.Location = new System.Drawing.Point(185, 14);
            this.textBoxClassifyCount.Name = "textBoxClassifyCount";
            this.textBoxClassifyCount.Size = new System.Drawing.Size(46, 21);
            this.textBoxClassifyCount.TabIndex = 1;
            // 
            // labelGradeCount
            // 
            this.labelGradeCount.AutoSize = true;
            this.labelGradeCount.Location = new System.Drawing.Point(15, 17);
            this.labelGradeCount.Name = "labelGradeCount";
            this.labelGradeCount.Size = new System.Drawing.Size(155, 12);
            this.labelGradeCount.TabIndex = 0;
            this.labelGradeCount.Text = "本批检测样本包含等级数量:";
            // 
            // btnClassify
            // 
            this.btnClassify.Location = new System.Drawing.Point(473, 14);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(88, 23);
            this.btnClassify.TabIndex = 5;
            this.btnClassify.Text = "单次分级";
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
            // 
            // btnEndBatchClassify
            // 
            this.btnEndBatchClassify.Location = new System.Drawing.Point(609, 14);
            this.btnEndBatchClassify.Name = "btnEndBatchClassify";
            this.btnEndBatchClassify.Size = new System.Drawing.Size(95, 23);
            this.btnEndBatchClassify.TabIndex = 4;
            this.btnEndBatchClassify.Text = "结束批次分级";
            this.btnEndBatchClassify.UseVisualStyleBackColor = true;
            this.btnEndBatchClassify.Click += new System.EventHandler(this.btnEndBatchClassify_Click);
            // 
            // btnBeginBatchClassify
            // 
            this.btnBeginBatchClassify.Location = new System.Drawing.Point(318, 14);
            this.btnBeginBatchClassify.Name = "btnBeginBatchClassify";
            this.btnBeginBatchClassify.Size = new System.Drawing.Size(109, 23);
            this.btnBeginBatchClassify.TabIndex = 3;
            this.btnBeginBatchClassify.Text = "开始批次分级";
            this.btnBeginBatchClassify.UseVisualStyleBackColor = true;
            this.btnBeginBatchClassify.Click += new System.EventHandler(this.btnBeginBatchClassify_Click);
            // 
            // tabPageLearn
            // 
            this.tabPageLearn.Controls.Add(this.panelLearnStatistics);
            this.tabPageLearn.Controls.Add(this.panelLearn);
            this.tabPageLearn.Controls.Add(this.labelLearnState);
            this.tabPageLearn.Controls.Add(this.panelLearnResult);
            this.tabPageLearn.Controls.Add(this.btnEndBatchLearn);
            this.tabPageLearn.Controls.Add(this.btnLearn);
            this.tabPageLearn.Controls.Add(this.btnBeginBatchLearn);
            this.tabPageLearn.Location = new System.Drawing.Point(4, 22);
            this.tabPageLearn.Name = "tabPageLearn";
            this.tabPageLearn.Size = new System.Drawing.Size(719, 389);
            this.tabPageLearn.TabIndex = 1;
            this.tabPageLearn.Tag = "Learn";
            this.tabPageLearn.Text = "学习";
            this.tabPageLearn.UseVisualStyleBackColor = true;
            // 
            // panelLearnStatistics
            // 
            this.panelLearnStatistics.Controls.Add(this.textBoxLearnStatistics);
            this.panelLearnStatistics.Controls.Add(this.textBoxLearnTotalCount);
            this.panelLearnStatistics.Controls.Add(this.labelLearnStatistics);
            this.panelLearnStatistics.Location = new System.Drawing.Point(22, 8);
            this.panelLearnStatistics.Name = "panelLearnStatistics";
            this.panelLearnStatistics.Size = new System.Drawing.Size(291, 354);
            this.panelLearnStatistics.TabIndex = 6;
            // 
            // textBoxLearnStatistics
            // 
            this.textBoxLearnStatistics.Location = new System.Drawing.Point(17, 41);
            this.textBoxLearnStatistics.Multiline = true;
            this.textBoxLearnStatistics.Name = "textBoxLearnStatistics";
            this.textBoxLearnStatistics.Size = new System.Drawing.Size(252, 294);
            this.textBoxLearnStatistics.TabIndex = 2;
            // 
            // textBoxLearnTotalCount
            // 
            this.textBoxLearnTotalCount.Location = new System.Drawing.Point(133, 13);
            this.textBoxLearnTotalCount.Name = "textBoxLearnTotalCount";
            this.textBoxLearnTotalCount.Size = new System.Drawing.Size(67, 21);
            this.textBoxLearnTotalCount.TabIndex = 1;
            // 
            // labelLearnStatistics
            // 
            this.labelLearnStatistics.AutoSize = true;
            this.labelLearnStatistics.Location = new System.Drawing.Point(15, 16);
            this.labelLearnStatistics.Name = "labelLearnStatistics";
            this.labelLearnStatistics.Size = new System.Drawing.Size(107, 12);
            this.labelLearnStatistics.TabIndex = 0;
            this.labelLearnStatistics.Text = "总共学习样本数量:";
            // 
            // panelLearn
            // 
            this.panelLearn.Controls.Add(this.picBoxLearn);
            this.panelLearn.Location = new System.Drawing.Point(19, 12);
            this.panelLearn.Name = "panelLearn";
            this.panelLearn.Size = new System.Drawing.Size(291, 353);
            this.panelLearn.TabIndex = 0;
            // 
            // picBoxLearn
            // 
            this.picBoxLearn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxLearn.Location = new System.Drawing.Point(17, 18);
            this.picBoxLearn.Name = "picBoxLearn";
            this.picBoxLearn.Size = new System.Drawing.Size(254, 316);
            this.picBoxLearn.TabIndex = 0;
            this.picBoxLearn.TabStop = false;
            // 
            // labelLearnState
            // 
            this.labelLearnState.AutoSize = true;
            this.labelLearnState.Location = new System.Drawing.Point(359, 354);
            this.labelLearnState.Name = "labelLearnState";
            this.labelLearnState.Size = new System.Drawing.Size(53, 12);
            this.labelLearnState.TabIndex = 5;
            this.labelLearnState.Text = "当前状态";
            // 
            // panelLearnResult
            // 
            this.panelLearnResult.Controls.Add(this.comboBoxLearn);
            this.panelLearnResult.Controls.Add(this.textBoxLearnCnt);
            this.panelLearnResult.Controls.Add(this.labelLearnCnt);
            this.panelLearnResult.Controls.Add(this.textBoxLearnResult);
            this.panelLearnResult.Controls.Add(this.labelLearnCurGrade);
            this.panelLearnResult.Location = new System.Drawing.Point(338, 53);
            this.panelLearnResult.Name = "panelLearnResult";
            this.panelLearnResult.Size = new System.Drawing.Size(361, 294);
            this.panelLearnResult.TabIndex = 4;
            // 
            // textBoxLearnCnt
            // 
            this.textBoxLearnCnt.Location = new System.Drawing.Point(175, 36);
            this.textBoxLearnCnt.Name = "textBoxLearnCnt";
            this.textBoxLearnCnt.Size = new System.Drawing.Size(100, 21);
            this.textBoxLearnCnt.TabIndex = 4;
            // 
            // labelLearnCnt
            // 
            this.labelLearnCnt.AutoSize = true;
            this.labelLearnCnt.Location = new System.Drawing.Point(25, 42);
            this.labelLearnCnt.Name = "labelLearnCnt";
            this.labelLearnCnt.Size = new System.Drawing.Size(107, 12);
            this.labelLearnCnt.TabIndex = 3;
            this.labelLearnCnt.Text = "本次学习样本数量:";
            // 
            // textBoxLearnResult
            // 
            this.textBoxLearnResult.Location = new System.Drawing.Point(21, 71);
            this.textBoxLearnResult.Multiline = true;
            this.textBoxLearnResult.Name = "textBoxLearnResult";
            this.textBoxLearnResult.Size = new System.Drawing.Size(326, 210);
            this.textBoxLearnResult.TabIndex = 2;
            // 
            // labelLearnCurGrade
            // 
            this.labelLearnCurGrade.AutoSize = true;
            this.labelLearnCurGrade.Location = new System.Drawing.Point(26, 10);
            this.labelLearnCurGrade.Name = "labelLearnCurGrade";
            this.labelLearnCurGrade.Size = new System.Drawing.Size(83, 12);
            this.labelLearnCurGrade.TabIndex = 0;
            this.labelLearnCurGrade.Text = "当前样本级别:";
            // 
            // btnEndBatchLearn
            // 
            this.btnEndBatchLearn.Location = new System.Drawing.Point(598, 12);
            this.btnEndBatchLearn.Name = "btnEndBatchLearn";
            this.btnEndBatchLearn.Size = new System.Drawing.Size(101, 23);
            this.btnEndBatchLearn.TabIndex = 3;
            this.btnEndBatchLearn.Text = "结束批次学习";
            this.btnEndBatchLearn.UseVisualStyleBackColor = true;
            this.btnEndBatchLearn.Click += new System.EventHandler(this.btnEndBatchLearn_Click);
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(473, 12);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(90, 23);
            this.btnLearn.TabIndex = 2;
            this.btnLearn.Text = "单次学习";
            this.btnLearn.UseVisualStyleBackColor = true;
            this.btnLearn.Click += new System.EventHandler(this.btnLearn_Click);
            // 
            // btnBeginBatchLearn
            // 
            this.btnBeginBatchLearn.Location = new System.Drawing.Point(338, 12);
            this.btnBeginBatchLearn.Name = "btnBeginBatchLearn";
            this.btnBeginBatchLearn.Size = new System.Drawing.Size(95, 23);
            this.btnBeginBatchLearn.TabIndex = 1;
            this.btnBeginBatchLearn.Text = "开始批次学习";
            this.btnBeginBatchLearn.UseVisualStyleBackColor = true;
            this.btnBeginBatchLearn.Click += new System.EventHandler(this.btnBeginBatchLearn_Click);
            // 
            // comboBoxLearn
            // 
            this.comboBoxLearn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLearn.FormattingEnabled = true;
            this.comboBoxLearn.Location = new System.Drawing.Point(175, 3);
            this.comboBoxLearn.Name = "comboBoxLearn";
            this.comboBoxLearn.Size = new System.Drawing.Size(101, 20);
            this.comboBoxLearn.TabIndex = 5;
            // 
            // PrimaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 493);
            this.Controls.Add(this.tabCtrl);
            this.Name = "PrimaryForm";
            this.Text = "分级系统";
            this.tabCtrl.ResumeLayout(false);
            this.tabPageClassify.ResumeLayout(false);
            this.tabPageClassify.PerformLayout();
            this.panelStatistics.ResumeLayout(false);
            this.panelStatistics.PerformLayout();
            this.panelClassfigy.ResumeLayout(false);
            this.panelClassfigy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClassify)).EndInit();
            this.panelClassifyResult.ResumeLayout(false);
            this.panelClassifyResult.PerformLayout();
            this.tabPageLearn.ResumeLayout(false);
            this.tabPageLearn.PerformLayout();
            this.panelLearnStatistics.ResumeLayout(false);
            this.panelLearnStatistics.PerformLayout();
            this.panelLearn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLearn)).EndInit();
            this.panelLearnResult.ResumeLayout(false);
            this.panelLearnResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPageClassify;
        private System.Windows.Forms.TabPage tabPageLearn;
        private System.Windows.Forms.Panel panelClassifyResult;
        private System.Windows.Forms.TextBox textBoxClassfiyResult;
        private System.Windows.Forms.TextBox textBoxClassifyCount;
        private System.Windows.Forms.Label labelGradeCount;
        private System.Windows.Forms.Button btnClassify;
        private System.Windows.Forms.Button btnEndBatchClassify;
        private System.Windows.Forms.Button btnBeginBatchClassify;
        private System.Windows.Forms.Label labelClassifyState;
        private System.Windows.Forms.Panel panelClassfigy;
        private System.Windows.Forms.TextBox textBoxCurGrade;
        private System.Windows.Forms.Label labelCurGrade;
        private System.Windows.Forms.PictureBox picBoxClassify;
        private System.Windows.Forms.Panel panelStatistics;
        private System.Windows.Forms.TextBox textBoxClassifyStatistics;
        private System.Windows.Forms.TextBox textBoxClassfyGradeCnt;
        private System.Windows.Forms.Label labelClassfyGradeCnt;
        private System.Windows.Forms.Panel panelLearnStatistics;
        private System.Windows.Forms.TextBox textBoxLearnStatistics;
        private System.Windows.Forms.TextBox textBoxLearnTotalCount;
        private System.Windows.Forms.Label labelLearnStatistics;
        private System.Windows.Forms.Label labelLearnState;
        private System.Windows.Forms.Panel panelLearnResult;
        private System.Windows.Forms.TextBox textBoxLearnResult;
        private System.Windows.Forms.Label labelLearnCurGrade;
        private System.Windows.Forms.Button btnEndBatchLearn;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.Button btnBeginBatchLearn;
        private System.Windows.Forms.Panel panelLearn;
        private System.Windows.Forms.PictureBox picBoxLearn;
        private System.Windows.Forms.TextBox textBoxLearnCnt;
        private System.Windows.Forms.Label labelLearnCnt;
        private System.Windows.Forms.ComboBox comboBoxLearn;
    }
}

