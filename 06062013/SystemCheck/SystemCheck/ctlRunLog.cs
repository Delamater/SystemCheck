using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemCheck
{
    public partial class ctlRunLog : UserControl
    {
        Checklist _chk = new Checklist();
        GridMgr _grd = new GridMgr();

        public ctlRunLog()
        {
            InitializeComponent();
        }




        private void RunLog_Load(object sender, EventArgs e)
        {
            //Wire up listening event
            _chk.ProgressBarIncrease += 
                new Checklist.ProgressBarValueIncreaseHandler(ProgressBarIncreaseSubscriber);

            _grd.ApplyGridStyle(dgvRunLog);

        }

        public void ProgressBarIncreaseSubscriber(object sender, ProgressBarIncreaseEventArgs ProgressBarIncreaseValue)
        {
            dsChecklist.dtRunLogRow dr = dsChecklist1.dtRunLog.NewdtRunLogRow();
            pbarCheckProgress.Value = ProgressBarIncreaseValue.ProgressBarValue;
            
            dr.ErrorValue = ProgressBarIncreaseValue.ErrorNum;
            dr.ErrorDesc = ProgressBarIncreaseValue.ErrorDesc;
            dr.ExecutionStart = ProgressBarIncreaseValue.ExecutionStart;
            dr.LoginName = ProgressBarIncreaseValue.LoginName;
            dr.ScriptName = ProgressBarIncreaseValue.ScriptName;

            dsChecklist1.dtRunLog.Rows.Add(dr);
        }


    }
}
