using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Management;

namespace SystemCheck
{
    public class WmiRequester
    {
        public enum WmiRequesterTypes
        {
            Win32_OperatingSystem, 
            Win32_Product, 
            Win32_LogicalDisk, 
            Win32_NetworkAdapterConfiguration, 
            Win32_PhysicalMemory, 
            Win32_DefragAnalysis, 
            Win32_PerfFormattedData_PerfOS_Memory
        }
        public class Utilities : WmiRequester
        {
            protected DataTable GetDatatableFromWmiQuery(ManagementObjectSearcher searcher)
            {
                DataTable dt = new DataTable();

                //Create columns and add them to the datatable
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (dt.Columns.Count == 0)
                    {
                        foreach (PropertyData item in queryObj.Properties)
                        {
                            dt.Columns.Add(item.Name);
                        }
                    }
                }

                //Create rows and add them to data table
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    DataRow dr = dt.NewRow();
                    foreach (PropertyData item in queryObj.Properties)
                    {
                        dr[item.Name] = item.Value;
                    }

                    dt.Rows.Add(dr);
                }

                return dt;
            }

            protected bool IsMachineNameLocal(string strMachineName)
            {
                //Assume it is false unless otherwise specified
                bool blnIsMachineLocal = false;


                if (strMachineName == ".")
                {
                    blnIsMachineLocal = true;
                }

                if (strMachineName == "127.0.0.1")
                {
                    blnIsMachineLocal = true;
                }

                if (strMachineName == Environment.MachineName)
                {
                    blnIsMachineLocal = true;
                }

                return blnIsMachineLocal;
            }

            protected ManagementObjectSearcher GetSearcher(string strMachineName, string strWindowsUserName, string strWindowsPassword, string strQuery)
            {
                //Connection credentials to the remove computer, not needed if the logged account has access
                ConnectionOptions oConn = new ConnectionOptions();
                string strNameSpace = @"\\";

                if (IsMachineNameLocal(strMachineName) == false)
                {
                    strNameSpace += strMachineName;
                    oConn.Username = strWindowsUserName;
                    oConn.Password = strWindowsPassword;
                }
                else { strNameSpace += "."; }

                strNameSpace += @"\root\cimv2";
                ManagementScope oMs = new ManagementScope(strNameSpace, oConn);

                //get Fixed disk state
                ObjectQuery oQuery =
                    new ObjectQuery(strQuery);

                //Execute the query
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
                return oSearcher;
            }
        }

        public class Win32_OperatingSystem: Utilities
        {
            
            public DataTable GetOperatingSystemInfo(string strMachineName, string strWindowsUserName, string strWindowsPassword)
            {
                //Set up the query
                Utilities _utils = new Utilities();
                string strQuery = "SELECT * FROM Win32_OperatingSystem";
                DataTable dt = new DataTable("Win32_OperatingSystem");
                ManagementObjectSearcher oSearcher = GetSearcher(strMachineName, strWindowsUserName, strWindowsPassword, strQuery);

                //Run the query and store into datatable
                
                dt = GetDatatableFromWmiQuery(oSearcher);
                
                return dt;

            }
        }

        public class Win32_Product: Utilities
        {
            
            public DataTable GetWin32Product(string strMachineName, string strWindowsUserName, string strWindowsPassword)
            {

                //Set up query
                string strQuery = "SELECT * FROM Win32_Product";
                DataTable dt = new DataTable("Win32_Product");
                ManagementObjectSearcher oSearcher = GetSearcher(strMachineName, strWindowsUserName, strWindowsPassword, strQuery);

                //Run the query and store into datatable
                dt = GetDatatableFromWmiQuery(oSearcher);
                
                return dt;
            }
        }

        public class Win32_LogicalDisk : Utilities
        {
            //Documentation on Win32_LogicalDisk can be found at
            //http://msdn.microsoft.com/en-us/library/aa394173.aspx

            /// <summary>
            /// If a blank string is sent for the machine name then the local 
            /// machine will be scanned instead of the remote machine. In addition, 
            /// the strWindowsUserName and strWindowsPassword arguments are ignored. 
            /// </summary>
            /// <param name="strMachineName">The name of the machine you want to connect to</param>
            /// <param name="strWindowsUserName">The user name of the person you want to impersonate. Use the local administrator to impersonate</param>
            /// <param name="strWindowsPassword">The password of the local admin associated with strWindowsUserName</param>
            /// <returns></returns>
            public DataTable GetDiskInformation(string strMachineName, string strWindowsUserName, string strWindowsPassword)
            {
                System.Data.DataTable dtResults = DataTableForWin32_LogicalDisk();
                string strQuery = 
                    "SELECT Name, Caption, FreeSpace, Size, DriveType, MediaType, Status, "
                        + "StatusInfo, VolumeName, VolumeDirty, Availability, ConfigManagerErrorCode "
                        + "FROM Win32_LogicalDisk "
                        + "WHERE DriveType=3";
                ManagementObjectSearcher oSearcher = GetSearcher(strMachineName, strWindowsUserName, strWindowsPassword, strQuery);

                //Get the results
                ManagementObjectCollection oReturnCollection = oSearcher.Get();

                //Loop through the results and store info
                //double D_Freespace = 0;
                //double D_Totalspace = 0;
                
                foreach (ManagementObject oReturn in oReturnCollection)
                {
                    DataRow dr = dtResults.NewRow();
                    dr["Name"] = oReturn["Name"];
                    dr["Caption"] = oReturn["Caption"];
                    
                    //bytes divided by 1024 squared = megabytes
                    dr["FreeSpaceMb"] = Convert.ToDouble(oReturn["FreeSpace"]) / Math.Pow(1024,2); 
                    
                    //bytes divided by 1024 squared = megabytes
                    dr["SizeMb"] = Convert.ToDouble(oReturn["Size"]) / Math.Pow(1024, 2);

                    // (Size - FreesSapce) = Used space
                    // (Size - FreeSpace) / Size = UsedPercent
                    dr["UsedPercent"] = Math.Round((Convert.ToDouble(oReturn["Size"]) - Convert.ToDouble(oReturn["FreeSpace"])) / Convert.ToDouble(oReturn["Size"]),2);
                    
                    dr["DriveType"] = SwitchDriveType(Convert.ToUInt32(oReturn["DriveType"]));
                    dr["MediaType"] = SwitchMediaType(Convert.ToUInt32(oReturn["MediaType"]));
                    dr["Status"] = oReturn["Status"] ?? "Unknown";
                    dr["StatusInfo"] = SwitchStatusInfo(Convert.ToUInt16(oReturn["StatusInfo"]));
                    dr["VolumeName"] = oReturn["VolumeName"];
                    dr["VolumeDirty"] = oReturn["VolumeDirty"];
                    dr["Availability"] = SwitchAvailability(Convert.ToUInt16(oReturn["Availability"]));
                    dr["ConfigManagerErrorCode"] = SwitchConfigManagerErrorCode(Convert.ToUInt32(oReturn["ConfigManagerErrorCode"]));

                    dr["TotalSpaceUsedMb"] = Convert.ToDouble(dr["SizeMb"]) - Convert.ToDouble(dr["FreeSpaceMb"]);
                    dtResults.Rows.Add(dr);
                }

                return dtResults;
            }


            private System.Data.DataTable DataTableForWin32_LogicalDisk()
            {
                //Build a datatable to store the results
                System.Data.DataTable dtDrives = new System.Data.DataTable();
                dtDrives.TableName = "Drives";
                DataColumn[] dcPrimaryKey = new DataColumn[1];
                DataColumn dcDriveKey = new DataColumn();
                DataColumn dcName = new DataColumn();
                DataColumn dcCaption = new DataColumn();
                DataColumn dcFreeSpaceMb = new DataColumn();
                DataColumn dcSizeMb = new DataColumn();
                DataColumn dcUsedPercent = new DataColumn();
                DataColumn dcDriveType = new DataColumn();
                DataColumn dcMediaType = new DataColumn();
                DataColumn dcStatus = new DataColumn();
                DataColumn dcStatusInfo = new DataColumn();
                DataColumn dcVolumeName = new DataColumn();
                DataColumn dcVolumeDirty = new DataColumn();
                DataColumn dcAvailability = new DataColumn();
                DataColumn dcConfigManagerErrorCode = new DataColumn();
                DataColumn dcTotalSpaceUsedMb = new DataColumn();


                dcDriveKey.DataType = System.Type.GetType("System.Int32");
                dcDriveKey.ColumnName = "DriveKey";
                dcDriveKey.AutoIncrementSeed = 1;
                dcDriveKey.AutoIncrement = true;
                dcDriveKey.AutoIncrementStep = 1;
                dcDriveKey.Caption = "Drive Key";
                dcDriveKey.Unique = true;

                dcName.ColumnName = "Name";
                dcName.DataType = System.Type.GetType("System.String");
                dcName.AllowDBNull = true;

                dcCaption.ColumnName = "Caption";
                dcCaption.DataType = System.Type.GetType("System.String");
                dcName.AllowDBNull = true;

                dcFreeSpaceMb.ColumnName = "FreeSpaceMb";
                dcFreeSpaceMb.DataType = System.Type.GetType("System.UInt64");
                dcName.AllowDBNull = true;

                dcSizeMb.ColumnName = "SizeMb";
                dcSizeMb.DataType = System.Type.GetType("System.UInt64");
                dcName.AllowDBNull = true;

                dcUsedPercent.ColumnName = "UsedPercent";
                dcUsedPercent.DataType = System.Type.GetType("System.Decimal");
                dcUsedPercent.AllowDBNull = true;

                dcDriveType.ColumnName = "DriveType";
                dcDriveType.DataType = System.Type.GetType("System.String");
                dcName.AllowDBNull = true;

                dcMediaType.ColumnName = "MediaType";
                dcMediaType.DataType = System.Type.GetType("System.String");
                dcName.AllowDBNull = true;

                dcStatus.ColumnName = "Status";
                dcStatus.DataType = System.Type.GetType("System.String");
                dcName.AllowDBNull = true;

                dcStatusInfo.ColumnName = "StatusInfo";
                dcStatusInfo.DataType = System.Type.GetType("System.String");
                dcName.AllowDBNull = true;

                dcVolumeName.ColumnName = "VolumeName";
                dcVolumeName.DataType = System.Type.GetType("System.String");
                dcName.AllowDBNull = true;

                dcVolumeDirty.ColumnName = "VolumeDirty";
                dcVolumeDirty.DataType = System.Type.GetType("System.Boolean");
                dcName.AllowDBNull = true;

                dcAvailability.ColumnName = "Availability";
                dcAvailability.DataType = System.Type.GetType("System.String");
                dcAvailability.AllowDBNull = true;

                dcConfigManagerErrorCode.ColumnName = "ConfigManagerErrorCode";
                dcConfigManagerErrorCode.DataType = System.Type.GetType("System.String");
                dcConfigManagerErrorCode.AllowDBNull = true;

                dcTotalSpaceUsedMb.ColumnName = "TotalSpaceUsedMb";
                dcTotalSpaceUsedMb.DataType = System.Type.GetType("System.UInt64");
                dcTotalSpaceUsedMb.AllowDBNull = true;

                dtDrives.Columns.Add(dcDriveKey);
                dtDrives.Columns.Add(dcName);
                dtDrives.Columns.Add(dcCaption);
                dtDrives.Columns.Add(dcFreeSpaceMb);
                dtDrives.Columns.Add(dcSizeMb);
                dtDrives.Columns.Add(dcUsedPercent);
                dtDrives.Columns.Add(dcDriveType);
                dtDrives.Columns.Add(dcMediaType);
                dtDrives.Columns.Add(dcStatus);
                dtDrives.Columns.Add(dcStatusInfo);
                dtDrives.Columns.Add(dcVolumeName);
                dtDrives.Columns.Add(dcVolumeDirty);
                dtDrives.Columns.Add(dcAvailability);
                dtDrives.Columns.Add(dcConfigManagerErrorCode);
                dtDrives.Columns.Add(dcTotalSpaceUsedMb);

                dcPrimaryKey[0] = dcDriveKey;
                dtDrives.PrimaryKey = dcPrimaryKey;

                return dtDrives;
            }

            private string SwitchMediaType(UInt32? UInt32MediaType)
            {
                string strMediaType = "";

                switch (UInt32MediaType)
                {
                    case null:
                    case 0:
                        strMediaType = "Format is unknown";
                        break;
                    case 1:
                        strMediaType = "5 1/4-Inch Floppy Disk - 1.2 MB - 512 bytes/sector";
                        break;
                    case 2:
                        strMediaType = "3 1/2-Inch Floppy Disk - 1.44 MB -512 bytes/sector";
                        break;
                    case 3:
                        strMediaType = "3 1/2-Inch Floppy Disk - 2.88 MB - 512 bytes/sector";
                        break;
                    case 4:
                        strMediaType = "3 1/2-Inch Floppy Disk - 20.8 MB - 512 bytes/sector";
                        break;
                    case 5:
                        strMediaType = "3 1/2-Inch Floppy Disk - 720 KB - 512 bytes/sector";
                        break;
                    case 6:
                        strMediaType = "5 1/4-Inch Floppy Disk - 360 KB - 512 bytes/sector";
                        break;
                    case 7:
                        strMediaType = "5 1/4-Inch Floppy Disk - 320 KB - 512 bytes/sector";
                        break;
                    case 8:
                        strMediaType = "5 1/4-Inch Floppy Disk - 320 KB - 1024 bytes/sector";
                        break;
                    case 9:
                        strMediaType = "5 1/4-Inch Floppy Disk - 180 KB - 512 bytes/sector";
                        break;
                    case 10:
                        strMediaType = "5 1/4-Inch Floppy Disk - 160 KB - 512 bytes/sector";
                        break;
                    case 11:
                        strMediaType = "Removable media other than floppy";
                        break;
                    case 12:
                        strMediaType = "Fixed hard disk media";
                        break;
                    case 13:
                        strMediaType = "3 1/2-Inch Floppy Disk - 120 MB - 512 bytes/sector";
                        break;
                    case 14:
                        strMediaType = "3 1/2-Inch Floppy Disk - 640 KB - 512 bytes/sector";
                        break;
                    case 15:
                        strMediaType = "5 1/4-Inch Floppy Disk - 640 KB - 512 bytes/sector";
                        break;
                    case 16:
                        strMediaType = "5 1/4-Inch Floppy Disk - 720 KB - 512 bytes/sector";
                        break;
                    case 17:
                        strMediaType = "3 1/2-Inch Floppy Disk - 1.2 MB - 512 bytes/sector";
                        break;
                    case 18:
                        strMediaType = "3 1/2-Inch Floppy Disk - 1.23 MB - 1024 bytes/sector";
                        break;
                    case 19:
                        strMediaType = "5 1/4-Inch Floppy Disk - 1.23 MB - 1024 bytes/sector";
                        break;
                    case 20:
                        strMediaType = "3 1/2-Inch Floppy Disk - 128 MB - 512 bytes/sector";
                        break;
                    case 21:
                        strMediaType = "3 1/2-Inch Floppy Disk - 230 MB - 512 bytes/sector";
                        break;
                    case 22:
                        strMediaType = "8-Inch Floppy Disk - 256 KB - 128 bytes/sector";
                        break;
                    default:
                        strMediaType = "Format is unknown";
                        break;
                }
                return strMediaType;
            }

            private string SwitchStatusInfo(UInt16? StatusInfo)
            {
                string strStatusInfo = "";

                switch (StatusInfo)
                {
                    case 1:
                        strStatusInfo = "Other";
                        break;
                    case 2:
                        strStatusInfo = "Unknown";
                        break;
                    case 3:
                        strStatusInfo = "Enabled";
                        break;
                    case 4:
                        strStatusInfo = "Disabled";
                        break;
                    case 5:
                        strStatusInfo = "Not applicable";
                        break;
                    case null:
                    default:
                        strStatusInfo = "Unknown";
                        break;
                }

                return strStatusInfo;
            }

            private string SwitchAvailability(UInt16? Availability)
            {
                string strAvailability = "";
                switch (Availability)
                {
                    case 1:
                        strAvailability = "Other";
                        break;
                    case 2:
                        strAvailability = "Unknown";
                        break;
                    case 3:
                        strAvailability = "Running or Full Power";
                        break;
                    case 4:
                        strAvailability = "Warning";
                        break;
                    case 5:
                        strAvailability = "In Test";
                        break;
                    case 6:
                        strAvailability = "Not Applicable";
                        break;
                    case 7:
                        strAvailability = "Power Off";
                        break;
                    case 8:
                        strAvailability = "Offline";
                        break;
                    case 9:
                        strAvailability = "Off Duty";
                        break;
                    case 10:
                        strAvailability = "Degraded";
                        break;
                    case 11:
                        strAvailability = "Not Installed";
                        break;
                    case 12:
                        strAvailability = "Install Error";
                        break;
                    case 13:
                        strAvailability = "Power Save - Unknown. The device is known to be in a power save mode, but its exact status is unknown.";
                        break;
                    case 14:
                        strAvailability = "Power Save - Low Power Mode. The device is in a power save state, but still functioning, and may exhibit degraded performance.";
                        break;
                    case 15:
                        strAvailability = "Power Save - Standby. The device is not functioning, but could be brought to full power quickly.";
                        break;
                    case 16:
                        strAvailability = "Power Cycle";
                        break;
                    case 17:
                        strAvailability = "Power Save - Warning. The device is in a warning state, but also in a power save mode.";
                        break;
                    case null:
                    default:
                        strAvailability = "Unknown availability type";
                        break;
                }

                return strAvailability;
            }
            private string SwitchConfigManagerErrorCode(UInt32? ConfigManagerErrorCode)
            {
                string strConfigManagerError = "";
                switch (ConfigManagerErrorCode)
                {
                    case 0:
                        strConfigManagerError = "Device is working properly";
                        break;
                    case 1:
                        strConfigManagerError = "Device is not configured correctly";
                        break;
                    case 2:
                        strConfigManagerError = "Windows cannot load the driver for this device";
                        break;
                    case 3:
                        strConfigManagerError = "Driver for this device might be corrupted, or the system may be low on memory or other resources";
                        break;
                    case 4:
                        strConfigManagerError = "Device is not working properly. One of its drivers or the registry might be corrupted";
                        break;
                    case 5:
                        strConfigManagerError = "Driver for the device requires a resource that Windows cannot manage";
                        break;
                    case 6:
                        strConfigManagerError = "Boot configuration for the device conflicts with other devices";
                        break;
                    case 7:
                        strConfigManagerError = "Cannot filter";
                        break;
                    case 8:
                        strConfigManagerError = "Driver loader for the device is missing";
                        break;
                    case 9:
                        strConfigManagerError = "Device is not working properly. The controlling firmware is incorrectly reporting the resources for the device";
                        break;
                    case 10:
                        strConfigManagerError = "Device cannot start";
                        break;
                    case 11:
                        strConfigManagerError = "Device failed";
                        break; 
                    case 12:
                        strConfigManagerError = "Device cannot find enough free resources to use";
                        break;
                    case 13:
                        strConfigManagerError = "Windows cannot verify the device resources";
                        break;
                    case 14:
                        strConfigManagerError = "Device cannot work properly until the computer is restarted";
                        break;
                    case 15:
                        strConfigManagerError = "Device is not working properly due to a possible re-enumeration problem";
                        break;
                    case 16:
                        strConfigManagerError = "Windows cannot identify all of the resources that the device uses";
                        break;
                    case 17:
                        strConfigManagerError = "Device is requesting an unknown resource type";
                        break;
                    case 18:
                        strConfigManagerError = "Device drivers must be reinstalled";
                        break;
                    case 19:
                        strConfigManagerError = "Failure using the VxD loader";
                        break;
                    case 20:
                        strConfigManagerError = "Registry might be corrupted";
                        break;
                    case 21:
                        strConfigManagerError = "System failure. If changing the device driver is ineffective, see the hardware documentation. Windows is removing the device";
                        break;
                    case 22:
                        strConfigManagerError = "Device is disabled";
                        break;
                    case 23:
                        strConfigManagerError = "System failure. If changing the device driver is ineffective, see the hardware documentation";
                        break;
                    case 24:
                        strConfigManagerError = "Device is not present, not working properly, or does not have all of its drivers installed";
                        break;
                    case 25:
                        strConfigManagerError = "Windows is still setting up the device";
                        break;
                    case 26:
                        strConfigManagerError = "Windows is still setting up the device";
                        break;
                    case 27:
                        strConfigManagerError = "Device does not have valid log configuration";
                        break;
                    case 28:
                        strConfigManagerError = "Device drivers are not installed";
                        break;
                    case 29:
                        strConfigManagerError = "Device is disabled. The device firmware did not provide the required resources";
                        break;
                    case 30:
                        strConfigManagerError = "Device is using an IRQ resource that another device is using";
                        break;
                    case 31:
                        strConfigManagerError = "Device is not working properly. Windows cannot load the required device drivers";
                        break;
                    case null:
                    default:
                        strConfigManagerError = "Unknown ConfigManagerErrorCode";
                        break;
                }

                return strConfigManagerError;
            }

            private string SwitchDriveType(UInt32? DriveType)
            {
                string strDriveType = "";
                switch (DriveType)
                {
                    case 0:
                        strDriveType = "Unknown";
                        break;
                    case 1:
                        strDriveType = "No Root Directory";
                        break;
                    case 2:
                        strDriveType = "Removable Disk";
                        break;
                    case 3:
                        strDriveType = "Local Disk";
                        break;
                    case 4:
                        strDriveType = "Network Drive";
                        break;
                    case 5:
                        strDriveType = "Compact Disc";
                        break;
                    case 6:
                        strDriveType = "RAM Disk";
                        break;
                    case null:
                    default:
                        strDriveType = "Unknown Drive Type";
                        break;
                }

                return strDriveType;
            }
        }

        public class Win32_NetworkAdapterConfiguration : Utilities
        {
            /// <summary>
            /// Returns information about the Network adapters on the machine
            /// </summary>
            /// <param name="strMachineName">The machine to query</param>
            /// <param name="strWindowsUserName">The local administrator's user name on the machine</param>
            /// <param name="strWindowsPassword">The password of the local admin associated with strWindowsUserName</param>
            /// <returns></returns>
            public DataTable GetWin32_NetworkAdapterConfiguration(string strMachineName, string strWindowsUserName, string strWindowsPassword)
            {
                //Set up query
                string strQuery = "SELECT * FROM Win32_NetworkAdapterConfiguration";
                DataTable dt = new DataTable("Win32_NetworkAdapterConfiguration");
                ManagementObjectSearcher oSearcher = GetSearcher(strMachineName, strWindowsUserName, strWindowsPassword, strQuery);

                //Run the query and store into datatable
                dt = GetDatatableFromWmiQuery(oSearcher);

                return dt;
            }
        }

        public class Win32_PhysicalMemory : Utilities
        {
            /// <summary>
            /// Returns information about the physical memory on themachine
            /// </summary>
            /// <param name="strMachineName">The machine to query</param>
            /// <param name="strWindowsUserName">The local administrator's user name on the machine</param>
            /// <param name="strWindowsPassword">The password of the local admin associated with strWindowsUserName</param>
            /// <returns></returns>
            public DataTable GetWin32_PhysicalMemory(string strMachineName, string strWindowsUserName, string strWindowsPassword)
            {
                //Set up query
                string strQuery = "SELECT * FROM Win32_PhysicalMemory";
                DataTable dt = new DataTable("Win32_PhysicalMemory");
                ManagementObjectSearcher oSearcher = GetSearcher(strMachineName, strWindowsUserName, strWindowsPassword, strQuery);

                //Run the query and store into datatable
                dt = GetDatatableFromWmiQuery(oSearcher);

                return dt;
                
            }
        }

        public class Win32_DefragAnalysis : Utilities
        {
            /// <summary>
            /// Returns information about fragmentation on a volume
            /// </summary>
            /// <param name="strMachineName">The machine to query</param>
            /// <param name="strWindowsUserName">The local administrator's user name on the machine</param>
            /// <param name="strWindowsPassword">The password of the local admin associated with strWindowsUserName</param>
            /// <returns></returns>
            public DataTable GetWin32_DefragAnalysis(string strMachineName, string strWindowsUserName, string strWindowsPassword)
            {
                //Set up query
                string strQuery = "SELECT * FROM Win32_DefragAnalysis";
                DataTable dt = new DataTable("Win32_DefragAnalysis");
                ManagementObjectSearcher oSearcher = GetSearcher(strMachineName, strWindowsUserName, strWindowsPassword, strQuery);

                //Run the query and store into datatable
                dt = GetDatatableFromWmiQuery(oSearcher);

                return dt;
            }
        }

        public class Win32_PerfFormattedData_PerfOS_Memory : Utilities
        {
            public DataTable GetWin32_PerfFormattedData_PerfOS_Memory(string strMachineName, string strWindowsUserName, string strWindowsPassword)
            {
                //Set up query
                string strQuery = "SELECT * FROM Win32_PerfFormattedData_PerfOS_Memory";
                DataTable dt = new DataTable("Win32_PerfFormattedData_PerfOS_Memory");
                ManagementObjectSearcher oSearcher = GetSearcher(strMachineName, strWindowsUserName, strWindowsPassword, strQuery);

                dt = GetDatatableFromWmiQuery(oSearcher);

                return dt;
            }
        }
    }
}
