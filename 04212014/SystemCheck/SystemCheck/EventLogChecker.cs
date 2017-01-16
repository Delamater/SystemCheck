using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Data;

namespace SystemCheck
{
    class EventLogChecker
    {
        private FileMgr _fmgr = new FileMgr();


        /// <summary>
        /// Returns a datatable which contains the events log items to check
        /// </summary>
        public dsChecklist.dtEventLogItemsToCheckDataTable EventLogIdsToCheck
        {
            get
            {
                try
                {
                    dsChecklist.dtEventLogItemsToCheckDataTable dt =
                        new dsChecklist.dtEventLogItemsToCheckDataTable();

                    dt.ReadXml(_fmgr.GetFile("dtEventLogItemsToCheck.xml").FullName);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Adds the events log items to check to the global dataset for this app
        /// </summary>
        /// <param name="ds"></param>
        public void SetEventLogsToCheck(dsChecklist ds)
        {
            ds.dtEventLogItemsToCheck.ReadXml(_fmgr.GetFile("dtEventLogItemsToCheck.xml").FullName);
        }

        public enum enumLogType { Application, Security, System, MicrosoftWindowsGroupPolicyOperational }

        public EventLog[] GetEventLogs(string strMachineName)
        {
            try
            {
                EventLog[] EventLogs;
                EventLogs = EventLog.GetEventLogs(strMachineName);

                return EventLogs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


        /// <summary>
        /// Returns a datatable of results from the event log
        /// </summary>
        /// <param name="dtItemsToCheck"></param>
        /// <param name="dtEventLog"></param>
        /// <returns></returns>
        public dsChecklist.dtEventLogDataTable ReadEventLog(
            string DomainName, string UserName, string MachineNameToQuery, string Password,
            dsChecklist.dtEventLogItemsToCheckDataTable dtItemsToCheck, 
            dsChecklist.dtEventLogDataTable dtEventLog)
        {
            try
            {

                foreach (DataRow dr in dtItemsToCheck.Rows)
                {
                    string strQuery = "*[System/EventID=" + dr["InstanceID"].ToString() + "]";
                    var elQuery = new EventLogQuery(dr["LogType"].ToString(), PathType.LogName, strQuery);

                    //Remote machine query assignment
                    System.Security.SecureString pw = new System.Security.SecureString();

                    //Set the secure string
                    char[] passwordChars = Password.ToCharArray();
                    foreach (char c in passwordChars)
                    {
                        pw.AppendChar(c);
                    }


                    //Build the info for the remote query session
                    EventLogSession session = new EventLogSession(
                        MachineNameToQuery,
                        DomainName,
                        UserName,
                        pw,
                        SessionAuthentication.Default);

                    pw.Dispose();

                    //Assign session to current query
                    elQuery.Session = session;

                    var elReader = new EventLogReader(elQuery);
                    StringBuilder sbDescription = new StringBuilder();

                    for (EventRecord eventInstance = elReader.ReadEvent();
                    null != eventInstance;
                    eventInstance = elReader.ReadEvent())
                    {
                        DataRow drEventLog = dtEventLog.NewRow();
                        drEventLog["RecordID"] = eventInstance.RecordId; ;
                        drEventLog["InstanceID"] = eventInstance.Id;

                        //for (int j = 0; j < eventInstance.Properties.Count; j++)
                        //{

                        //    sbDescription.Append(eventInstance.Properties[j].Value.ToString() + Environment.NewLine);
                        //}

                        drEventLog["LogType"] = eventInstance.LogName;
                        drEventLog["Description"] = eventInstance.FormatDescription() 
                            + Environment.NewLine 
                            + Environment.NewLine 
                            + "Opcode: " + eventInstance.OpcodeDisplayName;
                        drEventLog["ProviderName"] = eventInstance.ProviderName;
                        drEventLog["MachineName"] = eventInstance.MachineName;
                        drEventLog["UserID"] = eventInstance.UserId;
                        drEventLog["TimeCreated"] = eventInstance.TimeCreated;
                        drEventLog["LevelDisplayName"] = eventInstance.LevelDisplayName;
                        dtEventLog.Rows.Add(drEventLog);

                        sbDescription.Clear();
                    }
                }

            }
            catch (EventLogException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtEventLog; ;
        }

    }
}
