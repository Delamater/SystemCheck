using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemCheck
{
    public class Utilities
    {


        public class SchemaUtilities : Utilities
        {
            public string[] SystemDataTablesThatShouldNotBeBound
            {
                get
                {
                    string[] strSystemTables = new string[4];
                    strSystemTables[0] = "dtRunLog";
                    strSystemTables[1] = "dtEventLogItemsToCheck";
                    strSystemTables[2] = "dtEventLog";
                    strSystemTables[3] = "dtChecklist";
                    return strSystemTables;
                }
            }


            /// <summary>
            /// Given a dsChecklist dataset this routine will determine
            /// if the dataset has been populated with any data that 
            /// is not considered a system table. The dsChecklist 
            /// dataset will always have system tables in it as well. This routine will 
            /// look for any tables that are not a system table. Next it will check to 
            /// see if the table has rows. If it does then the it will report true.
            /// </summary>
            /// <param name="ds"></param>
            /// <returns></returns>
            public Boolean IsDatasetPopulatedWithNonSystemTables(dsChecklist ds)
            {
                bool blnIsDatasetPopulatedWithNonSystemTables = false;

                //The dataset must have at least one table
                if (ds.Tables.Count > 0)
                {

                    //Check each table in the dsChecklist dataset
                    foreach (System.Data.DataTable dt in ds.Tables)
                    {
                        if (IsSystemTable(dt.TableName) == false)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                blnIsDatasetPopulatedWithNonSystemTables = true;
                                return blnIsDatasetPopulatedWithNonSystemTables;
                            }
                        }
                    }

                    //dtChecklist is a system table, but it also contains user data.
                    //Check dtChecklist to see if there are any values in the YourValue column
                    if (ds.Tables.Contains("dtChecklist") == true)
                    {
                        if (IsCheckListDataTablePopulated(ds.Tables["dtChecklist"]) == true)
                        {
                            blnIsDatasetPopulatedWithNonSystemTables = true;
                            return blnIsDatasetPopulatedWithNonSystemTables;
                        }
                    }
                }

                //There is a chance the user may have run only the checklist checks
                //In this situation, check that the run log has been populated
                if (ds.Tables.Contains("dtRunLog") == true)
                {
                    if (ds.Tables["dtRunLog"].Rows.Count > 0)
                    {
                        blnIsDatasetPopulatedWithNonSystemTables = true;
                        return blnIsDatasetPopulatedWithNonSystemTables;
                    }
                }

                //If we made it here we have not populated the 
                //dsChecklist dataset with non-system tables or non-system data
                return blnIsDatasetPopulatedWithNonSystemTables;
            }

            public Boolean IsCheckListDataTablePopulated(System.Data.DataTable dt)
            {
                Boolean IsCheckListPopulated = false;
                if (dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow dr in dt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr["YourValue"].ToString()) == false)
                        {
                            IsCheckListPopulated = true;
                            return IsCheckListPopulated;
                        }
                    }
                }

                return IsCheckListPopulated;
            }

            public bool IsSystemTable(string someTable)
            {

                foreach (string systemTable in this.SystemDataTablesThatShouldNotBeBound)
                {
                    if (someTable == systemTable)
                    {
                        //This is a system table
                        return true;
                    }
                }

                // This is not a system table
                return false;
            }
        }
        
    }
}
