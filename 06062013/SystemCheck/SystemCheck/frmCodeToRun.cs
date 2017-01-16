using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemCheck
{
    public partial class frmCodeToRun : Form
    {
        private string _strCodeToRun = "";
        private string _strCodeToRunFileName = "";

        public string CodeToRunFileName
        {
            get{return _strCodeToRun;}
            set{_strCodeToRunFileName = value;}
        }

        public string CodeToRun
        {
            get { return _strCodeToRun; }
            set { _strCodeToRun = value; }
        }

        public frmCodeToRun()
        {
            InitializeComponent();
        }

        private void frmCodeToRun_Load(object sender, EventArgs e)
        {

        }
    }
}
