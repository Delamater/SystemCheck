using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SystemCheck
{
    public class Checklist
    {
        /// <summary>
        /// For every row within the dtCheckList.xml file read the code type
        /// and execute the code
        /// </summary>
        /// <param name="ds"></param>
        /// <returns>A dataset that can be bound to a datagridview. 
        /// The dataset will ultimately be reported on.
        /// 
        /// SR represeents a streamreader, the code to run. It must return two fields. 
        /// The first field is a type of double. The second field is a type of string. 
        /// </returns>
        /// 

        private string _strSQLExecuting = "";
        private int _intTotalItemsToExecute = 0;
        public Int32 TotalItemsToExecute
        {
            get { return _intTotalItemsToExecute; }
            set { _intTotalItemsToExecute = value; }
        }

        //Delegate is what the other classes see to understand the required signature of the void
        public delegate void ProgressBarValueIncreaseHandler(object sender, ProgressBarIncreaseEventArgs data);

        //ProgressBarValueIncreaseHandler delegate now gets an event called ProgressBarIncrease, 
        //which other classes can wire up in their code
        public event ProgressBarValueIncreaseHandler ProgressBarIncrease;


        /// <summary>
        /// This method is here to fire off the event so that anyone subscribing 
        /// to the event can know to handle the fact that the progress 
        /// bar should be increasing in value.
        /// 
        /// This void will announce the event to anyone listening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public void OnProgressBarIncrease(object sender, ProgressBarIncreaseEventArgs data)
        {
            if (ProgressBarIncrease != null)
            {
                ProgressBarIncrease(this, data);
            }

            //Notify this class what code is executing for 
            //error handling as well
            _strSQLExecuting = data.ScriptName;
        }

        public dsChecklist GetCheckListDataset(dsChecklist ds)
        {
            try
            {
                Int32 intCodeExecutedCounter = 0;
                double dblMultiplier = 0;
                //dblMultiplier = 100 / ds.dtChecklist.Select("IsExecute = True AND IsForDataSet = False").Count();
                //dblMultiplier = 100 / ds.dtChecklist.Select("IsExecute = True").Count();
                dblMultiplier = 100 / this.TotalItemsToExecute;

                foreach (dsChecklist.dtChecklistRow dr in ds.dtChecklist.Select("IsExecute = True AND IsForDataSet = False"))
                {
                    intCodeExecutedCounter += 1;
                    SqlDataReader sr;
                    Int32 intProgressBarValue = 0;
                    intProgressBarValue = Convert.ToInt32(intCodeExecutedCounter * dblMultiplier);

                    OnProgressBarIncrease(this,
                        new ProgressBarIncreaseEventArgs(
                            intProgressBarValue,
                            dr.ScriptName,
                            DataAccessLayer.LoginName,
                            DateTime.Now,
                            0,
                            "---"));

                    sr = DataAccessLayer.ExecuteQuery(dr.CodeToRun, CommandType.Text, dr.MinTsqlCompatibilityVersion);
                    sr.Read();

                    if (dr.IsForOutput == true)
                    {

                        // Code Type == SQL
                        if (dr.CodeType == Strings.enumCodeType.SQL.ToString())
                        {
                            
                            dr.YourValue = Convert.ToDecimal(sr[0]);
                            dr.Detail = (sr[1].ToString() ?? "");
                            if ((dr.YourValue >= dr.LowValue) && (dr.YourValue <= dr.HighValue))
                            {
                                dr.IsWithinRange = true;
                            }
                            else
                            {
                                dr.IsWithinRange = false;
                            }

                            continue;

                        }

                        // Code Type == Powershell
                        if (dr.CodeType == Strings.enumCodeType.Powershell.ToString())
                        {
                            throw new NotImplementedException();
                            //continue;
                        }

                        //Code Type == VbScript
                        if (dr.CodeType == Strings.enumCodeType.VbScript.ToString())
                        {
                            throw new NotImplementedException();
                            //continue;
                        }

                        //Update the value
                        //dr.YourValue = Convert.ToDouble(dr.YourValue);   
                        dr.YourValue = Convert.ToDecimal(dr.YourValue);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(ex.Message
                    + Environment.NewLine
                    + Environment.NewLine
                    + "Script: '" + _strSQLExecuting + "'"
                    + Environment.NewLine, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message
                    + Environment.NewLine
                    + Environment.NewLine
                    + "Script: '" + _strSQLExecuting + "'"
                    + Environment.NewLine, ex.InnerException);

            }

            //Clear current script executing
            _strSQLExecuting = "";
            return ds;
        }
        public dsChecklist GetDataTableResults(dsChecklist ds)
        {
            Int32 intCodeExecutedCounter = 0;
            dsChecklist dsResults = ds;
            try
            {
                foreach (dsChecklist.dtChecklistRow dr in ds.dtChecklist.Select("IsExecute = True AND IsForDataSet = True"))
                {
                    DataTable dt = new DataTable();
                    intCodeExecutedCounter += 1;
                    double dblMultiplier = 0;

                    Int32 intProgressBarValue = 0;
                    //dblMultiplier = 100 / ds.dtChecklist.Select("IsExecute = True").Count();
                    dblMultiplier = 100 / this.TotalItemsToExecute;

                    intProgressBarValue = Convert.ToInt32(intCodeExecutedCounter * dblMultiplier);

                        OnProgressBarIncrease(this,
                            new ProgressBarIncreaseEventArgs(
                                intProgressBarValue,
                                dr.ScriptName,
                                DataAccessLayer.LoginName,
                                DateTime.Now,
                                0,
                                "---"));

                    //There is a chance that this table may already exist in the dataset
                    //If so, remove it
                    if (dsResults.Tables.Contains(dr.ScriptName) == true)
                    {
                        dsResults.Tables.Remove(dr.ScriptName);
                    }
                    dt = DataAccessLayer.GetDataTable(dr.CodeToRun, CommandType.Text, dr.ScriptName, dr.MinTsqlCompatibilityVersion);
                    dsResults.Tables.Add(dt);

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message
                    + Environment.NewLine
                    + Environment.NewLine
                    + "Script: '" + _strSQLExecuting + "'"
                    + Environment.NewLine, ex.InnerException);
            }
            return ds;
        }

        class RunLog
        {
        }
    }

    public class ProgressBarIncreaseEventArgs : EventArgs
    {

        public Int32 ProgressBarValue { get; internal set; }
        public string ScriptName { get; internal set; }
        public string LoginName { get; internal set; }
        public DateTime ExecutionStart { get; internal set; }
        public Int32 ErrorNum { get; internal set; }
        public string ErrorDesc { get; internal set; }

        public ProgressBarIncreaseEventArgs(Int32 ProgressBarIncreaseValue, 
            string ScriptNameValue, string LoginNameValue, DateTime ExecutionStartValue,
            Int32 ErrorNumValue, string ErrorDescValue)
        {
            this.ProgressBarValue = ProgressBarIncreaseValue;
            this.ScriptName = ScriptNameValue;
            this.LoginName = LoginNameValue;
            this.ExecutionStart = ExecutionStartValue;
            this.ErrorNum = ErrorNumValue;
            this.ErrorDesc = ErrorDescValue;
        }
    }

    public class DataSetsToGather
    {
        public DataTable ItemsToRun()
        {
            DataTable dtDataToGather = new DataTable();
            DataColumn dcName = new DataColumn("Name");
            DataColumn dcIsExecute = new DataColumn("IsExecute");

            dcName.AllowDBNull = false;
            dcName.AutoIncrement = false;
            dcName.Caption = "Name";
            dcName.ColumnName = "Name";
            dcName.DataType = System.Type.GetType("System.String");

            dcIsExecute.AllowDBNull = false;
            dcIsExecute.AutoIncrement = false;
            dcIsExecute.Caption = "IsExecute";
            dcIsExecute.ColumnName = "IsExecute";
            dcIsExecute.DataType = System.Type.GetType("System.Boolean");

            dtDataToGather.Columns.Add(dcName);
            dtDataToGather.Columns.Add(dcIsExecute);

            DataRow dr = dtDataToGather.NewRow();
            dr[dcName] = "IndexFragmentation";
            dr[dcIsExecute] = true;

            dtDataToGather.Rows.Add(dr);

            return dtDataToGather;

        }
    }

    public class WmiToGather
    {
            
        public DataTable GetWmiResults(string RequesterType,
            string strMachineName, 
            string strWindowsUserName, 
            string strWindowsPassword)
        {
            DataTable dt;

            if (RequesterType == WmiRequester.WmiRequesterTypes.Win32_DefragAnalysis.ToString())
            {
                WmiRequester.Win32_DefragAnalysis defrag = new WmiRequester.Win32_DefragAnalysis();
                dt = defrag.GetWin32_DefragAnalysis(strMachineName, strWindowsUserName, strWindowsPassword);
                return dt;
            }

            if (RequesterType == WmiRequester.WmiRequesterTypes.Win32_LogicalDisk.ToString())
            {
                WmiRequester.Win32_LogicalDisk disk = new WmiRequester.Win32_LogicalDisk();
                dt = disk.GetDiskInformation(strMachineName, strWindowsUserName, strWindowsPassword);
                return dt;
            }

            if (RequesterType == WmiRequester.WmiRequesterTypes.Win32_NetworkAdapterConfiguration.ToString())
            {
                WmiRequester.Win32_NetworkAdapterConfiguration nic = 
                    new WmiRequester.Win32_NetworkAdapterConfiguration();

                dt = nic.GetWin32_NetworkAdapterConfiguration(strMachineName, strWindowsUserName, strWindowsPassword);
                return dt;
            }

            if (RequesterType == WmiRequester.WmiRequesterTypes.Win32_OperatingSystem.ToString())
            {
                WmiRequester.Win32_OperatingSystem os = 
                    new WmiRequester.Win32_OperatingSystem();
                dt = os.GetOperatingSystemInfo(strMachineName, strWindowsUserName, strWindowsPassword);
                return dt;
            }

            if (RequesterType == WmiRequester.WmiRequesterTypes.Win32_PerfFormattedData_PerfOS_Memory.ToString())
            {
                WmiRequester.Win32_PerfFormattedData_PerfOS_Memory perfMem = 
                    new WmiRequester.Win32_PerfFormattedData_PerfOS_Memory();
                dt = perfMem.GetWin32_PerfFormattedData_PerfOS_Memory(strMachineName, strWindowsUserName, strWindowsPassword);
                return dt;
            }

            if (RequesterType == WmiRequester.WmiRequesterTypes.Win32_PhysicalMemory.ToString())
            {
                WmiRequester.Win32_PhysicalMemory physMem =
                    new WmiRequester.Win32_PhysicalMemory();
                dt = physMem.GetWin32_PhysicalMemory(strMachineName, strWindowsUserName, strWindowsPassword);
                return dt;
            }

            if (RequesterType == WmiRequester.WmiRequesterTypes.Win32_Product.ToString())
            {
                WmiRequester.Win32_Product prod = 
                    new WmiRequester.Win32_Product();
                dt = prod.GetWin32Product(strMachineName, strWindowsUserName, strWindowsPassword);
                return dt;
            }

            return null;
        }
    }
}
