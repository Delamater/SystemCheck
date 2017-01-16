using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SystemCheck
{
    public partial class frmLogin : Form
    {
        #region "Properties And Declarations"
        private enum enumButtonType { AcceptButton, CancelButton };
        private ErrorHandler _err = new ErrorHandler();
        public const string kSqlAuth = "Sql Authentication";
        public const string kWinAuth = "Windows Authentication";
        private SqlConnection _cnn = null;
        private string _WindowsUser = "";
        private string _WindowsPwd = "";
        private string _WindowsDomain = "";
        private string _WindowsMachineName = "";
        private string _SqlServerName = "";

        //Error handlers
        protected ErrorProvider _errServer = new ErrorProvider();
        protected ErrorProvider _errUserName = new ErrorProvider();


        public SqlConnection myConnection
        {

            get 
            { 
                return _cnn; 
            }
            
            set 
            { 
                _cnn = value;
                DataAccessLayer.SqlConnectionString = value.ConnectionString;
            }

        }

        public string WindowsUser
        {
            get { return _WindowsUser; }
            set { _WindowsUser = value; }
        }

        public string WindowsPwd
        {
            get { return _WindowsPwd; }
            set { _WindowsPwd = value; }
        }

        public string WindowsDomain
        {
            get { return _WindowsDomain; }
            set { _WindowsDomain = value; }
        }

        public string WindowsMachineName
        {
            get { return _WindowsMachineName; }
            set { _WindowsMachineName = value; }
        }

        public string SqlServerName
        {
            get { return _SqlServerName; }
            set { _SqlServerName = value; }
        }
        #endregion

        public frmLogin()
        {
            InitializeComponent();
        }

        private void SetDefault(Button myDefaultBtn)
        {
           
            this.AcceptButton = myDefaultBtn;
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            SetFormDefaults();

            cboAuthentication.Items.Clear();

            cboAuthentication.Items.Add(kWinAuth);
            cboAuthentication.Items.Add(kSqlAuth);
            cboAuthentication.SelectedIndex = 0;

            txtSqlPassword.Text = string.Empty;
            txtSqlPassword.Enabled = false;

            string strDomainName = "";
            string strUserName = "";
            strDomainName = Environment.UserDomainName;
            strUserName = Environment.UserName;
            txtSqlUserName.Text = strDomainName + @"\" + strUserName;

            //DebugCode();
        }

        private void SetFormDefaults()
        {
            SetDefault(btnConnect);

            if (string.IsNullOrEmpty(this.SqlServerName) == true)
            {
                txtSqlServerName.Text = Environment.MachineName;
                this.SqlServerName = Environment.MachineName;
            }

            if (string.IsNullOrEmpty(this.WindowsUser) == true)
            {
                txtWindowsUser.Text = Environment.UserName;
                this.WindowsUser = Environment.UserName;
            }

            if (string.IsNullOrEmpty(this.WindowsDomain) == true)
            {
                txtDomain.Text = Environment.UserDomainName;
                this.WindowsDomain = Environment.UserDomainName;
            }

            if (string.IsNullOrEmpty(this.WindowsMachineName) == true)
            {
                txtWindowsMachineName.Text = Environment.MachineName;
                this.WindowsMachineName = Environment.MachineName;
            }
            
        }

        private void DebugCode()
        {
            cboAuthentication.SelectedIndex = 1;
            txtSqlServerName.Text = @"127.0.0.1";
            txtSqlUserName.Text = "sa";
            txtSqlPassword.Text = "Passw0rd";
            
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {

            SetConnection(cboAuthentication.SelectedItem.ToString(), txtWindowsUser.Text, txtWindowsMachineName.Text, txtWindowsPassword.Text, txtDomain.Text);

        }

        public void SetConnection(string strAuthenticationType, string strWindowsUser, string strWindowsMachineName, string strWindowsPwd, string strWindowsDomain)
        {
            SqlConnectionStringBuilder cnnSb = new SqlConnectionStringBuilder();
            try
            {

                this.WindowsUser = txtWindowsUser.Text;
                this.WindowsPwd = txtWindowsPassword.Text;
                this.WindowsMachineName = txtWindowsMachineName.Text;
                this.SqlServerName = txtSqlServerName.Text;
                if (strWindowsDomain != null)
                {
                    this.WindowsDomain = txtDomain.Text;
                }
        
                // This program requires sysadmin user, master DB is appropriate
                cnnSb.ApplicationName = Application.ProductName;
                cnnSb.InitialCatalog = "master";
                cnnSb.ConnectTimeout = Properties.Settings.Default.QueryTimeout;
                if (strAuthenticationType == kWinAuth)
                {
                    cnnSb.IntegratedSecurity = true;
                }
                else if (strAuthenticationType == kSqlAuth)
                {
                    cnnSb.Password = txtSqlPassword.Text;
                    cnnSb.UserID = txtSqlUserName.Text;
                }
                else
                {
                    throw new ApplicationException("The authentication type is unknown");
                }


                cnnSb.WorkstationID = Environment.MachineName;
                cnnSb.DataSource = txtSqlServerName.Text;

                cnnSb.ConnectTimeout = 30;
                if (TestConnection(cnnSb.ToString()) == true)
                {
                    this.myConnection = new SqlConnection(cnnSb.ToString());
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                cnnSb.ConnectTimeout = Properties.Settings.Default.QueryTimeout;
                this.myConnection = new SqlConnection(cnnSb.ToString());
            }    
        }

        private string GetWindowsUserName()
        {
            string strDomain = "";
            string strUser = "";
            strDomain = Environment.UserDomainName;
            strUser = Environment.UserName;

            return strDomain + @"\" + strUser;
        }

        public bool TestConnection(string strConnection)
        {
            if (strConnection == string.Empty)
            {
                return false;
            }

            try
            {
                DataAccessLayer.SqlConnectionString = strConnection;
                //DataAccessLayer.LoginName = 
                DataAccessLayer.ExecuteScalar("SELECT 1*10", CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboAuthentication.SelectedItem.ToString())
            {
                case kSqlAuth:
                    txtSqlUserName.Enabled = true;
                    txtSqlUserName.Text = string.Empty;

                    txtSqlPassword.Enabled = true;
                    txtSqlPassword.Text = string.Empty;
                    break;

                case kWinAuth:
                    txtSqlUserName.Text = GetWindowsUserName();
                    txtSqlUserName.Enabled = false;

                    txtSqlPassword.Text = string.Empty;
                    txtSqlPassword.Enabled = false;
                    break;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Clear current connection
            if (this.myConnection != null)
            {
                //If the connection is open, close it
                if (this.myConnection.State == ConnectionState.Open)
                {
                    this.myConnection.Close();
                }

                this.myConnection.ConnectionString = string.Empty;
            }

            //Close the log in form
            this.Close();
        }

        private void txtWindowsMachineName_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Windows Machine Name = "." is not allowed
            if (txtWindowsMachineName.Text.Length == 0)
            {
                if (e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
            }
        }

        private void txtSqlServerName_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Server name "." is not allowed
            if (txtSqlServerName.Text.Length == 0)
            {
                if (e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
            }
        }


    }
}
