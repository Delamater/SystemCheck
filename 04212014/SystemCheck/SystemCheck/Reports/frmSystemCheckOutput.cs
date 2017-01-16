using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SystemCheck.Reports
{
    public partial class frmSystemCheckOutput : Form
    {
        DataView _myDv = new DataView();
        private string _strCompanyName = "";

        public DataView ReportDatasource
        {
            get { return _myDv; }
            set { _myDv = value; }
        }

        public string myCompanyName
        { 
            get { return _strCompanyName; }
            set { _strCompanyName = value; }
        }

        public frmSystemCheckOutput()
        {
            InitializeComponent();
        }

        
            


        private void frmSystemCheckOutput_Load(object sender, EventArgs e)
        {
            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("Company", this.myCompanyName, false);
            rvSystemCheck.ShowParameterPrompts = true;

            rvSystemCheck.LocalReport.SetParameters(param);

            this.rvSystemCheck.RefreshReport();
            if (this.ReportDatasource != null)
            {
                dtChecklistBindingSource.DataSource = this.ReportDatasource;
                this.rvSystemCheck.RefreshReport();
                this.rvSystemCheck.LocalReport.ReleaseSandboxAppDomain();
            }

            //this.rvSystemCheck.RefreshReport();
        }
    }
}
