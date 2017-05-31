namespace csFinalHomework
{
    partial class MainWindow
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
			try { sw.Close(); }
			catch { }
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.txtFilePath = new System.Windows.Forms.TextBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.lstMain = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ofdFileOpen = new System.Windows.Forms.OpenFileDialog();
			this.ssStatus = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.prgbarProcess = new System.Windows.Forms.ToolStripProgressBar();
			this.lblHeapMem = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnProcess = new System.Windows.Forms.Button();
			this.txtSupportThreshold = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkShowInList = new System.Windows.Forms.CheckBox();
			this.sfdFileSave = new System.Windows.Forms.SaveFileDialog();
			this.btnStop = new System.Windows.Forms.Button();
			this.chkIgnoreSingleItem = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grpInputTokenType = new System.Windows.Forms.GroupBox();
			this.radbtnString = new System.Windows.Forms.RadioButton();
			this.radbtnInt = new System.Windows.Forms.RadioButton();
			this.ttReload = new System.Windows.Forms.ToolTip(this.components);
			this.chkGetNumOnly = new System.Windows.Forms.CheckBox();
			this.chkUpdateStatus = new System.Windows.Forms.CheckBox();
			this.btnSortFrequentItemSet = new System.Windows.Forms.Button();
			this.txtSupportPercentThreshold = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRefreshList = new System.Windows.Forms.Button();
			this.btnSaveToFile = new System.Windows.Forms.Button();
			this.btnAbout = new System.Windows.Forms.Button();
			this.btnVisualize = new System.Windows.Forms.Button();
			this.mnuOpen = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuOpenDataSrc = new System.Windows.Forms.ToolStripMenuItem();
			this.cmbConnType = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.mnulbl1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cmbProvider = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnulbl2 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtDataSource = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnulbl3 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtUserID = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnulbl4 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtPassword = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnulbl5 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtConnStr = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnulbl6 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtTableName = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuDataSrcConfirm = new System.Windows.Forms.ToolStripMenuItem();
			this.ssStatus.SuspendLayout();
			this.grpInputTokenType.SuspendLayout();
			this.mnuOpen.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtFilePath
			// 
			this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilePath.Location = new System.Drawing.Point(12, 12);
			this.txtFilePath.Name = "txtFilePath";
			this.txtFilePath.ReadOnly = true;
			this.txtFilePath.Size = new System.Drawing.Size(565, 21);
			this.txtFilePath.TabIndex = 0;
			// 
			// btnOpen
			// 
			this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpen.Location = new System.Drawing.Point(583, 10);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(33, 23);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// lstMain
			// 
			this.lstMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lstMain.FullRowSelect = true;
			this.lstMain.Location = new System.Drawing.Point(12, 39);
			this.lstMain.Name = "lstMain";
			this.lstMain.Size = new System.Drawing.Size(565, 468);
			this.lstMain.TabIndex = 10;
			this.lstMain.UseCompatibleStateImageBehavior = false;
			this.lstMain.View = System.Windows.Forms.View.Details;
			this.lstMain.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstMain_ColumnClick);
			this.lstMain.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lstMain_RetrieveVirtualItem);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "序号";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "项";
			this.columnHeader2.Width = 389;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "支持度";
			// 
			// ofdFileOpen
			// 
			this.ofdFileOpen.DefaultExt = "dat";
			this.ofdFileOpen.Filter = "数据文件|*.dat";
			this.ofdFileOpen.Title = "选择数据文件";
			// 
			// ssStatus
			// 
			this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.prgbarProcess,
            this.lblHeapMem});
			this.ssStatus.Location = new System.Drawing.Point(0, 510);
			this.ssStatus.Name = "ssStatus";
			this.ssStatus.Size = new System.Drawing.Size(751, 22);
			this.ssStatus.TabIndex = 3;
			this.ssStatus.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(519, 17);
			this.lblStatus.Spring = true;
			this.lblStatus.Text = "就绪。";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// prgbarProcess
			// 
			this.prgbarProcess.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.prgbarProcess.MarqueeAnimationSpeed = 0;
			this.prgbarProcess.Name = "prgbarProcess";
			this.prgbarProcess.Size = new System.Drawing.Size(100, 16);
			this.prgbarProcess.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			// 
			// lblHeapMem
			// 
			this.lblHeapMem.Name = "lblHeapMem";
			this.lblHeapMem.Size = new System.Drawing.Size(115, 17);
			this.lblHeapMem.Text = " 堆内存占用：0 MB";
			// 
			// btnProcess
			// 
			this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnProcess.Enabled = false;
			this.btnProcess.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnProcess.ForeColor = System.Drawing.Color.Red;
			this.btnProcess.Location = new System.Drawing.Point(622, 10);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(117, 23);
			this.btnProcess.TabIndex = 2;
			this.btnProcess.Text = "开挖！";
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// txtSupportThreshold
			// 
			this.txtSupportThreshold.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.txtSupportThreshold.Location = new System.Drawing.Point(666, 223);
			this.txtSupportThreshold.Name = "txtSupportThreshold";
			this.txtSupportThreshold.Size = new System.Drawing.Size(52, 21);
			this.txtSupportThreshold.TabIndex = 6;
			this.txtSupportThreshold.Text = "100";
			this.txtSupportThreshold.Validating += new System.ComponentModel.CancelEventHandler(this.txtSupportThreshold_Validating);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(583, 244);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "支持度阈值：";
			// 
			// chkShowInList
			// 
			this.chkShowInList.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.chkShowInList.AutoSize = true;
			this.chkShowInList.Location = new System.Drawing.Point(598, 286);
			this.chkShowInList.Name = "chkShowInList";
			this.chkShowInList.Size = new System.Drawing.Size(120, 16);
			this.chkShowInList.TabIndex = 7;
			this.chkShowInList.Text = "在列表中实时显示";
			this.ttReload.SetToolTip(this.chkShowInList, "不推荐选择：\r\n频繁地刷新列表会导致严重的性能下降");
			this.chkShowInList.UseVisualStyleBackColor = true;
			this.chkShowInList.CheckedChanged += new System.EventHandler(this.chkShowInList_CheckedChanged);
			// 
			// sfdFileSave
			// 
			this.sfdFileSave.DefaultExt = "dat";
			this.sfdFileSave.Filter = "结果数据|*.dat";
			this.sfdFileSave.Title = "选择结果保存目标";
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(613, 442);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(117, 23);
			this.btnStop.TabIndex = 9;
			this.btnStop.Text = "停！";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// chkIgnoreSingleItem
			// 
			this.chkIgnoreSingleItem.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.chkIgnoreSingleItem.AutoSize = true;
			this.chkIgnoreSingleItem.Checked = true;
			this.chkIgnoreSingleItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIgnoreSingleItem.Location = new System.Drawing.Point(598, 308);
			this.chkIgnoreSingleItem.Name = "chkIgnoreSingleItem";
			this.chkIgnoreSingleItem.Size = new System.Drawing.Size(96, 16);
			this.chkIgnoreSingleItem.TabIndex = 8;
			this.chkIgnoreSingleItem.Text = "忽略单项项集";
			this.chkIgnoreSingleItem.UseVisualStyleBackColor = true;
			this.chkIgnoreSingleItem.CheckedChanged += new System.EventHandler(this.chkIgnoreSingleItem_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(724, 226);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "次";
			// 
			// grpInputTokenType
			// 
			this.grpInputTokenType.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.grpInputTokenType.Controls.Add(this.radbtnString);
			this.grpInputTokenType.Controls.Add(this.radbtnInt);
			this.grpInputTokenType.Location = new System.Drawing.Point(599, 136);
			this.grpInputTokenType.Name = "grpInputTokenType";
			this.grpInputTokenType.Size = new System.Drawing.Size(131, 70);
			this.grpInputTokenType.TabIndex = 11;
			this.grpInputTokenType.TabStop = false;
			this.grpInputTokenType.Text = "输入项类型";
			// 
			// radbtnString
			// 
			this.radbtnString.AutoSize = true;
			this.radbtnString.Location = new System.Drawing.Point(33, 42);
			this.radbtnString.Name = "radbtnString";
			this.radbtnString.Size = new System.Drawing.Size(59, 16);
			this.radbtnString.TabIndex = 0;
			this.radbtnString.Text = "字符串";
			this.radbtnString.UseVisualStyleBackColor = true;
			this.radbtnString.CheckedChanged += new System.EventHandler(this.radbtnString_CheckedChanged);
			// 
			// radbtnInt
			// 
			this.radbtnInt.AutoSize = true;
			this.radbtnInt.Checked = true;
			this.radbtnInt.Location = new System.Drawing.Point(33, 20);
			this.radbtnInt.Name = "radbtnInt";
			this.radbtnInt.Size = new System.Drawing.Size(47, 16);
			this.radbtnInt.TabIndex = 0;
			this.radbtnInt.TabStop = true;
			this.radbtnInt.Text = "整数";
			this.radbtnInt.UseVisualStyleBackColor = true;
			// 
			// ttReload
			// 
			this.ttReload.AutoPopDelay = 5000;
			this.ttReload.InitialDelay = 1;
			this.ttReload.ReshowDelay = 100;
			this.ttReload.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.ttReload.ToolTipTitle = "提示";
			// 
			// chkGetNumOnly
			// 
			this.chkGetNumOnly.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.chkGetNumOnly.AutoSize = true;
			this.chkGetNumOnly.Location = new System.Drawing.Point(598, 330);
			this.chkGetNumOnly.Name = "chkGetNumOnly";
			this.chkGetNumOnly.Size = new System.Drawing.Size(132, 16);
			this.chkGetNumOnly.TabIndex = 8;
			this.chkGetNumOnly.Text = "仅统计频繁项集数目";
			this.ttReload.SetToolTip(this.chkGetNumOnly, "开启此项可提升速度……");
			this.chkGetNumOnly.UseVisualStyleBackColor = true;
			this.chkGetNumOnly.CheckedChanged += new System.EventHandler(this.chkGetNumOnly_CheckedChanged);
			// 
			// chkUpdateStatus
			// 
			this.chkUpdateStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.chkUpdateStatus.AutoSize = true;
			this.chkUpdateStatus.Checked = true;
			this.chkUpdateStatus.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUpdateStatus.Location = new System.Drawing.Point(598, 352);
			this.chkUpdateStatus.Name = "chkUpdateStatus";
			this.chkUpdateStatus.Size = new System.Drawing.Size(96, 16);
			this.chkUpdateStatus.TabIndex = 8;
			this.chkUpdateStatus.Text = "显示实时状态";
			this.ttReload.SetToolTip(this.chkUpdateStatus, "关闭此项可以稍稍加快挖掘速度");
			this.chkUpdateStatus.UseVisualStyleBackColor = true;
			this.chkUpdateStatus.CheckedChanged += new System.EventHandler(this.chkUpdateStatus_CheckedChanged);
			// 
			// btnSortFrequentItemSet
			// 
			this.btnSortFrequentItemSet.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnSortFrequentItemSet.Enabled = false;
			this.btnSortFrequentItemSet.Location = new System.Drawing.Point(594, 94);
			this.btnSortFrequentItemSet.Name = "btnSortFrequentItemSet";
			this.btnSortFrequentItemSet.Size = new System.Drawing.Size(145, 23);
			this.btnSortFrequentItemSet.TabIndex = 12;
			this.btnSortFrequentItemSet.Text = "对每个频繁项集排序";
			this.btnSortFrequentItemSet.UseVisualStyleBackColor = true;
			this.btnSortFrequentItemSet.Click += new System.EventHandler(this.btnSortFrequentItemSet_Click);
			// 
			// txtSupportPercentThreshold
			// 
			this.txtSupportPercentThreshold.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.txtSupportPercentThreshold.Location = new System.Drawing.Point(666, 250);
			this.txtSupportPercentThreshold.Name = "txtSupportPercentThreshold";
			this.txtSupportPercentThreshold.Size = new System.Drawing.Size(52, 21);
			this.txtSupportPercentThreshold.TabIndex = 6;
			this.txtSupportPercentThreshold.Text = "0.1";
			this.txtSupportPercentThreshold.Validating += new System.ComponentModel.CancelEventHandler(this.txtSupportPercentThreshold_Validating);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(724, 253);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(11, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "%";
			// 
			// btnRefreshList
			// 
			this.btnRefreshList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefreshList.Location = new System.Drawing.Point(613, 413);
			this.btnRefreshList.Name = "btnRefreshList";
			this.btnRefreshList.Size = new System.Drawing.Size(117, 23);
			this.btnRefreshList.TabIndex = 13;
			this.btnRefreshList.Text = "在列表中显示";
			this.btnRefreshList.UseVisualStyleBackColor = true;
			this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
			// 
			// btnSaveToFile
			// 
			this.btnSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveToFile.Enabled = false;
			this.btnSaveToFile.Location = new System.Drawing.Point(613, 384);
			this.btnSaveToFile.Name = "btnSaveToFile";
			this.btnSaveToFile.Size = new System.Drawing.Size(117, 23);
			this.btnSaveToFile.TabIndex = 13;
			this.btnSaveToFile.Text = "保存到文件...";
			this.btnSaveToFile.UseVisualStyleBackColor = true;
			this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
			// 
			// btnAbout
			// 
			this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAbout.Location = new System.Drawing.Point(613, 471);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(117, 23);
			this.btnAbout.TabIndex = 9;
			this.btnAbout.Text = "关于...";
			this.btnAbout.UseVisualStyleBackColor = true;
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// btnVisualize
			// 
			this.btnVisualize.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnVisualize.Enabled = false;
			this.btnVisualize.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnVisualize.ForeColor = System.Drawing.Color.LimeGreen;
			this.btnVisualize.Location = new System.Drawing.Point(594, 54);
			this.btnVisualize.Name = "btnVisualize";
			this.btnVisualize.Size = new System.Drawing.Size(145, 23);
			this.btnVisualize.TabIndex = 12;
			this.btnVisualize.Text = "可视化显示频繁模式";
			this.btnVisualize.UseVisualStyleBackColor = true;
			this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
			// 
			// mnuOpen
			// 
			this.mnuOpen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenFile,
            this.mnuOpenDataSrc});
			this.mnuOpen.Name = "mnuOpen";
			this.mnuOpen.Size = new System.Drawing.Size(158, 70);
			// 
			// mnuOpenFile
			// 
			this.mnuOpenFile.Image = global::csFinalHomework.Properties.Resources.openfolderHS;
			this.mnuOpenFile.Name = "mnuOpenFile";
			this.mnuOpenFile.Size = new System.Drawing.Size(157, 22);
			this.mnuOpenFile.Text = "打开数据文件...";
			this.mnuOpenFile.Click += new System.EventHandler(this.mnuOpenFile_Click);
			// 
			// mnuOpenDataSrc
			// 
			this.mnuOpenDataSrc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbConnType,
            this.toolStripSeparator6,
            this.mnulbl1,
            this.cmbProvider,
            this.toolStripSeparator1,
            this.mnulbl2,
            this.txtDataSource,
            this.toolStripSeparator2,
            this.mnulbl3,
            this.txtUserID,
            this.toolStripSeparator3,
            this.mnulbl4,
            this.txtPassword,
            this.toolStripSeparator4,
            this.mnulbl5,
            this.txtConnStr,
            this.toolStripSeparator5,
            this.mnulbl6,
            this.txtTableName,
            this.toolStripSeparator7,
            this.mnuDataSrcConfirm});
			this.mnuOpenDataSrc.Image = global::csFinalHomework.Properties.Resources.AddTableHS;
			this.mnuOpenDataSrc.Name = "mnuOpenDataSrc";
			this.mnuOpenDataSrc.Size = new System.Drawing.Size(157, 22);
			this.mnuOpenDataSrc.Text = "打开数据源";
			// 
			// cmbConnType
			// 
			this.cmbConnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbConnType.Items.AddRange(new object[] {
            "SQL",
            "ODBC"});
			this.cmbConnType.Name = "cmbConnType";
			this.cmbConnType.Size = new System.Drawing.Size(300, 25);
			this.cmbConnType.SelectedIndexChanged += new System.EventHandler(this.conn_TextChanged);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(357, 6);
			// 
			// mnulbl1
			// 
			this.mnulbl1.Enabled = false;
			this.mnulbl1.Name = "mnulbl1";
			this.mnulbl1.Size = new System.Drawing.Size(360, 22);
			this.mnulbl1.Text = "Provider:";
			// 
			// cmbProvider
			// 
			this.cmbProvider.Items.AddRange(new object[] {
            "<请选择或输入Provider>",
            "Microsoft.Jet.OLEDB.4.0",
            "SQLOLEDB",
            "MSDAORA.1"});
			this.cmbProvider.Name = "cmbProvider";
			this.cmbProvider.Size = new System.Drawing.Size(300, 25);
			this.cmbProvider.TextChanged += new System.EventHandler(this.conn_TextChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(357, 6);
			// 
			// mnulbl2
			// 
			this.mnulbl2.Enabled = false;
			this.mnulbl2.Name = "mnulbl2";
			this.mnulbl2.Size = new System.Drawing.Size(360, 22);
			this.mnulbl2.Text = "Data Source:";
			// 
			// txtDataSource
			// 
			this.txtDataSource.Name = "txtDataSource";
			this.txtDataSource.Size = new System.Drawing.Size(300, 23);
			this.txtDataSource.TextChanged += new System.EventHandler(this.conn_TextChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(357, 6);
			// 
			// mnulbl3
			// 
			this.mnulbl3.Enabled = false;
			this.mnulbl3.Name = "mnulbl3";
			this.mnulbl3.Size = new System.Drawing.Size(360, 22);
			this.mnulbl3.Text = "User ID:";
			// 
			// txtUserID
			// 
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(300, 23);
			this.txtUserID.TextChanged += new System.EventHandler(this.conn_TextChanged);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(357, 6);
			// 
			// mnulbl4
			// 
			this.mnulbl4.Enabled = false;
			this.mnulbl4.Name = "mnulbl4";
			this.mnulbl4.Size = new System.Drawing.Size(360, 22);
			this.mnulbl4.Text = "Password:";
			// 
			// txtPassword
			// 
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(300, 23);
			this.txtPassword.TextChanged += new System.EventHandler(this.conn_TextChanged);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(357, 6);
			// 
			// mnulbl5
			// 
			this.mnulbl5.Enabled = false;
			this.mnulbl5.Name = "mnulbl5";
			this.mnulbl5.Size = new System.Drawing.Size(360, 22);
			this.mnulbl5.Text = "连接字符串：";
			// 
			// txtConnStr
			// 
			this.txtConnStr.Name = "txtConnStr";
			this.txtConnStr.Size = new System.Drawing.Size(300, 23);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(357, 6);
			// 
			// mnulbl6
			// 
			this.mnulbl6.Enabled = false;
			this.mnulbl6.Name = "mnulbl6";
			this.mnulbl6.Size = new System.Drawing.Size(360, 22);
			this.mnulbl6.Text = "表名：";
			// 
			// txtTableName
			// 
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(300, 23);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(357, 6);
			// 
			// mnuDataSrcConfirm
			// 
			this.mnuDataSrcConfirm.Image = global::csFinalHomework.Properties.Resources._109_AllAnnotations_Default_16x16_72;
			this.mnuDataSrcConfirm.Name = "mnuDataSrcConfirm";
			this.mnuDataSrcConfirm.Size = new System.Drawing.Size(360, 22);
			this.mnuDataSrcConfirm.Text = "确认";
			this.mnuDataSrcConfirm.Click += new System.EventHandler(this.mnuDataSrcConfirm_Click);
			// 
			// MainWindow
			// 
			this.AcceptButton = this.btnProcess;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(751, 532);
			this.Controls.Add(this.btnSaveToFile);
			this.Controls.Add(this.btnRefreshList);
			this.Controls.Add(this.btnVisualize);
			this.Controls.Add(this.btnSortFrequentItemSet);
			this.Controls.Add(this.grpInputTokenType);
			this.Controls.Add(this.chkUpdateStatus);
			this.Controls.Add(this.chkGetNumOnly);
			this.Controls.Add(this.chkIgnoreSingleItem);
			this.Controls.Add(this.chkShowInList);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSupportPercentThreshold);
			this.Controls.Add(this.txtSupportThreshold);
			this.Controls.Add(this.ssStatus);
			this.Controls.Add(this.lstMain);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.txtFilePath);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(767, 571);
			this.Name = "MainWindow";
			this.Text = "频繁模式挖掘与可视化";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.ssStatus.ResumeLayout(false);
			this.ssStatus.PerformLayout();
			this.grpInputTokenType.ResumeLayout(false);
			this.grpInputTokenType.PerformLayout();
			this.mnuOpen.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ListView lstMain;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.OpenFileDialog ofdFileOpen;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar prgbarProcess;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtSupportThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox chkShowInList;
        private System.Windows.Forms.SaveFileDialog sfdFileSave;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkIgnoreSingleItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpInputTokenType;
        private System.Windows.Forms.RadioButton radbtnString;
        private System.Windows.Forms.RadioButton radbtnInt;
        private System.Windows.Forms.ToolStripStatusLabel lblHeapMem;
        private System.Windows.Forms.ToolTip ttReload;
        private System.Windows.Forms.Button btnSortFrequentItemSet;
        private System.Windows.Forms.TextBox txtSupportPercentThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.CheckBox chkGetNumOnly;
        private System.Windows.Forms.Button btnSaveToFile;
		private System.Windows.Forms.CheckBox chkUpdateStatus;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.Button btnVisualize;
		private System.Windows.Forms.ContextMenuStrip mnuOpen;
		private System.Windows.Forms.ToolStripMenuItem mnuOpenFile;
		private System.Windows.Forms.ToolStripMenuItem mnuOpenDataSrc;
		private System.Windows.Forms.ToolStripMenuItem mnuDataSrcConfirm;
		private System.Windows.Forms.ToolStripComboBox cmbProvider;
		private System.Windows.Forms.ToolStripMenuItem mnulbl1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mnulbl2;
		private System.Windows.Forms.ToolStripTextBox txtDataSource;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnulbl3;
		private System.Windows.Forms.ToolStripTextBox txtUserID;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mnulbl4;
		private System.Windows.Forms.ToolStripTextBox txtPassword;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem mnulbl5;
		private System.Windows.Forms.ToolStripTextBox txtConnStr;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripComboBox cmbConnType;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem mnulbl6;
		private System.Windows.Forms.ToolStripTextBox txtTableName;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

