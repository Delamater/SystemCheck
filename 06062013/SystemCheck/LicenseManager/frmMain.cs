using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LicenseManager
{
    public partial class Form1 : Form
    {

        //Used for both checking and making the license
        private string _strLicensePath = 
            Path.GetDirectoryName(Application.StartupPath + @"..\..\..\License\");

        LicenseMaker _alm = new LicenseMaker();
        ErrorHandler _err = new ErrorHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox frmAbt = new frmAboutBox();
            frmAbt.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCheckLicenseFile_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_alm.IsLicensed(GetLicenseFilePathAndName()))
                {
                    case true:
                        //Do nothing, allow app to continue
                        break;

                    case false:
                        _err.ShowError(new ApplicationException(_alm.ApplicationNotLicensedErrorMessage),
                             MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                }
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateLicense_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtInputString.Text.Trim()))
            {
                return;
            }
            
            try
            {
                //_alm.MakeLicenseKey(GetLicenseFilePathAndName(), txtCustName.Text, dtpLicensedUntil.Value, txtMachineName.Text);
                _alm.MakeLicenseKey(GetLicenseFilePathAndName(), txtInputString.Text, dtpLicensedUntil.Value);
                txtKeyFileLocation.Text = GetLicenseFilePathAndName();
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string GetLicenseFilePathAndName()
        {
           
            string strFullPath = string.Empty;
            strFullPath = Path.Combine(_strLicensePath, Constants.strLicenseFileName);

            return strFullPath;
        }

        private void txtInputString_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string strInput = string.Empty;
                strInput = txtInputString.Text;

                if (strInput.Length == 0)
                {
                    grpDecryptedValues.Visible = false;
                    _alm.Clear();
                    txtMacID.Text = _alm.MacID;
                    txtUserDomainName.Text = _alm.UserDomainName;
                    txtMachineName.Text = _alm.MachineName;
                }

                if (strInput.Length > 0)
                {
                    _alm.SetLicenseParts(strInput);
                    txtMacID.Text = _alm.MacID;
                    txtUserDomainName.Text = _alm.UserDomainName;
                    txtMachineName.Text = _alm.MachineName;
                    grpDecryptedValues.Visible = true;
                }

            }
            catch (FormatException)
            {
                
                // A format exception can happen if a string doesn't decrypt properly
                // such as when typing manually into the input string textbox
                _alm.Clear();
                txtMachineName.Text = string.Empty;
                txtMacID.Text = string.Empty;
                txtUserDomainName.Text = string.Empty;
                grpDecryptedValues.Visible = false;
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtInputString.Text = _alm.RequestLicense();
        }

    }
}
