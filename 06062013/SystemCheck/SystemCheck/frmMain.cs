using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;



namespace SystemCheck
{
    public partial class frmMain : Form
    {
        #region "Declarations"
        private ErrorHandler _err = new ErrorHandler();
        private FileMgr _fmgr = new FileMgr();
        private DataAccessLayer _dal = new DataAccessLayer();
        private DataSetsToGather _DataSetsToGather = new DataSetsToGather();
        private frmLogin _logIn = new frmLogin();
        private Checklist _chk = new Checklist();
        private GridMgr _grd = new GridMgr();
        private Strings _str = new Strings();
        private ApplicationLicensing.LicenseCheck _alm = new ApplicationLicensing.LicenseCheck();
        private Boolean blnIsLicensed = false;
        private EventLogChecker _evt = new EventLogChecker();
        private Strings.Utilies _strUtils = new Strings.Utilies();
        private Utilities.SchemaUtilities _schemaUtils = new Utilities.SchemaUtilities();

        private dsChecklist.dtChecklistDataTable _dtCheckListBasicChecksForComboBox;
        private dsChecklist.dtChecklistDataTable _dtCheckListDatasetsToGatherForComboBox;

        private Stack easterEgg = new Stack(12);

        private System.Data.DataTable _dtDiskInformation;

        public dsChecklist.dtChecklistDataTable BasicChecksDataset
        {
            get { return _dtCheckListBasicChecksForComboBox; }
            set { _dtCheckListBasicChecksForComboBox = value; }
        }
        public dsChecklist.dtChecklistDataTable DatasetsToGather
        {
            get { return _dtCheckListDatasetsToGatherForComboBox; }
            set { _dtCheckListDatasetsToGatherForComboBox = value; }
        }

        #endregion

        #region "Menu Commands"

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                ContextMenuStrip strip = (ContextMenuStrip)item.Owner;

                DialogResult dlgResult = new DialogResult();
                SaveFileDialog saveDlg =
                    _fmgr.SaveFile(GetShortChartName(strip), true, "Png Files|*.Png", "Png", false, true, true, true);
                
                dlgResult = saveDlg.ShowDialog();

                //Save Disk Info Chart To File
                if (strip.SourceControl.Name == chtDiskInformation.Name)
                {
                    chtDiskInformation.SaveImage(saveDlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    return;
                }

                //Save Database Info Chart To File
                if (strip.SourceControl.Name == chtDatabaseFilesPie.Name)
                {
                    chtDatabaseFilesPie.SaveImage(saveDlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    return;
                }

                //Save Memory Info Chart To File
                if (strip.SourceControl.Name == chtMemoryInfo.Name)
                {
                    chtMemoryInfo.SaveImage(saveDlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    return;
                }
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyImageToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                ContextMenuStrip strip = (ContextMenuStrip)item.Owner;

                using (MemoryStream ms = new MemoryStream())
                {

                    string strChartName = GetShortChartName(strip);

                    // Copy Database File Chart To Clipboard
                    if (strip.SourceControl.Name == chtDatabaseFilesPie.Name)
                    {
                        chtDatabaseFilesPie.SaveImage(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        Bitmap bm = new Bitmap(ms);
                        Clipboard.SetImage(bm);
                        return;
                    }

                    // Copy Disk Info Chart To Clipboard
                    if (strip.SourceControl.Name == chtDiskInformation.Name)
                    {
                        chtDiskInformation.SaveImage(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        Bitmap bm = new Bitmap(ms);
                        Clipboard.SetImage(bm);
                        return;
                    }

                    // Copy Memory Info Chart To Clipboard
                    if (strip.SourceControl.Name == chtMemoryInfo.Name)
                    {
                        chtMemoryInfo.SaveImage(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        Bitmap bm = new Bitmap(ms);
                        Clipboard.SetImage(bm);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetShortChartName(ContextMenuStrip strip)
        {
            string strChartName = "Unknown";

            if (strip.SourceControl.Name == chtDiskInformation.Name)
            {
                strChartName = "DiskInfo";
                return strChartName;
            }

            if (strip.SourceControl.Name == chtMemoryInfo.Name)
            {
                strChartName = "MemoryInfo";
                return strChartName;
            }

            if (strip.SourceControl.Name == chtDatabaseFilesPie.Name)
            {
                strChartName = "DatabaseInfo";
                return strChartName;
            }

            return strChartName;
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Application.Exit();
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                //Has the checklist been populated with actual data, meaning run against a database?
                if (_schemaUtils.IsCheckListDataTablePopulated(dsChecklist1.Tables["dtChecklist"]) == true)
                {

                    //Did you enter a company name for the report?
                    if (!string.IsNullOrEmpty(txtCompanyName.Text))
                    {
                        Reports.frmSystemCheckOutput rvSystemCheckOutput =
                            new Reports.frmSystemCheckOutput();

                        rvSystemCheckOutput.myCompanyName = txtCompanyName.Text;
                        
                        DataView dvResults = new DataView(dsChecklist1.Tables["dtChecklist"]);
                        dvResults.RowFilter = "IsForOutput = 1 AND IsExecute = 1 AND IsForDataSet = 0";

                        rvSystemCheckOutput.ReportDatasource = dvResults;

                        rvSystemCheckOutput.ShowDialog();
                    }
                    else
                    {
                        _err.ShowMessage(Strings.kCompanyNameIsRequired, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _err.ShowMessage(Strings.kCheckListDatatableIsEmpty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ResetChecklistDataSet();
            dsChecklist1.dtRunLog.Clear();
            
            // There must be a database connection set
            if (cboDatabases.SelectedIndex == -1)
            {
                return;
            }

            try
            {

                //Execute the code set to IsExecute = 1

                pbarCheckProgress.Value = 1;

                if (dsChecklist1.dtRunLog.Rows.Count > 0)
                {
                    dsChecklist1.dtRunLog.Clear();

                }

                SetDatasetIsExecuteProperty(dsChecklist1);
                SetTotalItemsToExecute();

                //Loop through standard checklist requests
                if (chkRunBasicChecks.Checked == true)
                {
                    _chk.GetCheckListDataset(dsChecklist1);
                }

                //Loop through custom dataset requests
                if (chkRunDataSetChecks.Checked == true)
                {
                    dsChecklist1 = _chk.GetDataTableResults(dsChecklist1);
                }

                //Run the event viewer log checks
                if (chkRunEventLogChecks.Checked == true)
                {
                    if (dsChecklist1.dtEventLogItemsToCheck.Rows.Count > 0)
                    {
                        RunEventLogChecks();
                    }
                }

                //Run WMI Queries
                if (chkRunWmiQueries.Checked == true)
                {
                    RunWmiDataSets();
                }

                ShowData();
                BindForm(false);
            }
            catch (ApplicationException ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                _err.ShowError(new ApplicationException
                    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (SqlException ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                _err.ShowError(new ApplicationException
                    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                _err.ShowError(new ApplicationException
                    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadCboDataTables();
                _grd.ApplyGridStyle(dgvResults);
                _grd.ApplyGridStyle(dgvRunLog);
                pbarCheckProgress.Value = 0;
            }
        }

        private void SetTotalItemsToExecute()
        {
            int intTotalItemsToExecute = 0;
            if (chkRunBasicChecks.Checked == true)
            {
                intTotalItemsToExecute += chkCodeToRun.CheckedIndices.Count;
            }

            if (chkRunDataSetChecks.Checked == true)
            {
                intTotalItemsToExecute += chkListDataSets.CheckedIndices.Count;
            }

            if (chkRunEventLogChecks.Checked == true)
            {
                intTotalItemsToExecute += dgvEventLogItemsToCheck.Rows.Count;
            }

            if (chkRunWmiQueries.Checked == true)
            {
                intTotalItemsToExecute += chkWmiQueriesToRun.CheckedIndices.Count;
            }

            _chk.TotalItemsToExecute = intTotalItemsToExecute;
        }

        private void loginToServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                _logIn.ShowDialog();

                if ( _logIn.myConnection == null)
                {
                    ShowLoginStatus(false);
                }
                else if(_logIn.myConnection != null && _logIn.myConnection.ConnectionString == string.Empty )
                {
                    // We've logged in once before and now the myConnection property has some value, 
                    // but the user clicked cancel and so they chose to not reconnect
                    ShowLoginStatus(false);
                }
                else if(_logIn.myConnection != null 
                    && _logIn.myConnection.ConnectionString != string.Empty
                    && _logIn.TestConnection(_logIn.myConnection.ConnectionString) == false)
                {
                    // For some reason, the connection string has been set, but it is wrong.
                    ShowLoginStatus(false);
                }

                else
                {
                    ShowLoginStatus(true);
                    //Populate cboDatabases
                    SqlDataReader srDatabases;
                    System.Data.DataTable dtDatabases = new System.Data.DataTable();

                    srDatabases = DataAccessLayer.ExecuteQuery(
                        "SELECT name FROM sys.databases", 
                        CommandType.Text, 
                        Convert.ToDecimal(Convert.ToDouble(_str.MinTsqlCompatibilityVersion)));
                    dtDatabases.Load(srDatabases);
                    cboDatabases.DataSource = dtDatabases;
                    cboDatabases.DisplayMember = "name";

                    SetAbleToExecuteAgainstDatabaseVisualIndicators(true);

                    //SetDatabaseChartInfo(cboDatabases.SelectedText);
                    saveToolStripMenuItem.Enabled = true;
                    
                    SetDiskInformationChartInfo();
                    //SetProductInformation();
                    SetMemoryChartInfo();
                    //GetWin32_PerfFormattedData_PerfOS_Memory();
                }
            }
            catch (Exception ex)
            {
                //Set visual indicators that system is not connected
                ShowLoginStatus(false);
 
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetAbleToExecuteAgainstDatabaseVisualIndicators(bool blnIsEnabled)
        {
            if (blnIsEnabled == false)
            {
                if (_logIn.TestConnection(_logIn.myConnection.ConnectionString) == false)
                {
                    toolStripStatusLabel1.Text = "Login Status: ";
                    tspLoginStatusImage.Image = Properties.Resources.noresults_uncompressed;

                    executeToolStripMenuItem.Enabled = false;
                }
            }
            else if (blnIsEnabled == true)
            {
                executeToolStripMenuItem.Enabled = true;
            }

        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allToolStripMenuItem.Checked = !allToolStripMenuItem.Checked;

            switch (allToolStripMenuItem.Checked)
            {
                case true:

                    foreach (System.Windows.Forms.ToolStripMenuItem ctl in checklistOptionsToolStripMenuItem.DropDownItems)
                    {
                        if (ctl.Name != allToolStripMenuItem.Name)
                        {
                            ctl.Checked = false;
                            ctl.Enabled = false;
                        }
                    }

                    break;

                case false:

                    foreach (System.Windows.Forms.ToolStripMenuItem ctl in checklistOptionsToolStripMenuItem.DropDownItems)
                    {
                        if (ctl.Name != allToolStripMenuItem.Name)
                        {
                            ctl.Enabled = true;
                        }
                    }
                    break;
            }

            SetChkControlCheckedProperty(allToolStripMenuItem, Strings.enumCategory.All);
        }

        private void performanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetChkControlCheckedProperty(performanceToolStripMenuItem, Strings.enumCategory.Performance);
        }

        private void operationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetChkControlCheckedProperty(operationToolStripMenuItem, Strings.enumCategory.Operation);
        }

        private void patchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetChkControlCheckedProperty(patchingToolStripMenuItem, Strings.enumCategory.Patching);
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetChkControlCheckedProperty(configurationToolStripMenuItem, Strings.enumCategory.Configuration);
        }

        #endregion

        #region "Licensing"
        /// <summary>
        /// Checks if application is licensed. If not, a string will be copied into the clipboard.
        /// Send that string to the person who holds the LicenseMaker program, who will then decrypt
        /// and send back a key. 
        /// </summary>
        private void CheckIfLicensed()
        {
            try
            {
                UpdateLicenseFile();
                switch (_alm.IsLicensed(Strings.LicenseFileFullPath))
                {
                    case true:
                        //Notify app that we are licensed
                        blnIsLicensed = true;
                        break;

                    case false:
                        blnIsLicensed = false;
                        _err.ShowError(new ApplicationException(_alm.ApplicationNotLicensedErrorMessage),
                             MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                }
            }
            catch (Exception ex)
            {
                Exception ex2 = new ApplicationException(ex.Message
                    + Environment.NewLine
                    + Environment.NewLine
                    + _alm.ApplicationNotLicensedErrorMessage);
                _err.ShowError(ex2, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (blnIsLicensed == false)
                {
                    Clipboard.SetText(_alm.RequestLicense());
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        /// <summary>
        /// Loop through the command line arguments
        /// One of these arguments will contain the path to the startup directory
        /// The other might contain the name of the license file, 
        /// if the user is double clicking the license file to start the program
        /// </summary>
        private void UpdateLicenseFile()
        {
            //Get all the arguments
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                //Loop through the args to find the location of the file that is launching
                for (int i = 0; i < args.Length; i++)
                {

                    if (args[i].ToString().Contains(Strings.LicenseFileName))
                    {

                        //We are launching from the license file
                        //First, determine if the file is where it is expected to be
                        //if (!System.IO.File.Exists(Strings.LicenseFileFullPath))
                        //{
                        //    //The file already exists, replace it                           
                        //    System.IO.File.Copy(args[i].ToString(), Strings.LicenseFileFullPath, true);
                        //}

                        //Overwrite the license file
                        System.IO.File.Copy(args[i].ToString(), Strings.LicenseFileFullPath, true);

                    }
                }

            }

        }
        #endregion
        private void ClearDatabaseComboBox()
        {
            if (cboDatabases.Items.Count > 0)
            {
                cboDatabases.DataSource = null;
                System.Data.DataTable dt = (System.Data.DataTable)cboDatabases.DataSource;
                dt.Rows.Clear();
                //cboDatabases.Items.Clear();
            }
        }

        private void ClearDatabasePieChart()
        {
            chtDatabaseFilesPie.Visible = false;
        }

        private void ClearDiskStackedColumn100Chart()
        {
            chtDiskInformation.Visible = false;
        }

        private void ClearMemoryPieChart()
        {
            chtMemoryInfo.Visible = false;
        }
        #region "WMI Queries"

        private void SetDatabaseChartInfo(string DatabaseName)
        {
            try
            {
                //Set chart to visible
                chtDatabaseFilesPie.Visible = true;

                //Get a datatable for the chart control
                System.Data.DataTable dtDbInfo = new System.Data.DataTable();

                //String to retrieve size and location of each database file
                string strGetDatabaseFileInfo =
                    "SELECT name, (size*8)/1024 SizeInMb, physical_name FROM sys.database_files";

                //Minimum version of this query requires SQL 9.0, or SQL 2005
                dtDbInfo = DataAccessLayer.GetDataTable(strGetDatabaseFileInfo, CommandType.Text, "DataFileInfo", 9);

                chtDatabaseFilesPie.DataSource = dtDbInfo;
                chtDatabaseFilesPie.Series["Series1"].ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chtDatabaseFilesPie.Series["Series1"]["PointWidth"] = "0.5";
                chtDatabaseFilesPie.Series["Series1"].IsValueShownAsLabel = true;
                chtDatabaseFilesPie.Series["Series1"]["BarLabelStyle"] = "Center";
                chtDatabaseFilesPie.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                chtDatabaseFilesPie.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;
                chtDatabaseFilesPie.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 45;
                //chtDatabaseFilesPie.Series["Series1"]["DrawingStyle"] = "Cylinder";
                chtDatabaseFilesPie.Series["Series1"].XValueMember = "Name";
                chtDatabaseFilesPie.Series["Series1"].YValueMembers = "SizeInMb";

                chtDatabaseFilesPie.DataBind();
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDiskInformationChartInfo()
        {
            // A series in a chart can be thought of like a series of data. 
            // If you looked at this in a two dimensional table you would see something like the following:
            // SeriesName       | C       | E         | etc..
            // TotalSpaceUsed   | 290484  | 271220    |
            // FreeSpace        | 186143  | 34023     |

            // So in the example above, on a stackedcolumn100 chart you would see
            // Two cylinders. Both cylinders would be split into two unequal parts.
            // Both parts of the first clinder belong to point C (two points, 290484 and 186143)
            // The bottom half of the first cylinder will have a volume of 290484 and the top half will
            // have a volume of 186143.
            //
            // A second cylinder will also be present on the graph with two unequal vertical distributions.
            // The bottom half will have a volume of 271220 and the top half will have a volume 
            // of 34023. 
            //
            // The "etc.." above represents any additional points that might be added to the graph. 
            // These would represent additional cylinders in the graph.
            
            try
            {
                //Ensure chart is visible
                chtDiskInformation.Visible = true;

                //Clear any series left over from design time
                chtDiskInformation.Series.Clear();

                // Get the Data Table
                this._dtDiskInformation = GetLogicalDiskInfo();

                // Set visual properties of the Chart Area
                chtDiskInformation.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                chtDiskInformation.ChartAreas["ChartArea1"].Area3DStyle.LightStyle =
                    System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
                chtDiskInformation.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;
                chtDiskInformation.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 30;

                // Set Series details
                chtDiskInformation.Series.Add("TotalSpaceUsedMb");
                chtDiskInformation.Series["TotalSpaceUsedMb"].YValuesPerPoint = 1;
                chtDiskInformation.Series.Add("FreeSpaceMb");
                chtDiskInformation.Series["FreeSpaceMb"].YValuesPerPoint = 1;

                //Loop through each series and set display properties
                foreach (System.Windows.Forms.DataVisualization.Charting.Series mySeries in chtDiskInformation.Series)
                {
                    mySeries["DrawingStyle"] = "Cylinder";
                    mySeries["BarLabelStyle"] = "Center";
                    mySeries.IsValueShownAsLabel = true;
                    mySeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
                }


                foreach (DataRow dr in this._dtDiskInformation.Rows)
                {
                    //Set the TotalSpaceUsedMb series points
                    chtDiskInformation.Series["TotalSpaceUsedMb"].Points.AddXY(dr["Caption"].ToString(), Convert.ToDouble(dr["TotalSpaceUsedMb"].ToString()));

                    //Set the FreeSpaceMb series points
                    chtDiskInformation.Series["FreeSpaceMb"].Points.AddXY(dr["Caption"].ToString(), Convert.ToDouble(dr["FreeSpaceMb"].ToString()));
                }

               
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                _err.ShowError(new ApplicationException
                    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetMemoryChartInfo()
        
        {
            //Set chart to visible
            chtMemoryInfo.Visible = true;

            //Make a data table to store values
            System.Data.DataTable dt = new System.Data.DataTable("Win32_PhysicalMemory");

            //Get data
            WmiRequester.Win32_PhysicalMemory wmiMem = new WmiRequester.Win32_PhysicalMemory();
            dt = wmiMem.GetWin32_PhysicalMemory(_logIn.WindowsMachineName, _logIn.WindowsUser, _logIn.WindowsPwd);

            if (dt.Rows.Count > 0)
            {
                //Clear the series on the chart
                chtMemoryInfo.Series.Clear();

                //Add two series, speed and capacity
                chtMemoryInfo.Series.Add("Speed");
                chtMemoryInfo.Series.Add("Capacity");

                //Set chart properties
                chtMemoryInfo.Series["Speed"].ChartType = 
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chtMemoryInfo.Series["Capacity"].ChartType = 
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chtMemoryInfo.Series["Speed"]["PointWidth"] = "0.5";
                chtMemoryInfo.Series["Speed"].IsValueShownAsLabel = true;
                chtMemoryInfo.Series["Speed"]["BarLabelStyle"] = "Center";
                chtMemoryInfo.Series["Speed"]["DrawingStyle"] = "Cylinder";

                chtMemoryInfo.Series["Capacity"]["PointWidth"] = "0.5";
                chtMemoryInfo.Series["Capacity"].IsValueShownAsLabel = true;
                chtMemoryInfo.Series["Capacity"]["BarLabelStyle"] = "Center";
                chtMemoryInfo.Series["Capacity"]["DrawingStyle"] = "Cylinder";

                chtMemoryInfo.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                chtMemoryInfo.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = true;
                chtMemoryInfo.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;
                chtMemoryInfo.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 30;
                chtMemoryInfo.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = 
                    System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
                chtMemoryInfo.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 0;
                chtMemoryInfo.ChartAreas["ChartArea1"].Area3DStyle.PointDepth = 100;
                chtMemoryInfo.ChartAreas["ChartArea1"].Area3DStyle.PointGapDepth = 100;
                chtMemoryInfo.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 5;
                

                double dblTotalMemoryMb = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    //Capacity is stored in bytes
                    dblTotalMemoryMb += Convert.ToDouble(dr["Capacity"].ToString());

                    System.Windows.Forms.DataVisualization.Charting.DataPoint dp =
                        new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                    
                    //Add speed points
                    chtMemoryInfo.Series["Speed"].Points.AddY(Convert.ToDouble(dr["Speed"].ToString()));

                    //Convert capacity from bytes to megabytes and add as a point
                    chtMemoryInfo.Series["Capacity"].Points.AddY(Convert.ToDouble(dr["Capacity"].ToString()) / Math.Pow(1024, 2));
                    
                }

                //Bytes are converted to megabytes
                dblTotalMemoryMb = dblTotalMemoryMb / Math.Pow(1024, 2);

                chtMemoryInfo.ChartAreas["ChartArea1"].AxisX.IsStartedFromZero = false;
            }
            else
            {
                chtMemoryInfo.Visible = false;
                
                
                StringBuilder sb = new StringBuilder();
                sb.Append(Strings.kPhysicalMemoryCouldNotBeDetected);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                //_err.ShowError(new ApplicationException
                //    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                throw new ApplicationException(sb.ToString());
            }

        }

        private void GetProductInformation()
        {
            try
            {
                WmiRequester.Win32_Product wmiProd = new WmiRequester.Win32_Product();
                System.Data.DataTable dt = new System.Data.DataTable("Win32_Product");
                dt = wmiProd.GetWin32Product(_logIn.WindowsMachineName, _logIn.WindowsUser, _logIn.WindowsPwd);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                _err.ShowError(new ApplicationException
                    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GetWin32_PerfFormattedData_PerfOS_Memory()
        {
            WmiRequester.Win32_PerfFormattedData_PerfOS_Memory mem = 
                new WmiRequester.Win32_PerfFormattedData_PerfOS_Memory();
            System.Data.DataTable dt = new System.Data.DataTable("Win32_PerfFormattedData_PerfOS_Memory");
            dt = mem.GetWin32_PerfFormattedData_PerfOS_Memory(_logIn.WindowsMachineName, _logIn.WindowsUser, _logIn.WindowsPwd);

        }

        #endregion
        private void ShowData()
        {
            // dgvResults should show only queries designation for output, 
            // and queries set to execute, while the chkCodeToRun
            // should continue to show all available queries. This allows
            // you to continue to check or uncheck existing queries 
            // and execute again
            DataView dvResults = new DataView(dsChecklist1.dtChecklist);
            dvResults.RowFilter = "IsForOutput = 1 AND IsExecute = 1 AND IsForDataSet = 0";
            dgvResults.DataSource = dvResults;

            _grd.HideResultsDataGridViewColumns(dgvResults);

            //Set Progress bar back to zero
            pbarCheckProgress.Value = 0;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void SetChkControlCheckedProperty(ToolStripMenuItem tsm, Strings.enumCategory Category)
        {
            if (tsm.Name == allToolStripMenuItem.Name)
            {
                for (int i = 0; i < chkCodeToRun.Items.Count; i++)
                {
                    chkCodeToRun.SetItemChecked(i, tsm.Checked);
                }

                return;
            }

            //foreach (dsChecklist.dtCodeToRunRow dr in dsChecklist1.dtCodeToRun.Rows)
            foreach (dsChecklist.dtChecklistRow dr in dsChecklist1.dtChecklist.Rows)
            {
                if (dr.Category == Category.ToString())
                {
                    chkCodeToRun.SetItemChecked(chkCodeToRun.FindStringExact(dr.ScriptName), tsm.Checked);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {


            try
            {
                CheckIfLicensed();
                System.Windows.Forms.Application.EnableVisualStyles();

                _chk.ProgressBarIncrease +=
                    new Checklist.ProgressBarValueIncreaseHandler(ProgressBarIncreaseSubscriber);

                //DebugCode();
                BindForm(true);

            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                _err.ShowError(new ApplicationException
                    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ShowLoginStatus(Boolean isLoggedIn)
        {

            switch (isLoggedIn)
            {

                case true:

                    toolStripStatusLabel1.Text = "Login Status: " + _logIn.myConnection.DataSource;
                    tspLoginStatusImage.Image = Properties.Resources._112_Tick_Blue;
                    SetAbleToExecuteAgainstDatabaseVisualIndicators(true);
                    break;

                case false:
                    SetAbleToExecuteAgainstDatabaseVisualIndicators(false);
                    //ClearDatabaseComboBox();
                    //ClearDatabasePieChart();
                    //ClearDiskStackedColumn100Chart();
                    //ClearMemoryPieChart();
                    break;
            }

        }

        public void ProgressBarIncreaseSubscriber(object sender,
            ProgressBarIncreaseEventArgs ProgressBarIncreaseValue)
        {
            dsChecklist.dtRunLogRow dr = dsChecklist1.dtRunLog.NewdtRunLogRow();
            pbarCheckProgress.Value = ProgressBarIncreaseValue.ProgressBarValue;

            dr.ErrorValue = ProgressBarIncreaseValue.ErrorNum;
            dr.ErrorDesc = ProgressBarIncreaseValue.ErrorDesc;
            dr.ExecutionStart = ProgressBarIncreaseValue.ExecutionStart;
            dr.LoginName = ProgressBarIncreaseValue.LoginName;
            dr.ScriptName = ProgressBarIncreaseValue.ScriptName;

            //Set percent complete
            int percent = pbarCheckProgress.Value;
            using (Graphics gr = pbarCheckProgress.CreateGraphics())
            {

                //Switch to Antialiased drawing for better (smoother) graphic results
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gr.DrawString(percent.ToString() + "% " + dr.ScriptName,
                    SystemFonts.DefaultFont,
                    Brushes.White,
                    new PointF(pbarCheckProgress.Width / 2 - (gr.MeasureString(percent.ToString() + "%" + dr.ScriptName,
                        SystemFonts.DefaultFont).Width / 2.0F),
                    pbarCheckProgress.Height / 2 - (gr.MeasureString(percent.ToString() + "%" + dr.ScriptName,
                        SystemFonts.DefaultFont).Height / 2.0F)));
            }
            System.Windows.Forms.Application.DoEvents();
            //Add to the run log
            dsChecklist1.dtRunLog.Rows.Add(dr);
        }

        private void SetDatasetIsExecuteProperty(dsChecklist ds)
        {

            //Set the dataset row to checked for all items 
            //checked in the chkCodeToRun control
            for (int i = 0; i < chkCodeToRun.Items.Count; i++)
            {
                int intCheckListKey = Convert.ToInt32((((System.Data.DataRowView)(chkCodeToRun.Items[i])).Row).ItemArray[0]);

                switch (chkCodeToRun.GetItemCheckState(i))
                {
                    case CheckState.Checked:
                        dsChecklist1.dtChecklist.FindByChecklistKey(intCheckListKey).IsExecute = true;
                        break;

                    default:
                        //Everything else is set to false
                        dsChecklist1.dtChecklist.FindByChecklistKey(intCheckListKey).IsExecute = false;
                        break;
                }
            }

            //Set the dataset row IsExecute to checked 
            //for all items in the chkListDataSets control
            for (int intDataSetCtr = 0; intDataSetCtr < chkListDataSets.Items.Count; intDataSetCtr++)
            {
                int intCheckListKey =
                    Convert.ToInt32((((System.Data.DataRowView)(chkListDataSets.Items[intDataSetCtr])).Row.ItemArray[0]));

                switch (chkListDataSets.GetItemCheckState(intDataSetCtr))
                {
                    case CheckState.Checked:
                        dsChecklist1.dtChecklist.FindByChecklistKey(intCheckListKey).IsExecute = true;
                        break;


                    default:
                        //Everything else is set to false
                        dsChecklist1.dtChecklist.FindByChecklistKey(intCheckListKey).IsExecute = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Once the datasets have been retrieved, this method will bind 
        /// those to the results tab, specifically the combo box
        /// </summary>
        private void LoadCboDataTables()
        {
            //Load cboDatatablesForResults
            cboDatatablesForResults.Items.Clear();
            foreach (System.Data.DataTable myDtResults in dsChecklist1.Tables)
            {
                if (_schemaUtils.IsSystemTable(myDtResults.TableName) == false)
                {
                    //This is NOT a system table, add it to the output 
                    cboDatatablesForResults.Items.Add(myDtResults.TableName);
                }
            }

            if (cboDatatablesForResults.Items.Contains("dtChecklist") == false)
            {
                if (_schemaUtils.IsDatasetPopulatedWithNonSystemTables(dsChecklist1) == true)
                {
                    cboDatatablesForResults.Items.Add("dtCheckList");
                }
            }
        }

        #region "Bind Form And Populate Combo Boxes"
        private void BindForm(Boolean HandleCheckedListControlState)
        {
            //Load the query timeout into the menu
            toolStripTxtTimeout.Text = Properties.Settings.Default.QueryTimeout.ToString();

            MakeBasicChecksReferenceReadonlyDataTable();
            MakeDatasetsToGatherReferenceReadonlyDatatable();

            //dsChecklist1.Clear();
            if (dsChecklist1.dtChecklist.Rows.Count == 0)
            {
                dsChecklist1.dtChecklist.ReadXml(_fmgr.GetFile("dtCheckList.xml").FullName);
            }
            PopulateCboLogType();
            if (dsChecklist1.dtEventLogItemsToCheck.Rows.Count == 0)
            {
                PopulateEventsToCheck();
            }
            PopulateSystemChecksCodeToRun(HandleCheckedListControlState);
            PopulatechkListDataSetsToRun(HandleCheckedListControlState);
            PopulateWmiQueriesToRun(true);
            LoadCboDataTables();
            _grd.ApplyGridStyle(dgvResults);

        }

        private void PopulateWmiQueriesToRun(bool HandleCheckedListControlState)
        {
            if (chkWmiQueriesToRun.Items.Count < 1)
            {
                //Add WMI checks to chkWmiQueries
                chkWmiQueriesToRun.Items.Add(WmiRequester.WmiRequesterTypes.Win32_OperatingSystem.ToString(), true);
                chkWmiQueriesToRun.Items.Add(WmiRequester.WmiRequesterTypes.Win32_Product.ToString(), true);
                chkWmiQueriesToRun.Items.Add(WmiRequester.WmiRequesterTypes.Win32_LogicalDisk.ToString(), true);
                chkWmiQueriesToRun.Items.Add(WmiRequester.WmiRequesterTypes.Win32_NetworkAdapterConfiguration.ToString(), true);
                chkWmiQueriesToRun.Items.Add(WmiRequester.WmiRequesterTypes.Win32_PhysicalMemory.ToString(), true);
                chkWmiQueriesToRun.Items.Add(WmiRequester.WmiRequesterTypes.Win32_DefragAnalysis.ToString(), true);
                chkWmiQueriesToRun.Items.Add(WmiRequester.WmiRequesterTypes.Win32_PerfFormattedData_PerfOS_Memory.ToString(), true);
            }
            
        }
        private void MakeBasicChecksReferenceReadonlyDataTable()
        {
            if (this.BasicChecksDataset == null)
            {
                dsChecklist.dtChecklistDataTable dtBasicChecksToRunForComboBoxBinding = new dsChecklist.dtChecklistDataTable();
                dsChecklist ds = new dsChecklist();
                ds.Tables.Add(new dsChecklist.dtChecklistDataTable());
                ds.Tables[0].ReadXml(_fmgr.GetFile("dtCheckList.xml").FullName);

                this.BasicChecksDataset = (dsChecklist.dtChecklistDataTable)ds.Tables[0];
                ds.Dispose();
            }
        }

        private void MakeDatasetsToGatherReferenceReadonlyDatatable()
        {
            if (this.DatasetsToGather == null)
            {
                dsChecklist.dtChecklistDataTable dtDatasetsToGatherForComboBoxBinding = new dsChecklist.dtChecklistDataTable();
                dsChecklist ds = new dsChecklist();
                ds.Tables.Add(new dsChecklist.dtChecklistDataTable());
                ds.Tables[0].ReadXml(_fmgr.GetFile("dtChecklist.xml").FullName);

                this.DatasetsToGather = (dsChecklist.dtChecklistDataTable)ds.Tables[0];
                ds.Dispose();
            }
        }

        private void PopulateSystemChecksCodeToRun(bool HandleCodeToRunCheckedState)
        {
            
            DataView dvCodeToRun = new DataView(this.BasicChecksDataset);
            dvCodeToRun.RowFilter = "IsForOutput = 1 AND IsExecute = 1 AND IsForDataSet = 0";
            
            chkCodeToRun.DataSource = dvCodeToRun;
            chkCodeToRun.DisplayMember = "ScriptName";

            if (HandleCodeToRunCheckedState == true)
            {
                for (int i = 0; i < chkCodeToRun.Items.Count; i++)
                {

                    //Read dtChecklist.xml's IsExecute field 
                    //Set chkCodeToRun default
                    if (Convert.ToBoolean(
                        ((System.Data.DataRowView)(chkCodeToRun.Items[i])).Row.ItemArray[15])
                        == true)
                    {
                        chkCodeToRun.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }

        }

        private void PopulatechkListDataSetsToRun(bool HandleChkListDatasetCheckedState)
        {
            DataView dvSetsOfData = new DataView(this.DatasetsToGather);
            dvSetsOfData.RowFilter = "IsForOutput = 1 AND IsForDataSet = 1";


            chkListDataSets.DataSource = dvSetsOfData;
            chkListDataSets.DisplayMember = "ScriptName";

            if (HandleChkListDatasetCheckedState == true)
            {
                for (int i = 0; i < chkListDataSets.Items.Count; i++)
                {
                    if (Convert.ToBoolean(
                        (((System.Data.DataRowView)(chkListDataSets.Items[i])).Row).ItemArray[15]) // 15 = IsExecute
                        == true)
                    {
                        chkListDataSets.SetItemCheckState(i, CheckState.Checked);
                    }

                }
            }

        }

        private void PopulateCboLogType()
        {
            cboLogType.Items.Clear();
            cboLogType.Items.Add(EventLogChecker.enumLogType.Application.ToString());
            cboLogType.Items.Add(EventLogChecker.enumLogType.System.ToString());
            cboLogType.SelectedIndex = 0;
        }

        private void PopulateEventsToCheck()
        {
            dgvEventLogItemsToCheck.DataSource = null;
            _evt.SetEventLogsToCheck(dsChecklist1);
            DataView dv = new DataView(dsChecklist1.dtEventLogItemsToCheck, null, "LogType ASC, InstanceID ASC", DataViewRowState.CurrentRows);
            dgvEventLogItemsToCheck.DataSource = dv;
        }
        #endregion
        private void DebugCode()
        {
            dsChecklist.dtChecklistRow dr = dsChecklist1.dtChecklist.NewdtChecklistRow();

            //dr.ChecklistKey = 1;
            dr.ScriptName = "Am I SQL Admin";
            dr.CheckDesc = "Check to see if the connection is SQL Server Administrator (sa or equivalent). If it is not, this checklist will end early.";
            dr.LowValue = 1;
            dr.HighValue = 10;
            //dr.IsWithinRange = true;
            dr.IsWithinRangeGood = true;
            //dr.YourValue = "1";
            dr.ChecklistCrossRefID = 15;
            dr.Category = Strings.enumCategory.Configuration.ToString();
            dr.AdditionalDocumentation = @"http://www.google.com";
            dr.Weight = 1;
            dr.CodeToRun = @"SELECT 
	                        @@SPID, 
	                        SYSTEM_USER, 
	                        USER, 
	                        NULL,		-- LogStart
	                        GETDATE(),	--LogEnd
	                        IS_SRVROLEMEMBER('sysadmin')
                        ";
            dr.CodeType = Strings.enumCodeType.SQL.ToString();
            dr.IsExecute = false;
            dsChecklist1.dtChecklist.Rows.Add(dr);
            dsChecklist1.dtChecklist.WriteXml(@"c:\dtCheckList.xml", true);

        }

        private void cboDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnn = new SqlConnection();
                cnn = _logIn.myConnection;

                if (cnn != null)
                {
                    if (cnn.ConnectionString != string.Empty)
                    {
                        SqlConnectionStringBuilder sqlCnn =
                            new SqlConnectionStringBuilder(cnn.ConnectionString);
                        sqlCnn.InitialCatalog = (((System.Data.DataRowView)(cboDatabases.SelectedItem)).Row.ItemArray[0].ToString());

                        _logIn.myConnection = new SqlConnection(sqlCnn.ToString());
                    }
                }

                //Set database info
                if (cboDatabases.DataSource != null)
                    if (cboDatabases.Items.Count > 0)
                    {
                        {
                            if (!string.IsNullOrEmpty(((System.Data.DataRowView)(cboDatabases.SelectedItem)).Row.ItemArray[0].ToString()))
                            {
                                SetDatabaseChartInfo(((System.Data.DataRowView)(cboDatabases.SelectedItem)).Row.ItemArray[0].ToString());
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDatatablesForResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvResults.DataSource = dsChecklist1.Tables[cboDatatablesForResults.Text];
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string strFileName = "";

                ExcelMgr xlMgr = new ExcelMgr();
                strFileName = xlMgr.ExportToExcel(dsChecklist1);

                ttExcelExport.UseAnimation = true;
                ttExcelExport.UseFading = true;
                ttExcelExport.AutoPopDelay = 5000;
                ttExcelExport.ReshowDelay = 500;
                ttExcelExport.ToolTipIcon = ToolTipIcon.Info;
                ttExcelExport.ToolTipTitle = "File Exported to Excel";
                ttExcelExport.IsBalloon = true;
                ttExcelExport.SetToolTip(btnExportToExcel, "File: '" + strFileName + "' generated");
                ttExcelExport.Show("File: '" + strFileName + "' generated", this, 5000);
                ttExcelExport.Tag = strFileName;


            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                _err.ShowError(new ApplicationException
                    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEventCheck_Click(object sender, EventArgs e)
        {
            
            //Sanity check: Don't add blank records to check
            if (string.IsNullOrEmpty(txtEventItemToCheck.Text) == true)
            {
                return;
            }

            Strings.Utilies strUtils = new Strings.Utilies();
            try
            {

                if (cboLogType.Text == "Application")
                {
                    AddEventLogChecks(EventLogChecker.enumLogType.Application, txtEventItemToCheck.Text);
                    txtEventItemToCheck.Text = "";
                    return;
                }

                if (cboLogType.Text == "System")
                {
                    AddEventLogChecks(EventLogChecker.enumLogType.System, txtEventItemToCheck.Text);
                    txtEventItemToCheck.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                _err.ShowError(new ApplicationException
                    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        /// <summary>
        /// Adds event log checks to the data grid. The grid should be prepopulated from 
        /// the dtEventLogItemsToCheck.xml file. 
        /// </summary>
        /// <param name="LogType">Application, System, etc...</param>
        /// <param name="strInstanceIDOrDescription">Supports integer only at the moment</param>
        private void AddEventLogChecks(EventLogChecker.enumLogType LogType, string strInstanceIDOrDescription)
        {

            //Does this already exist?
            //If so, cancel and return. Do not insert a duplicate
            DataView dvChecks = new DataView(dsChecklist1.dtEventLogItemsToCheck);
            dvChecks.RowFilter = "LogType = '" + LogType + "' AND InstanceID = '" + strInstanceIDOrDescription + "'";

            if (dvChecks.Count > 0)
            {
                //This row has already been added. Do not add it again
                return;
            }

            Strings.Utilies strUtils = new Strings.Utilies();
            DataRow dr = dsChecklist1.dtEventLogItemsToCheck.NewRow();
            dr["LogType"] = LogType.ToString();

           
             dr["InstanceID"] = Convert.ToInt32(strInstanceIDOrDescription);
            dsChecklist1.dtEventLogItemsToCheck.Rows.Add(dr);
        }

        private void btnEventLogCheck_Click(object sender, EventArgs e)
        {
            RunEventLogChecks();
            ShowData();
            LoadCboDataTables();
            _grd.ApplyGridStyle(dgvResults);
            _grd.ApplyGridStyle(dgvRunLog);

        }

        private void RunWmiDataSets()
        {
            WmiToGather wmi = new WmiToGather();
            
            foreach (object item in chkWmiQueriesToRun.CheckedItems)
            {
                System.Data.DataTable dt;
                try
                {
                    Int32 intCodeExecutedCounter = 1;
                    Int32 intProgressBarValue = 0;
                    double dblMultiplier = 0;
                    dblMultiplier = 100 / _chk.TotalItemsToExecute; ;
                    intProgressBarValue = Convert.ToInt32(intCodeExecutedCounter * dblMultiplier);
                    
                    _chk.OnProgressBarIncrease(this,
                           new ProgressBarIncreaseEventArgs(
                               intProgressBarValue,
                               item.ToString(),
                               DataAccessLayer.LoginName,
                               DateTime.Now,
                               0,
                               "---"));
                    System.Windows.Forms.Application.DoEvents();

                    dt = wmi.GetWmiResults(item.ToString(), _logIn.WindowsMachineName, _logIn.WindowsUser, _logIn.WindowsPwd);
                    dt.TableName = item.ToString();
                    //Remove the table if it exists already
                    if (dsChecklist1.Tables.Contains(item.ToString()))
                    {
                        dsChecklist1.Tables.Remove(item.ToString());
                    }

                    //Add the table to the output
                    dsChecklist1.Tables.Add(dt);
                }
                catch (System.Management.ManagementException ex)
                {
                    StackTrace myStackTrace = new StackTrace();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(ex.Message);
                    sb.Append(Environment.NewLine);
                    sb.Append("Error Information: " + item.ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("WMI Query: " + item.ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);
                    
                    _err.ShowError(
                        new ApplicationException
                        (
                            sb.ToString(),
                            ex.InnerException
                        ),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    continue;
                }
                catch (System.Security.SecurityException ex)
                {
                    StackTrace myStackTrace = new StackTrace();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(ex.Message);
                    sb.Append(Environment.NewLine);
                    sb.Append("" + ex.Method);
                    sb.Append(Environment.NewLine);
                    sb.Append("RefusedSet: " + ex.RefusedSet);
                    sb.Append(Environment.NewLine);
                    sb.Append("PermissionType: " + ex.PermissionType);
                    sb.Append(Environment.NewLine);
                    sb.Append("Action: " + ex.Action);
                    sb.Append(Environment.NewLine);
                    sb.Append("First Permission That Failed: " + ex.FirstPermissionThatFailed);
                    sb.Append(Environment.NewLine);
                    sb.Append("WMI Query: " + item.ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                    _err.ShowError(
                        new ApplicationException
                        (
                            sb.ToString(),
                            ex.InnerException
                        ),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    
                    continue;
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    StackTrace myStackTrace = new StackTrace();
                                        
                    StringBuilder sb = new StringBuilder();
                    sb.Append(ex.Message);
                    sb.Append(Environment.NewLine);
                    sb.Append("WMI Query: " + item.ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);
                    
                    _err.ShowError(
                        new ApplicationException
                        (
                            sb.ToString(), 
                            ex.InnerException
                        ),
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    continue;
                }
                catch (Exception ex)
                {
                    StackTrace myStackTrace = new StackTrace();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(ex.Message);
                    sb.Append(Environment.NewLine);
                    sb.Append("WMI Query: " + item.ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                    _err.ShowError(
                        new ApplicationException
                        (
                            sb.ToString(), 
                            ex.InnerException
                        ),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    continue;
                }
            }
        }

        private void RunEventLogChecks()
        {
            Int32 intCodeExecutedCounter = 0;
            Int32 intProgressBarValue = 0;
            double dblMultiplier = 0;
            dblMultiplier = 100 / _chk.TotalItemsToExecute;
            try
            {
                dsChecklist.dtEventLogDataTable dt = new dsChecklist.dtEventLogDataTable();
                dt.TableName = "Event Log Checks";

                intCodeExecutedCounter += 1;
                intProgressBarValue = Convert.ToInt32(intCodeExecutedCounter * dblMultiplier);

                SqlConnection cnn = _logIn.myConnection;
                if (cnn != null)
                {
                    //Decompose the connection and retrieve necessary parts
                    string ServerName = _logIn.WindowsMachineName;
                    string UserName = _logIn.WindowsUser;
                    string DomainName = _logIn.WindowsDomain;
                    string Password = _logIn.WindowsPwd;
                    _chk.OnProgressBarIncrease(this, 
                        new ProgressBarIncreaseEventArgs(
                            75, //TODO: Need to calculate the value instead
                            "Event Log Checks", 
                            _logIn.WindowsUser, 
                            DateTime.Now, 
                            0, 
                            "---"));
                    
                    if (dsChecklist1.Tables.Contains(dt.TableName))
                    {
                        dsChecklist1.Tables.Remove(dt.TableName);
                    }

                    dt = _evt.ReadEventLog(DomainName, UserName, ServerName, Password, dsChecklist1.dtEventLogItemsToCheck, dt);
                    dsChecklist1.Tables.Add(dt);
                }

                
            }
            catch (Exception ex)
            {
                //_err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                throw new ApplicationException
                    (sb.ToString());
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            dsChecklist1.dtEventLogItemsToCheck.Rows.Clear();
        }

        /// <summary>
        /// The event log checks only accept numbers as instanceID values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEventItemToCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            { e.Handled = true; }
        }

        private void chkRunEventLogChecks_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox frmAbt = new frmAboutBox();
            frmAbt.ShowDialog();
        }



        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Save the existing dataset to a file somewhere
            try
            {
                if (_schemaUtils.IsDatasetPopulatedWithNonSystemTables(dsChecklist1) == true)
                {
                    DialogResult dlgResult = new System.Windows.Forms.DialogResult();
                    SaveFileDialog saveDlg = 
                        _fmgr.SaveFile(
                            _fmgr.StripIllegalCharactersFromFileName(_logIn.SqlServerName), 
                            true, 
                            "XML Files|*.xml", 
                            "xml", 
                            false, 
                            true, 
                            true, 
                            true);
                    dlgResult = saveDlg.ShowDialog();
                    if (dlgResult == System.Windows.Forms.DialogResult.OK)
                    {
                        dsChecklist1.WriteXml(saveDlg.FileName, XmlWriteMode.WriteSchema);
                    }
                }
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
        /// <summary>
        /// Only numbers are allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTxtTimeout_KeyPress(object sender, KeyPressEventArgs e)
        {
 
            //Must be a digit
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                //Allow backspaces
                if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\b"))
                {
                    //Don't allow the text value to go null
                    if (toolStripTxtTimeout.Text.Length == 1)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        //Allow backspaces
                    }

                }
                else
                {
                    //Cancel the key press
                    e.Handled = true; 
                }
            }


            //Do not allow timeout value of zero
            if (toolStripTxtTimeout.Text.Length == 1)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "0"))
                {
                    e.Handled = true;
                }
            }
            
        }

        private void toolStripTxtTimeout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.QueryTimeout = Convert.ToInt32(toolStripTxtTimeout.Text);
                Properties.Settings.Default.Save();

                if (_logIn.myConnection != null)
                {
                    SqlConnectionStringBuilder cnnSb = new SqlConnectionStringBuilder(_logIn.myConnection.ConnectionString);
                    cnnSb.ConnectTimeout = Properties.Settings.Default.QueryTimeout;
                    if (cnnSb.IntegratedSecurity == true)
                    {
                        _logIn.SetConnection(frmLogin.kWinAuth, cnnSb.UserID, cnnSb.WorkstationID, cnnSb.Password, null);
                    }
                    else if (cnnSb.IntegratedSecurity == false)
                    {
                        _logIn.SetConnection(frmLogin.kSqlAuth, cnnSb.UserID, cnnSb.WorkstationID, cnnSb.Password, null);
                    }   
                }
                
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);

                StackTrace myStackTrace = new StackTrace();
                sb.Append("Calling Method: " + myStackTrace.GetFrame(1).GetMethod().Name);

                _err.ShowError(new ApplicationException
                    (sb.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Retrieves disk information after the user has logged in already. Only run this code after the user has logged in. 
        /// </summary>
        /// <returns></returns>
        private System.Data.DataTable GetLogicalDiskInfo()
        {
            if (_logIn.myConnection == null)
            {
                throw new ApplicationException(Strings.NotLoggedIn);
            }
            WmiRequester.Win32_LogicalDisk disk = new WmiRequester.Win32_LogicalDisk();
            System.Data.DataTable dtDisk = new System.Data.DataTable();
            
            try
            {
                dtDisk = disk.GetDiskInformation(_logIn.WindowsMachineName, _logIn.WindowsUser, _logIn.WindowsPwd);
            }
            catch (Exception ex)
            {
                //_err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }

            return dtDisk;
        }


        private void button2_Click(object sender, EventArgs e)
        {
        
            WmiRequester.Win32_OperatingSystem _wmiOs = new WmiRequester.Win32_OperatingSystem();
            System.Data.DataTable dt = new System.Data.DataTable("Win32_OperatingSystem");
            //dt = _wmiOs.GetOperatingSystemInfo("bob-pc", "bob", "x3@dmin");
            dt = _wmiOs.GetOperatingSystemInfo("", "", "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                WmiRequester.Win32_NetworkAdapterConfiguration wmiNetwork = new WmiRequester.Win32_NetworkAdapterConfiguration();
                System.Data.DataTable dt = new System.Data.DataTable("Win32_NetworkAdapterConfiguration");
                dt = wmiNetwork.GetWin32_NetworkAdapterConfiguration("bob-pc", "bob", "x3@dmin");
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                WmiRequester.Win32_PhysicalMemory wmiMem = new WmiRequester.Win32_PhysicalMemory();
                System.Data.DataTable dt = new System.Data.DataTable("Win32_PhysicalMemory");
                dt = wmiMem.GetWin32_PhysicalMemory("bob-pc", "bob", "x3@dmin");
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                WmiRequester.Win32_DefragAnalysis wmiDefrag = new WmiRequester.Win32_DefragAnalysis();
                System.Data.DataTable dt = new System.Data.DataTable("Win32_DefragAnalysis");
                //dt = wmiDefrag.GetWin32_DefragAnalysis("bob-pc", "bob", "x3@dmin");
                dt = wmiDefrag.GetWin32_DefragAnalysis("", "", "");
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            easterEgg.Push(e.KeyChar);
            
        }

        private void loadDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {

            LoadDataFromFileSource();
        }

        private void LoadDataFromFileSource()
        {
            DialogResult dlgResult = new DialogResult();
            OpenFileDialog ofd = _fmgr.OpenFile(string.Empty, "XML Files|*xml", "xml", true, true, true, true);

            try
            {
                dlgResult = ofd.ShowDialog();
                if (dlgResult == System.Windows.Forms.DialogResult.OK)
                {
                    dsChecklist1.Tables.Clear();
                    
                    dsChecklist1.ReadXml(ofd.FileName, XmlReadMode.ReadSchema);
                    ShowData();
                    BindForm(true);
                }
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LoadDtChecklistTable(System.Data.DataTable dt)
        {

        }

        private void chkCodeToRun_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                chkCodeToRun.SelectedIndex = chkCodeToRun.IndexFromPoint(e.Location);
                if (chkCodeToRun.SelectedIndex != -1)
                {
                    ctxCodeToRun.Show();
                }
            }

            //Set the selected row to the query shown in the richtextbox window
            //int indexFromPoint = chkCodeToRun.IndexFromPoint(e.Location);
            int intCheckListKey = Convert.ToInt32((((System.Data.DataRowView)(chkCodeToRun.SelectedItem)).Row).ItemArray[0]);

            if (intCheckListKey >= 0)
            {
                dsChecklist.dtChecklistRow dr = dsChecklist1.dtChecklist.NewdtChecklistRow();
                dr = dsChecklist1.dtChecklist.FindByChecklistKey(intCheckListKey);
                rtxQuery.Text = dr.CodeToRun.ToString();
            }
        }

        private void chkListDataSets_MouseDown(object sender, MouseEventArgs e)
        {
            int intCheckListKey = Convert.ToInt32((((System.Data.DataRowView)(chkListDataSets.SelectedItem)).Row).ItemArray[0]);
            if (intCheckListKey >= 0)
            {
                dsChecklist.dtChecklistRow dr = dsChecklist1.dtChecklist.NewdtChecklistRow();
                dr = dsChecklist1.dtChecklist.FindByChecklistKey(intCheckListKey);
                rtxQuery.Text = dr.CodeToRun.ToString();
            }
        }

     }
}
