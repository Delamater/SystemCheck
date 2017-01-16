namespace SystemCheck
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryTimeoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTxtTimeout = new System.Windows.Forms.ToolStripTextBox();
            this.checklistOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspLoginStatusImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabChecks = new System.Windows.Forms.TabControl();
            this.tabCheckChecklist = new System.Windows.Forms.TabPage();
            this.grpCodeToRun = new System.Windows.Forms.GroupBox();
            this.grpBasicChecks = new System.Windows.Forms.GroupBox();
            this.chkCodeToRun = new System.Windows.Forms.CheckedListBox();
            this.ctxCodeToRun = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tspOpenCode = new System.Windows.Forms.ToolStripMenuItem();
            this.grpBasicCheckboxCheckControl = new System.Windows.Forms.GroupBox();
            this.chkRunBasicChecks = new System.Windows.Forms.CheckBox();
            this.tabCheckDatasets = new System.Windows.Forms.TabPage();
            this.grpDataSets = new System.Windows.Forms.GroupBox();
            this.grpDatasetCheckedListbox = new System.Windows.Forms.GroupBox();
            this.chkListDataSets = new System.Windows.Forms.CheckedListBox();
            this.grpRunDataSetChecks = new System.Windows.Forms.GroupBox();
            this.chkRunDataSetChecks = new System.Windows.Forms.CheckBox();
            this.tabCheckEventViewer = new System.Windows.Forms.TabPage();
            this.grpEventViewer = new System.Windows.Forms.GroupBox();
            this.grpEventLogToCheck = new System.Windows.Forms.GroupBox();
            this.dgvEventLogItemsToCheck = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instanceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtEventLogItemsToCheckBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsChecklist1 = new SystemCheck.dsChecklist();
            this.grpEventCheckHeader = new System.Windows.Forms.GroupBox();
            this.chkRunEventLogChecks = new System.Windows.Forms.CheckBox();
            this.txtEventItemToCheck = new System.Windows.Forms.TextBox();
            this.cboLogType = new System.Windows.Forms.ComboBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnAddEventCheck = new System.Windows.Forms.Button();
            this.tabCheckWmiQueries = new System.Windows.Forms.TabPage();
            this.grpWmi = new System.Windows.Forms.GroupBox();
            this.grpWmiQueriesToRun = new System.Windows.Forms.GroupBox();
            this.chkWmiQueriesToRun = new System.Windows.Forms.CheckedListBox();
            this.grpIsWmiQueriesToExecute = new System.Windows.Forms.GroupBox();
            this.chkRunWmiQueries = new System.Windows.Forms.CheckBox();
            this.grpRunLog = new System.Windows.Forms.GroupBox();
            this.dgvRunLog = new System.Windows.Forms.DataGridView();
            this.runIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scriptNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executionStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorDescDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtRunLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpProgressBar = new System.Windows.Forms.GroupBox();
            this.pbarCheckProgress = new System.Windows.Forms.ProgressBar();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.grpDnAndServerInfo = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabDatabaseSelection = new System.Windows.Forms.TabPage();
            this.groDbInfoCollection = new System.Windows.Forms.GroupBox();
            this.grpDbInfo = new System.Windows.Forms.GroupBox();
            this.chtDatabaseFilesPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmChartControls = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyImageToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpDbInfoSelector = new System.Windows.Forms.GroupBox();
            this.lblDatabases = new System.Windows.Forms.Label();
            this.cboDatabases = new System.Windows.Forms.ComboBox();
            this.tabDiskInformation = new System.Windows.Forms.TabPage();
            this.chtDiskInformation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabMemoryInformation = new System.Windows.Forms.TabPage();
            this.chtMemoryInfo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabQuery = new System.Windows.Forms.TabPage();
            this.rtxQuery = new System.Windows.Forms.RichTextBox();
            this.grpReportDetails = new System.Windows.Forms.GroupBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.btnEventLogCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.grpResultsSettings = new System.Windows.Forms.GroupBox();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDatatablesForResults = new System.Windows.Forms.ComboBox();
            this.errorDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveDlg = new System.Windows.Forms.SaveFileDialog();
            this.ttExcelExport = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabChecks.SuspendLayout();
            this.tabCheckChecklist.SuspendLayout();
            this.grpCodeToRun.SuspendLayout();
            this.grpBasicChecks.SuspendLayout();
            this.ctxCodeToRun.SuspendLayout();
            this.grpBasicCheckboxCheckControl.SuspendLayout();
            this.tabCheckDatasets.SuspendLayout();
            this.grpDataSets.SuspendLayout();
            this.grpDatasetCheckedListbox.SuspendLayout();
            this.grpRunDataSetChecks.SuspendLayout();
            this.tabCheckEventViewer.SuspendLayout();
            this.grpEventViewer.SuspendLayout();
            this.grpEventLogToCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventLogItemsToCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEventLogItemsToCheckBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsChecklist1)).BeginInit();
            this.grpEventCheckHeader.SuspendLayout();
            this.tabCheckWmiQueries.SuspendLayout();
            this.grpWmi.SuspendLayout();
            this.grpWmiQueriesToRun.SuspendLayout();
            this.grpIsWmiQueriesToExecute.SuspendLayout();
            this.grpRunLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRunLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRunLogBindingSource)).BeginInit();
            this.grpProgressBar.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.grpDnAndServerInfo.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabDatabaseSelection.SuspendLayout();
            this.groDbInfoCollection.SuspendLayout();
            this.grpDbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtDatabaseFilesPie)).BeginInit();
            this.cmChartControls.SuspendLayout();
            this.grpDbInfoSelector.SuspendLayout();
            this.tabDiskInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtDiskInformation)).BeginInit();
            this.tabMemoryInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtMemoryInfo)).BeginInit();
            this.tabQuery.SuspendLayout();
            this.grpReportDetails.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.grpResultsSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.executeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadDatasetToolStripMenuItem,
            this.toolStripSeparator4,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(140, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // loadDatasetToolStripMenuItem
            // 
            this.loadDatasetToolStripMenuItem.Image = global::SystemCheck.Properties.Resources.Import;
            this.loadDatasetToolStripMenuItem.Name = "loadDatasetToolStripMenuItem";
            this.loadDatasetToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.loadDatasetToolStripMenuItem.Text = "&Load Dataset";
            this.loadDatasetToolStripMenuItem.Click += new System.EventHandler(this.loadDatasetToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(140, 6);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.settingsToolStripMenuItem.Text = "S&ettings";
            this.settingsToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.checklistOptionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryTimeoutToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // queryTimeoutToolStripMenuItem
            // 
            this.queryTimeoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTxtTimeout});
            this.queryTimeoutToolStripMenuItem.Name = "queryTimeoutToolStripMenuItem";
            this.queryTimeoutToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.queryTimeoutToolStripMenuItem.Text = "Query Timeout";
            // 
            // toolStripTxtTimeout
            // 
            this.toolStripTxtTimeout.MaxLength = 4;
            this.toolStripTxtTimeout.Name = "toolStripTxtTimeout";
            this.toolStripTxtTimeout.Size = new System.Drawing.Size(100, 23);
            this.toolStripTxtTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTxtTimeout_KeyPress);
            this.toolStripTxtTimeout.TextChanged += new System.EventHandler(this.toolStripTxtTimeout_TextChanged);
            // 
            // checklistOptionsToolStripMenuItem
            // 
            this.checklistOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.performanceToolStripMenuItem,
            this.operationToolStripMenuItem,
            this.patchingToolStripMenuItem});
            this.checklistOptionsToolStripMenuItem.Enabled = false;
            this.checklistOptionsToolStripMenuItem.Name = "checklistOptionsToolStripMenuItem";
            this.checklistOptionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.checklistOptionsToolStripMenuItem.Text = "Checklist Options";
            this.checklistOptionsToolStripMenuItem.Visible = false;
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.allToolStripMenuItem.Text = "&All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.CheckOnClick = true;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.configurationToolStripMenuItem.Text = "&Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // performanceToolStripMenuItem
            // 
            this.performanceToolStripMenuItem.CheckOnClick = true;
            this.performanceToolStripMenuItem.Name = "performanceToolStripMenuItem";
            this.performanceToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.performanceToolStripMenuItem.Text = "&Performance";
            this.performanceToolStripMenuItem.Click += new System.EventHandler(this.performanceToolStripMenuItem_Click);
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.CheckOnClick = true;
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.operationToolStripMenuItem.Text = "&Operation";
            this.operationToolStripMenuItem.Click += new System.EventHandler(this.operationToolStripMenuItem_Click);
            // 
            // patchingToolStripMenuItem
            // 
            this.patchingToolStripMenuItem.CheckOnClick = true;
            this.patchingToolStripMenuItem.Name = "patchingToolStripMenuItem";
            this.patchingToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.patchingToolStripMenuItem.Text = "Pa&tching";
            this.patchingToolStripMenuItem.Click += new System.EventHandler(this.patchingToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToServerToolStripMenuItem});
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.loginToolStripMenuItem.Text = "Login";
            // 
            // loginToServerToolStripMenuItem
            // 
            this.loginToServerToolStripMenuItem.Image = global::SystemCheck.Properties.Resources.Network;
            this.loginToServerToolStripMenuItem.Name = "loginToServerToolStripMenuItem";
            this.loginToServerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loginToServerToolStripMenuItem.Text = "&Login To Server";
            this.loginToServerToolStripMenuItem.Click += new System.EventHandler(this.loginToServerToolStripMenuItem_Click);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.executeToolStripMenuItem.Text = "&Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(113, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tspLoginStatusImage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 751);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel1.Text = "Login Status: ";
            // 
            // tspLoginStatusImage
            // 
            this.tspLoginStatusImage.Image = global::SystemCheck.Properties.Resources.noresults_uncompressed;
            this.tspLoginStatusImage.Name = "tspLoginStatusImage";
            this.tspLoginStatusImage.Size = new System.Drawing.Size(16, 17);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1016, 727);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(1008, 701);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Checklist";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabChecks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpRunLog);
            this.splitContainer1.Panel2.Controls.Add(this.grpProgressBar);
            this.splitContainer1.Panel2.Controls.Add(this.grpSettings);
            this.splitContainer1.Size = new System.Drawing.Size(1002, 695);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabChecks
            // 
            this.tabChecks.Controls.Add(this.tabCheckChecklist);
            this.tabChecks.Controls.Add(this.tabCheckDatasets);
            this.tabChecks.Controls.Add(this.tabCheckEventViewer);
            this.tabChecks.Controls.Add(this.tabCheckWmiQueries);
            this.tabChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChecks.Location = new System.Drawing.Point(0, 0);
            this.tabChecks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabChecks.Name = "tabChecks";
            this.tabChecks.SelectedIndex = 0;
            this.tabChecks.Size = new System.Drawing.Size(330, 695);
            this.tabChecks.TabIndex = 4;
            // 
            // tabCheckChecklist
            // 
            this.tabCheckChecklist.Controls.Add(this.grpCodeToRun);
            this.tabCheckChecklist.Location = new System.Drawing.Point(4, 22);
            this.tabCheckChecklist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCheckChecklist.Name = "tabCheckChecklist";
            this.tabCheckChecklist.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCheckChecklist.Size = new System.Drawing.Size(322, 669);
            this.tabCheckChecklist.TabIndex = 2;
            this.tabCheckChecklist.Text = "Check list";
            this.tabCheckChecklist.UseVisualStyleBackColor = true;
            // 
            // grpCodeToRun
            // 
            this.grpCodeToRun.Controls.Add(this.grpBasicChecks);
            this.grpCodeToRun.Controls.Add(this.grpBasicCheckboxCheckControl);
            this.grpCodeToRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCodeToRun.Location = new System.Drawing.Point(2, 2);
            this.grpCodeToRun.Name = "grpCodeToRun";
            this.grpCodeToRun.Size = new System.Drawing.Size(318, 665);
            this.grpCodeToRun.TabIndex = 3;
            this.grpCodeToRun.TabStop = false;
            this.grpCodeToRun.Text = "Code To Run";
            // 
            // grpBasicChecks
            // 
            this.grpBasicChecks.Controls.Add(this.chkCodeToRun);
            this.grpBasicChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBasicChecks.Location = new System.Drawing.Point(3, 55);
            this.grpBasicChecks.Name = "grpBasicChecks";
            this.grpBasicChecks.Size = new System.Drawing.Size(312, 607);
            this.grpBasicChecks.TabIndex = 4;
            this.grpBasicChecks.TabStop = false;
            // 
            // chkCodeToRun
            // 
            this.chkCodeToRun.CheckOnClick = true;
            this.chkCodeToRun.ContextMenuStrip = this.ctxCodeToRun;
            this.chkCodeToRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCodeToRun.FormattingEnabled = true;
            this.chkCodeToRun.HorizontalScrollbar = true;
            this.chkCodeToRun.Location = new System.Drawing.Point(3, 16);
            this.chkCodeToRun.Name = "chkCodeToRun";
            this.chkCodeToRun.ScrollAlwaysVisible = true;
            this.chkCodeToRun.Size = new System.Drawing.Size(306, 588);
            this.chkCodeToRun.Sorted = true;
            this.chkCodeToRun.TabIndex = 2;
            this.chkCodeToRun.ThreeDCheckBoxes = true;
            this.chkCodeToRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkCodeToRun_MouseDown);
            // 
            // ctxCodeToRun
            // 
            this.ctxCodeToRun.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspOpenCode});
            this.ctxCodeToRun.Name = "ctxCodeToRun";
            this.ctxCodeToRun.Size = new System.Drawing.Size(184, 28);
            this.ctxCodeToRun.Text = "Open Code";
            // 
            // tspOpenCode
            // 
            this.tspOpenCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspOpenCode.Name = "tspOpenCode";
            this.tspOpenCode.Size = new System.Drawing.Size(183, 24);
            this.tspOpenCode.Text = "Open SQL Code";
            // 
            // grpBasicCheckboxCheckControl
            // 
            this.grpBasicCheckboxCheckControl.Controls.Add(this.chkRunBasicChecks);
            this.grpBasicCheckboxCheckControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBasicCheckboxCheckControl.Location = new System.Drawing.Point(3, 16);
            this.grpBasicCheckboxCheckControl.Name = "grpBasicCheckboxCheckControl";
            this.grpBasicCheckboxCheckControl.Size = new System.Drawing.Size(312, 39);
            this.grpBasicCheckboxCheckControl.TabIndex = 3;
            this.grpBasicCheckboxCheckControl.TabStop = false;
            // 
            // chkRunBasicChecks
            // 
            this.chkRunBasicChecks.AutoSize = true;
            this.chkRunBasicChecks.Checked = true;
            this.chkRunBasicChecks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunBasicChecks.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkRunBasicChecks.Location = new System.Drawing.Point(3, 16);
            this.chkRunBasicChecks.Name = "chkRunBasicChecks";
            this.chkRunBasicChecks.Size = new System.Drawing.Size(306, 17);
            this.chkRunBasicChecks.TabIndex = 2;
            this.chkRunBasicChecks.Text = "Run Basic Checks";
            this.chkRunBasicChecks.UseVisualStyleBackColor = true;
            // 
            // tabCheckDatasets
            // 
            this.tabCheckDatasets.Controls.Add(this.grpDataSets);
            this.tabCheckDatasets.Location = new System.Drawing.Point(4, 22);
            this.tabCheckDatasets.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCheckDatasets.Name = "tabCheckDatasets";
            this.tabCheckDatasets.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCheckDatasets.Size = new System.Drawing.Size(324, 674);
            this.tabCheckDatasets.TabIndex = 0;
            this.tabCheckDatasets.Text = "Datasets";
            this.tabCheckDatasets.UseVisualStyleBackColor = true;
            // 
            // grpDataSets
            // 
            this.grpDataSets.Controls.Add(this.grpDatasetCheckedListbox);
            this.grpDataSets.Controls.Add(this.grpRunDataSetChecks);
            this.grpDataSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDataSets.Location = new System.Drawing.Point(2, 2);
            this.grpDataSets.Name = "grpDataSets";
            this.grpDataSets.Size = new System.Drawing.Size(321, 675);
            this.grpDataSets.TabIndex = 3;
            this.grpDataSets.TabStop = false;
            this.grpDataSets.Text = "Datasets To Gather";
            // 
            // grpDatasetCheckedListbox
            // 
            this.grpDatasetCheckedListbox.Controls.Add(this.chkListDataSets);
            this.grpDatasetCheckedListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatasetCheckedListbox.Location = new System.Drawing.Point(3, 54);
            this.grpDatasetCheckedListbox.Name = "grpDatasetCheckedListbox";
            this.grpDatasetCheckedListbox.Size = new System.Drawing.Size(315, 618);
            this.grpDatasetCheckedListbox.TabIndex = 4;
            this.grpDatasetCheckedListbox.TabStop = false;
            // 
            // chkListDataSets
            // 
            this.chkListDataSets.CheckOnClick = true;
            this.chkListDataSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListDataSets.FormattingEnabled = true;
            this.chkListDataSets.HorizontalScrollbar = true;
            this.chkListDataSets.Location = new System.Drawing.Point(3, 14);
            this.chkListDataSets.Name = "chkListDataSets";
            this.chkListDataSets.ScrollAlwaysVisible = true;
            this.chkListDataSets.Size = new System.Drawing.Size(310, 601);
            this.chkListDataSets.Sorted = true;
            this.chkListDataSets.TabIndex = 2;
            this.chkListDataSets.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkListDataSets_MouseDown);
            // 
            // grpRunDataSetChecks
            // 
            this.grpRunDataSetChecks.Controls.Add(this.chkRunDataSetChecks);
            this.grpRunDataSetChecks.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRunDataSetChecks.Location = new System.Drawing.Point(3, 14);
            this.grpRunDataSetChecks.Name = "grpRunDataSetChecks";
            this.grpRunDataSetChecks.Size = new System.Drawing.Size(315, 41);
            this.grpRunDataSetChecks.TabIndex = 3;
            this.grpRunDataSetChecks.TabStop = false;
            // 
            // chkRunDataSetChecks
            // 
            this.chkRunDataSetChecks.AutoSize = true;
            this.chkRunDataSetChecks.Checked = true;
            this.chkRunDataSetChecks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunDataSetChecks.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkRunDataSetChecks.Location = new System.Drawing.Point(3, 14);
            this.chkRunDataSetChecks.Name = "chkRunDataSetChecks";
            this.chkRunDataSetChecks.Size = new System.Drawing.Size(309, 14);
            this.chkRunDataSetChecks.TabIndex = 0;
            this.chkRunDataSetChecks.Text = "Run Dataset Checks";
            this.chkRunDataSetChecks.UseVisualStyleBackColor = true;
            // 
            // tabCheckEventViewer
            // 
            this.tabCheckEventViewer.Controls.Add(this.grpEventViewer);
            this.tabCheckEventViewer.Location = new System.Drawing.Point(4, 22);
            this.tabCheckEventViewer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCheckEventViewer.Name = "tabCheckEventViewer";
            this.tabCheckEventViewer.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCheckEventViewer.Size = new System.Drawing.Size(324, 674);
            this.tabCheckEventViewer.TabIndex = 1;
            this.tabCheckEventViewer.Text = "Event Viewer";
            this.tabCheckEventViewer.UseVisualStyleBackColor = true;
            // 
            // grpEventViewer
            // 
            this.grpEventViewer.Controls.Add(this.grpEventLogToCheck);
            this.grpEventViewer.Controls.Add(this.grpEventCheckHeader);
            this.grpEventViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEventViewer.Location = new System.Drawing.Point(2, 2);
            this.grpEventViewer.Name = "grpEventViewer";
            this.grpEventViewer.Size = new System.Drawing.Size(321, 675);
            this.grpEventViewer.TabIndex = 4;
            this.grpEventViewer.TabStop = false;
            this.grpEventViewer.Text = "Event Viewer Checks";
            // 
            // grpEventLogToCheck
            // 
            this.grpEventLogToCheck.Controls.Add(this.dgvEventLogItemsToCheck);
            this.grpEventLogToCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEventLogToCheck.Location = new System.Drawing.Point(3, 108);
            this.grpEventLogToCheck.Name = "grpEventLogToCheck";
            this.grpEventLogToCheck.Size = new System.Drawing.Size(315, 564);
            this.grpEventLogToCheck.TabIndex = 8;
            this.grpEventLogToCheck.TabStop = false;
            // 
            // dgvEventLogItemsToCheck
            // 
            this.dgvEventLogItemsToCheck.AllowUserToAddRows = false;
            this.dgvEventLogItemsToCheck.AutoGenerateColumns = false;
            this.dgvEventLogItemsToCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventLogItemsToCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.logTypeDataGridViewTextBoxColumn,
            this.instanceIDDataGridViewTextBoxColumn});
            this.dgvEventLogItemsToCheck.DataSource = this.dtEventLogItemsToCheckBindingSource;
            this.dgvEventLogItemsToCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEventLogItemsToCheck.Location = new System.Drawing.Point(3, 14);
            this.dgvEventLogItemsToCheck.Name = "dgvEventLogItemsToCheck";
            this.dgvEventLogItemsToCheck.ReadOnly = true;
            this.dgvEventLogItemsToCheck.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvEventLogItemsToCheck.RowTemplate.Height = 24;
            this.dgvEventLogItemsToCheck.Size = new System.Drawing.Size(309, 547);
            this.dgvEventLogItemsToCheck.TabIndex = 7;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // logTypeDataGridViewTextBoxColumn
            // 
            this.logTypeDataGridViewTextBoxColumn.DataPropertyName = "LogType";
            this.logTypeDataGridViewTextBoxColumn.HeaderText = "LogType";
            this.logTypeDataGridViewTextBoxColumn.Name = "logTypeDataGridViewTextBoxColumn";
            this.logTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // instanceIDDataGridViewTextBoxColumn
            // 
            this.instanceIDDataGridViewTextBoxColumn.DataPropertyName = "InstanceID";
            this.instanceIDDataGridViewTextBoxColumn.HeaderText = "InstanceID";
            this.instanceIDDataGridViewTextBoxColumn.Name = "instanceIDDataGridViewTextBoxColumn";
            this.instanceIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtEventLogItemsToCheckBindingSource
            // 
            this.dtEventLogItemsToCheckBindingSource.DataMember = "dtEventLogItemsToCheck";
            this.dtEventLogItemsToCheckBindingSource.DataSource = this.dsChecklist1;
            // 
            // dsChecklist1
            // 
            this.dsChecklist1.DataSetName = "dsChecklist";
            this.dsChecklist1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grpEventCheckHeader
            // 
            this.grpEventCheckHeader.Controls.Add(this.chkRunEventLogChecks);
            this.grpEventCheckHeader.Controls.Add(this.txtEventItemToCheck);
            this.grpEventCheckHeader.Controls.Add(this.cboLogType);
            this.grpEventCheckHeader.Controls.Add(this.btnClearList);
            this.grpEventCheckHeader.Controls.Add(this.btnAddEventCheck);
            this.grpEventCheckHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEventCheckHeader.Location = new System.Drawing.Point(3, 14);
            this.grpEventCheckHeader.Name = "grpEventCheckHeader";
            this.grpEventCheckHeader.Size = new System.Drawing.Size(315, 94);
            this.grpEventCheckHeader.TabIndex = 7;
            this.grpEventCheckHeader.TabStop = false;
            // 
            // chkRunEventLogChecks
            // 
            this.chkRunEventLogChecks.AutoSize = true;
            this.chkRunEventLogChecks.Checked = true;
            this.chkRunEventLogChecks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunEventLogChecks.Location = new System.Drawing.Point(7, 13);
            this.chkRunEventLogChecks.Name = "chkRunEventLogChecks";
            this.chkRunEventLogChecks.Size = new System.Drawing.Size(103, 14);
            this.chkRunEventLogChecks.TabIndex = 11;
            this.chkRunEventLogChecks.Text = "Run Event Log Checks";
            this.chkRunEventLogChecks.UseVisualStyleBackColor = true;
            this.chkRunEventLogChecks.CheckedChanged += new System.EventHandler(this.chkRunEventLogChecks_CheckedChanged);
            // 
            // txtEventItemToCheck
            // 
            this.txtEventItemToCheck.Location = new System.Drawing.Point(0, 36);
            this.txtEventItemToCheck.Name = "txtEventItemToCheck";
            this.txtEventItemToCheck.Size = new System.Drawing.Size(243, 20);
            this.txtEventItemToCheck.TabIndex = 10;
            this.txtEventItemToCheck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEventItemToCheck_KeyPress);
            // 
            // cboLogType
            // 
            this.cboLogType.FormattingEnabled = true;
            this.cboLogType.Location = new System.Drawing.Point(3, 67);
            this.cboLogType.Name = "cboLogType";
            this.cboLogType.Size = new System.Drawing.Size(242, 21);
            this.cboLogType.TabIndex = 9;
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(249, 65);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 8;
            this.btnClearList.Text = "Clear";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnAddEventCheck
            // 
            this.btnAddEventCheck.Location = new System.Drawing.Point(249, 36);
            this.btnAddEventCheck.Name = "btnAddEventCheck";
            this.btnAddEventCheck.Size = new System.Drawing.Size(75, 23);
            this.btnAddEventCheck.TabIndex = 6;
            this.btnAddEventCheck.Text = "Add";
            this.btnAddEventCheck.UseVisualStyleBackColor = true;
            this.btnAddEventCheck.Click += new System.EventHandler(this.btnAddEventCheck_Click);
            // 
            // tabCheckWmiQueries
            // 
            this.tabCheckWmiQueries.Controls.Add(this.grpWmi);
            this.tabCheckWmiQueries.Location = new System.Drawing.Point(4, 22);
            this.tabCheckWmiQueries.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCheckWmiQueries.Name = "tabCheckWmiQueries";
            this.tabCheckWmiQueries.Size = new System.Drawing.Size(324, 674);
            this.tabCheckWmiQueries.TabIndex = 3;
            this.tabCheckWmiQueries.Text = "WMI Queries";
            this.tabCheckWmiQueries.UseVisualStyleBackColor = true;
            // 
            // grpWmi
            // 
            this.grpWmi.Controls.Add(this.grpWmiQueriesToRun);
            this.grpWmi.Controls.Add(this.grpIsWmiQueriesToExecute);
            this.grpWmi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWmi.Location = new System.Drawing.Point(0, 0);
            this.grpWmi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpWmi.Name = "grpWmi";
            this.grpWmi.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpWmi.Size = new System.Drawing.Size(326, 678);
            this.grpWmi.TabIndex = 0;
            this.grpWmi.TabStop = false;
            this.grpWmi.Text = "WMI Queries To Gather";
            // 
            // grpWmiQueriesToRun
            // 
            this.grpWmiQueriesToRun.Controls.Add(this.chkWmiQueriesToRun);
            this.grpWmiQueriesToRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWmiQueriesToRun.Location = new System.Drawing.Point(2, 56);
            this.grpWmiQueriesToRun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpWmiQueriesToRun.Name = "grpWmiQueriesToRun";
            this.grpWmiQueriesToRun.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpWmiQueriesToRun.Size = new System.Drawing.Size(321, 621);
            this.grpWmiQueriesToRun.TabIndex = 1;
            this.grpWmiQueriesToRun.TabStop = false;
            // 
            // chkWmiQueriesToRun
            // 
            this.chkWmiQueriesToRun.CheckOnClick = true;
            this.chkWmiQueriesToRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWmiQueriesToRun.FormattingEnabled = true;
            this.chkWmiQueriesToRun.Location = new System.Drawing.Point(2, 12);
            this.chkWmiQueriesToRun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkWmiQueriesToRun.Name = "chkWmiQueriesToRun";
            this.chkWmiQueriesToRun.Size = new System.Drawing.Size(318, 608);
            this.chkWmiQueriesToRun.TabIndex = 0;
            // 
            // grpIsWmiQueriesToExecute
            // 
            this.grpIsWmiQueriesToExecute.Controls.Add(this.chkRunWmiQueries);
            this.grpIsWmiQueriesToExecute.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpIsWmiQueriesToExecute.Location = new System.Drawing.Point(2, 12);
            this.grpIsWmiQueriesToExecute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpIsWmiQueriesToExecute.Name = "grpIsWmiQueriesToExecute";
            this.grpIsWmiQueriesToExecute.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpIsWmiQueriesToExecute.Size = new System.Drawing.Size(321, 44);
            this.grpIsWmiQueriesToExecute.TabIndex = 0;
            this.grpIsWmiQueriesToExecute.TabStop = false;
            // 
            // chkRunWmiQueries
            // 
            this.chkRunWmiQueries.AutoSize = true;
            this.chkRunWmiQueries.Checked = true;
            this.chkRunWmiQueries.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunWmiQueries.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkRunWmiQueries.Location = new System.Drawing.Point(2, 12);
            this.chkRunWmiQueries.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkRunWmiQueries.Name = "chkRunWmiQueries";
            this.chkRunWmiQueries.Size = new System.Drawing.Size(316, 14);
            this.chkRunWmiQueries.TabIndex = 0;
            this.chkRunWmiQueries.Text = "Run WMI Queries?";
            this.chkRunWmiQueries.UseVisualStyleBackColor = true;
            // 
            // grpRunLog
            // 
            this.grpRunLog.Controls.Add(this.dgvRunLog);
            this.grpRunLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRunLog.Location = new System.Drawing.Point(0, 533);
            this.grpRunLog.Name = "grpRunLog";
            this.grpRunLog.Size = new System.Drawing.Size(668, 162);
            this.grpRunLog.TabIndex = 6;
            this.grpRunLog.TabStop = false;
            this.grpRunLog.Text = "Execution Progress";
            // 
            // dgvRunLog
            // 
            this.dgvRunLog.AllowUserToAddRows = false;
            this.dgvRunLog.AllowUserToDeleteRows = false;
            this.dgvRunLog.AutoGenerateColumns = false;
            this.dgvRunLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRunLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.runIDDataGridViewTextBoxColumn,
            this.scriptNameDataGridViewTextBoxColumn,
            this.loginNameDataGridViewTextBoxColumn,
            this.executionStartDataGridViewTextBoxColumn,
            this.errorValueDataGridViewTextBoxColumn,
            this.errorDescDataGridViewTextBoxColumn1});
            this.dgvRunLog.DataSource = this.dtRunLogBindingSource;
            this.dgvRunLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRunLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRunLog.Location = new System.Drawing.Point(3, 16);
            this.dgvRunLog.MultiSelect = false;
            this.dgvRunLog.Name = "dgvRunLog";
            this.dgvRunLog.ReadOnly = true;
            this.dgvRunLog.RowTemplate.Height = 24;
            this.dgvRunLog.Size = new System.Drawing.Size(662, 143);
            this.dgvRunLog.TabIndex = 0;
            // 
            // runIDDataGridViewTextBoxColumn
            // 
            this.runIDDataGridViewTextBoxColumn.DataPropertyName = "RunID";
            this.runIDDataGridViewTextBoxColumn.HeaderText = "RunID";
            this.runIDDataGridViewTextBoxColumn.Name = "runIDDataGridViewTextBoxColumn";
            this.runIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // scriptNameDataGridViewTextBoxColumn
            // 
            this.scriptNameDataGridViewTextBoxColumn.DataPropertyName = "ScriptName";
            this.scriptNameDataGridViewTextBoxColumn.HeaderText = "ScriptName";
            this.scriptNameDataGridViewTextBoxColumn.Name = "scriptNameDataGridViewTextBoxColumn";
            this.scriptNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loginNameDataGridViewTextBoxColumn
            // 
            this.loginNameDataGridViewTextBoxColumn.DataPropertyName = "LoginName";
            this.loginNameDataGridViewTextBoxColumn.HeaderText = "LoginName";
            this.loginNameDataGridViewTextBoxColumn.Name = "loginNameDataGridViewTextBoxColumn";
            this.loginNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // executionStartDataGridViewTextBoxColumn
            // 
            this.executionStartDataGridViewTextBoxColumn.DataPropertyName = "ExecutionStart";
            this.executionStartDataGridViewTextBoxColumn.HeaderText = "ExecutionStart";
            this.executionStartDataGridViewTextBoxColumn.Name = "executionStartDataGridViewTextBoxColumn";
            this.executionStartDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // errorValueDataGridViewTextBoxColumn
            // 
            this.errorValueDataGridViewTextBoxColumn.DataPropertyName = "ErrorValue";
            this.errorValueDataGridViewTextBoxColumn.HeaderText = "ErrorValue";
            this.errorValueDataGridViewTextBoxColumn.Name = "errorValueDataGridViewTextBoxColumn";
            this.errorValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // errorDescDataGridViewTextBoxColumn1
            // 
            this.errorDescDataGridViewTextBoxColumn1.DataPropertyName = "ErrorDesc";
            this.errorDescDataGridViewTextBoxColumn1.HeaderText = "ErrorDesc";
            this.errorDescDataGridViewTextBoxColumn1.Name = "errorDescDataGridViewTextBoxColumn1";
            this.errorDescDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dtRunLogBindingSource
            // 
            this.dtRunLogBindingSource.DataMember = "dtRunLog";
            this.dtRunLogBindingSource.DataSource = this.dsChecklist1;
            // 
            // grpProgressBar
            // 
            this.grpProgressBar.Controls.Add(this.pbarCheckProgress);
            this.grpProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProgressBar.Location = new System.Drawing.Point(0, 493);
            this.grpProgressBar.Name = "grpProgressBar";
            this.grpProgressBar.Size = new System.Drawing.Size(668, 40);
            this.grpProgressBar.TabIndex = 5;
            this.grpProgressBar.TabStop = false;
            // 
            // pbarCheckProgress
            // 
            this.pbarCheckProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbarCheckProgress.Location = new System.Drawing.Point(3, 16);
            this.pbarCheckProgress.Name = "pbarCheckProgress";
            this.pbarCheckProgress.Size = new System.Drawing.Size(662, 21);
            this.pbarCheckProgress.TabIndex = 2;
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.grpDnAndServerInfo);
            this.grpSettings.Controls.Add(this.grpReportDetails);
            this.grpSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSettings.Location = new System.Drawing.Point(0, 0);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(668, 493);
            this.grpSettings.TabIndex = 4;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // grpDnAndServerInfo
            // 
            this.grpDnAndServerInfo.Controls.Add(this.tabControl2);
            this.grpDnAndServerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDnAndServerInfo.Location = new System.Drawing.Point(3, 79);
            this.grpDnAndServerInfo.Name = "grpDnAndServerInfo";
            this.grpDnAndServerInfo.Size = new System.Drawing.Size(662, 411);
            this.grpDnAndServerInfo.TabIndex = 12;
            this.grpDnAndServerInfo.TabStop = false;
            this.grpDnAndServerInfo.Text = "Database And Server Info";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabDatabaseSelection);
            this.tabControl2.Controls.Add(this.tabDiskInformation);
            this.tabControl2.Controls.Add(this.tabMemoryInformation);
            this.tabControl2.Controls.Add(this.tabQuery);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 16);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(656, 392);
            this.tabControl2.TabIndex = 0;
            // 
            // tabDatabaseSelection
            // 
            this.tabDatabaseSelection.Controls.Add(this.groDbInfoCollection);
            this.tabDatabaseSelection.Location = new System.Drawing.Point(4, 22);
            this.tabDatabaseSelection.Name = "tabDatabaseSelection";
            this.tabDatabaseSelection.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabDatabaseSelection.Size = new System.Drawing.Size(648, 366);
            this.tabDatabaseSelection.TabIndex = 0;
            this.tabDatabaseSelection.Text = "Database Selection";
            this.tabDatabaseSelection.UseVisualStyleBackColor = true;
            // 
            // groDbInfoCollection
            // 
            this.groDbInfoCollection.Controls.Add(this.grpDbInfo);
            this.groDbInfoCollection.Controls.Add(this.grpDbInfoSelector);
            this.groDbInfoCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groDbInfoCollection.Location = new System.Drawing.Point(3, 3);
            this.groDbInfoCollection.Name = "groDbInfoCollection";
            this.groDbInfoCollection.Size = new System.Drawing.Size(642, 360);
            this.groDbInfoCollection.TabIndex = 18;
            this.groDbInfoCollection.TabStop = false;
            // 
            // grpDbInfo
            // 
            this.grpDbInfo.Controls.Add(this.chtDatabaseFilesPie);
            this.grpDbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDbInfo.Location = new System.Drawing.Point(3, 81);
            this.grpDbInfo.Name = "grpDbInfo";
            this.grpDbInfo.Size = new System.Drawing.Size(636, 276);
            this.grpDbInfo.TabIndex = 20;
            this.grpDbInfo.TabStop = false;
            this.grpDbInfo.Text = "Database File Info";
            // 
            // chtDatabaseFilesPie
            // 
            this.chtDatabaseFilesPie.BackColor = System.Drawing.SystemColors.Control;
            this.chtDatabaseFilesPie.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 45;
            chartArea1.Area3DStyle.Rotation = 45;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chtDatabaseFilesPie.ChartAreas.Add(chartArea1);
            this.chtDatabaseFilesPie.ContextMenuStrip = this.cmChartControls;
            this.chtDatabaseFilesPie.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chtDatabaseFilesPie.Legends.Add(legend1);
            this.chtDatabaseFilesPie.Location = new System.Drawing.Point(3, 16);
            this.chtDatabaseFilesPie.Name = "chtDatabaseFilesPie";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chtDatabaseFilesPie.Series.Add(series1);
            this.chtDatabaseFilesPie.Size = new System.Drawing.Size(630, 257);
            this.chtDatabaseFilesPie.TabIndex = 13;
            this.chtDatabaseFilesPie.Text = "Database Info";
            title1.Name = "Database File Sizes";
            this.chtDatabaseFilesPie.Titles.Add(title1);
            // 
            // cmChartControls
            // 
            this.cmChartControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem,
            this.copyImageToClipboardToolStripMenuItem});
            this.cmChartControls.Name = "cmChartControls";
            this.cmChartControls.Size = new System.Drawing.Size(250, 52);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Image = global::SystemCheck.Properties.Resources.Save;
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // copyImageToClipboardToolStripMenuItem
            // 
            this.copyImageToClipboardToolStripMenuItem.Image = global::SystemCheck.Properties.Resources.CopyHS;
            this.copyImageToClipboardToolStripMenuItem.Name = "copyImageToClipboardToolStripMenuItem";
            this.copyImageToClipboardToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.copyImageToClipboardToolStripMenuItem.Text = "Copy image To Clipboard";
            this.copyImageToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyImageToClipboardToolStripMenuItem_Click);
            // 
            // grpDbInfoSelector
            // 
            this.grpDbInfoSelector.Controls.Add(this.lblDatabases);
            this.grpDbInfoSelector.Controls.Add(this.cboDatabases);
            this.grpDbInfoSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDbInfoSelector.Location = new System.Drawing.Point(3, 16);
            this.grpDbInfoSelector.Name = "grpDbInfoSelector";
            this.grpDbInfoSelector.Size = new System.Drawing.Size(636, 65);
            this.grpDbInfoSelector.TabIndex = 19;
            this.grpDbInfoSelector.TabStop = false;
            this.grpDbInfoSelector.Text = "Database Selection";
            // 
            // lblDatabases
            // 
            this.lblDatabases.AutoSize = true;
            this.lblDatabases.Location = new System.Drawing.Point(6, 16);
            this.lblDatabases.Name = "lblDatabases";
            this.lblDatabases.Size = new System.Drawing.Size(53, 13);
            this.lblDatabases.TabIndex = 15;
            this.lblDatabases.Text = "Database";
            // 
            // cboDatabases
            // 
            this.cboDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabases.FormattingEnabled = true;
            this.cboDatabases.Location = new System.Drawing.Point(9, 31);
            this.cboDatabases.Name = "cboDatabases";
            this.cboDatabases.Size = new System.Drawing.Size(234, 21);
            this.cboDatabases.TabIndex = 14;
            this.cboDatabases.SelectedIndexChanged += new System.EventHandler(this.cboDatabases_SelectedIndexChanged);
            // 
            // tabDiskInformation
            // 
            this.tabDiskInformation.Controls.Add(this.chtDiskInformation);
            this.tabDiskInformation.Location = new System.Drawing.Point(4, 22);
            this.tabDiskInformation.Name = "tabDiskInformation";
            this.tabDiskInformation.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabDiskInformation.Size = new System.Drawing.Size(649, 370);
            this.tabDiskInformation.TabIndex = 1;
            this.tabDiskInformation.Text = "Disk Information";
            this.tabDiskInformation.UseVisualStyleBackColor = true;
            // 
            // chtDiskInformation
            // 
            this.chtDiskInformation.BackColor = System.Drawing.SystemColors.Control;
            this.chtDiskInformation.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.Area3DStyle.PointDepth = 60;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.Name = "ChartArea1";
            this.chtDiskInformation.ChartAreas.Add(chartArea2);
            this.chtDiskInformation.ContextMenuStrip = this.cmChartControls;
            this.chtDiskInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chtDiskInformation.Legends.Add(legend2);
            this.chtDiskInformation.Location = new System.Drawing.Point(3, 3);
            this.chtDiskInformation.Name = "chtDiskInformation";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series2.CustomProperties = "DrawingStyle=Cylinder";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 2;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series2";
            this.chtDiskInformation.Series.Add(series2);
            this.chtDiskInformation.Series.Add(series3);
            this.chtDiskInformation.Size = new System.Drawing.Size(645, 368);
            this.chtDiskInformation.TabIndex = 0;
            this.chtDiskInformation.Text = "chart1";
            title2.Name = "DiskInfo";
            title2.Text = "Disk Information";
            this.chtDiskInformation.Titles.Add(title2);
            // 
            // tabMemoryInformation
            // 
            this.tabMemoryInformation.Controls.Add(this.chtMemoryInfo);
            this.tabMemoryInformation.Location = new System.Drawing.Point(4, 22);
            this.tabMemoryInformation.Name = "tabMemoryInformation";
            this.tabMemoryInformation.Size = new System.Drawing.Size(649, 370);
            this.tabMemoryInformation.TabIndex = 2;
            this.tabMemoryInformation.Text = "Memory Information";
            this.tabMemoryInformation.UseVisualStyleBackColor = true;
            // 
            // chtMemoryInfo
            // 
            chartArea3.Area3DStyle.Enable3D = true;
            chartArea3.Area3DStyle.IsClustered = true;
            chartArea3.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea3.Area3DStyle.WallWidth = 5;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.chtMemoryInfo.ChartAreas.Add(chartArea3);
            this.chtMemoryInfo.ContextMenuStrip = this.cmChartControls;
            this.chtMemoryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chtMemoryInfo.Legends.Add(legend3);
            this.chtMemoryInfo.Location = new System.Drawing.Point(0, 0);
            this.chtMemoryInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chtMemoryInfo.Name = "chtMemoryInfo";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series2";
            this.chtMemoryInfo.Series.Add(series4);
            this.chtMemoryInfo.Series.Add(series5);
            this.chtMemoryInfo.Size = new System.Drawing.Size(651, 375);
            this.chtMemoryInfo.TabIndex = 0;
            this.chtMemoryInfo.Text = "chart1";
            // 
            // tabQuery
            // 
            this.tabQuery.Controls.Add(this.rtxQuery);
            this.tabQuery.Location = new System.Drawing.Point(4, 22);
            this.tabQuery.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Size = new System.Drawing.Size(649, 370);
            this.tabQuery.TabIndex = 3;
            this.tabQuery.Text = "Query Information";
            this.tabQuery.UseVisualStyleBackColor = true;
            // 
            // rtxQuery
            // 
            this.rtxQuery.DetectUrls = false;
            this.rtxQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxQuery.Location = new System.Drawing.Point(0, 0);
            this.rtxQuery.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtxQuery.Name = "rtxQuery";
            this.rtxQuery.ReadOnly = true;
            this.rtxQuery.Size = new System.Drawing.Size(652, 375);
            this.rtxQuery.TabIndex = 0;
            this.rtxQuery.Text = "";
            // 
            // grpReportDetails
            // 
            this.grpReportDetails.Controls.Add(this.txtCompanyName);
            this.grpReportDetails.Controls.Add(this.btnEventLogCheck);
            this.grpReportDetails.Controls.Add(this.label1);
            this.grpReportDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpReportDetails.Location = new System.Drawing.Point(3, 16);
            this.grpReportDetails.Name = "grpReportDetails";
            this.grpReportDetails.Size = new System.Drawing.Size(662, 63);
            this.grpReportDetails.TabIndex = 11;
            this.grpReportDetails.TabStop = false;
            this.grpReportDetails.Text = "Report Details";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(6, 32);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(326, 20);
            this.txtCompanyName.TabIndex = 11;
            // 
            // btnEventLogCheck
            // 
            this.btnEventLogCheck.Enabled = false;
            this.btnEventLogCheck.Location = new System.Drawing.Point(355, 19);
            this.btnEventLogCheck.Name = "btnEventLogCheck";
            this.btnEventLogCheck.Size = new System.Drawing.Size(117, 23);
            this.btnEventLogCheck.TabIndex = 3;
            this.btnEventLogCheck.Text = "Run Event Check";
            this.btnEventLogCheck.UseVisualStyleBackColor = true;
            this.btnEventLogCheck.Visible = false;
            this.btnEventLogCheck.Click += new System.EventHandler(this.btnEventLogCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Company Name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpResults);
            this.tabPage2.Controls.Add(this.grpResultsSettings);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(1008, 704);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Results";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.dgvResults);
            this.grpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResults.Location = new System.Drawing.Point(3, 80);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(1004, 622);
            this.grpResults.TabIndex = 2;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(3, 15);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.Size = new System.Drawing.Size(998, 604);
            this.dgvResults.TabIndex = 1;
            // 
            // grpResultsSettings
            // 
            this.grpResultsSettings.Controls.Add(this.btnExportToExcel);
            this.grpResultsSettings.Controls.Add(this.label2);
            this.grpResultsSettings.Controls.Add(this.cboDatatablesForResults);
            this.grpResultsSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResultsSettings.Location = new System.Drawing.Point(3, 3);
            this.grpResultsSettings.Name = "grpResultsSettings";
            this.grpResultsSettings.Size = new System.Drawing.Size(1004, 77);
            this.grpResultsSettings.TabIndex = 1;
            this.grpResultsSettings.TabStop = false;
            this.grpResultsSettings.Text = "Settings";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(251, 38);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(108, 23);
            this.btnExportToExcel.TabIndex = 3;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data tables";
            // 
            // cboDatatablesForResults
            // 
            this.cboDatatablesForResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatatablesForResults.FormattingEnabled = true;
            this.cboDatatablesForResults.Location = new System.Drawing.Point(5, 40);
            this.cboDatatablesForResults.Name = "cboDatatablesForResults";
            this.cboDatatablesForResults.Size = new System.Drawing.Size(240, 21);
            this.cboDatatablesForResults.TabIndex = 0;
            this.cboDatatablesForResults.SelectedIndexChanged += new System.EventHandler(this.cboDatatablesForResults_SelectedIndexChanged);
            // 
            // errorDescDataGridViewTextBoxColumn
            // 
            this.errorDescDataGridViewTextBoxColumn.DataPropertyName = "ErrorDesc";
            this.errorDescDataGridViewTextBoxColumn.HeaderText = "ErrorDesc";
            this.errorDescDataGridViewTextBoxColumn.Name = "errorDescDataGridViewTextBoxColumn";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 773);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Check";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabChecks.ResumeLayout(false);
            this.tabCheckChecklist.ResumeLayout(false);
            this.grpCodeToRun.ResumeLayout(false);
            this.grpBasicChecks.ResumeLayout(false);
            this.ctxCodeToRun.ResumeLayout(false);
            this.grpBasicCheckboxCheckControl.ResumeLayout(false);
            this.grpBasicCheckboxCheckControl.PerformLayout();
            this.tabCheckDatasets.ResumeLayout(false);
            this.grpDataSets.ResumeLayout(false);
            this.grpDatasetCheckedListbox.ResumeLayout(false);
            this.grpRunDataSetChecks.ResumeLayout(false);
            this.grpRunDataSetChecks.PerformLayout();
            this.tabCheckEventViewer.ResumeLayout(false);
            this.grpEventViewer.ResumeLayout(false);
            this.grpEventLogToCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventLogItemsToCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEventLogItemsToCheckBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsChecklist1)).EndInit();
            this.grpEventCheckHeader.ResumeLayout(false);
            this.grpEventCheckHeader.PerformLayout();
            this.tabCheckWmiQueries.ResumeLayout(false);
            this.grpWmi.ResumeLayout(false);
            this.grpWmiQueriesToRun.ResumeLayout(false);
            this.grpIsWmiQueriesToExecute.ResumeLayout(false);
            this.grpIsWmiQueriesToExecute.PerformLayout();
            this.grpRunLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRunLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRunLogBindingSource)).EndInit();
            this.grpProgressBar.ResumeLayout(false);
            this.grpSettings.ResumeLayout(false);
            this.grpDnAndServerInfo.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabDatabaseSelection.ResumeLayout(false);
            this.groDbInfoCollection.ResumeLayout(false);
            this.grpDbInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtDatabaseFilesPie)).EndInit();
            this.cmChartControls.ResumeLayout(false);
            this.grpDbInfoSelector.ResumeLayout(false);
            this.grpDbInfoSelector.PerformLayout();
            this.tabDiskInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtDiskInformation)).EndInit();
            this.tabMemoryInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtMemoryInfo)).EndInit();
            this.tabQuery.ResumeLayout(false);
            this.grpReportDetails.ResumeLayout(false);
            this.grpReportDetails.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.grpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.grpResultsSettings.ResumeLayout(false);
            this.grpResultsSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripStatusLabel tspLoginStatusImage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem loginToServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checklistOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem performanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        public dsChecklist dsChecklist1;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dtRunLogBindingSource;
        private System.Windows.Forms.SaveFileDialog saveDlg;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.GroupBox grpResultsSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDatatablesForResults;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.ToolTip ttExcelExport;
        private System.Windows.Forms.GroupBox grpDnAndServerInfo;
        private System.Windows.Forms.GroupBox grpReportDetails;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpProgressBar;
        private System.Windows.Forms.GroupBox grpRunLog;
        private System.Windows.Forms.DataGridView dgvRunLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn runIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scriptNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn executionStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorDescDataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox grpEventViewer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button btnEventLogCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn insrtanceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox grpEventCheckHeader;
        private System.Windows.Forms.ComboBox cboLogType;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnAddEventCheck;
        private System.Windows.Forms.GroupBox grpEventLogToCheck;
        private System.Windows.Forms.DataGridView dgvEventLogItemsToCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtEventItemToCheck;
        private System.Windows.Forms.BindingSource dtEventLogItemsToCheckBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn instanceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.CheckBox chkRunEventLogChecks;
        private System.Windows.Forms.GroupBox grpDataSets;
        private System.Windows.Forms.ToolStripMenuItem queryTimeoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTxtTimeout;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabDatabaseSelection;
        private System.Windows.Forms.GroupBox groDbInfoCollection;
        private System.Windows.Forms.GroupBox grpDbInfo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtDatabaseFilesPie;
        private System.Windows.Forms.GroupBox grpDbInfoSelector;
        private System.Windows.Forms.Label lblDatabases;
        private System.Windows.Forms.ComboBox cboDatabases;
        private System.Windows.Forms.TabPage tabDiskInformation;
        private System.Windows.Forms.TabPage tabMemoryInformation;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtDiskInformation;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtMemoryInfo;
        private System.Windows.Forms.ContextMenuStrip cmChartControls;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyImageToClipboardToolStripMenuItem;
        private System.Windows.Forms.TabControl tabChecks;
        private System.Windows.Forms.TabPage tabCheckDatasets;
        private System.Windows.Forms.GroupBox grpDatasetCheckedListbox;
        private System.Windows.Forms.CheckedListBox chkListDataSets;
        private System.Windows.Forms.GroupBox grpRunDataSetChecks;
        private System.Windows.Forms.CheckBox chkRunDataSetChecks;
        private System.Windows.Forms.TabPage tabCheckEventViewer;
        private System.Windows.Forms.TabPage tabCheckChecklist;
        private System.Windows.Forms.GroupBox grpCodeToRun;
        private System.Windows.Forms.GroupBox grpBasicCheckboxCheckControl;
        private System.Windows.Forms.CheckBox chkRunBasicChecks;
        private System.Windows.Forms.GroupBox grpBasicChecks;
        private System.Windows.Forms.CheckedListBox chkCodeToRun;
        private System.Windows.Forms.TabPage tabCheckWmiQueries;
        private System.Windows.Forms.GroupBox grpWmi;
        private System.Windows.Forms.GroupBox grpWmiQueriesToRun;
        private System.Windows.Forms.CheckedListBox chkWmiQueriesToRun;
        private System.Windows.Forms.GroupBox grpIsWmiQueriesToExecute;
        private System.Windows.Forms.CheckBox chkRunWmiQueries;
        public System.Windows.Forms.ProgressBar pbarCheckProgress;
        private System.Windows.Forms.ToolStripMenuItem loadDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip ctxCodeToRun;
        private System.Windows.Forms.ToolStripMenuItem tspOpenCode;
        private System.Windows.Forms.TabPage tabQuery;
        private System.Windows.Forms.RichTextBox rtxQuery;
    }
}