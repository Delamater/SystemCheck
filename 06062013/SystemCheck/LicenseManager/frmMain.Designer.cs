namespace LicenseManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpDecryptedValues = new System.Windows.Forms.GroupBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.txtUserDomainName = new System.Windows.Forms.TextBox();
            this.txtMacID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpCheckLicense = new System.Windows.Forms.GroupBox();
            this.btnCheckLicenseFile = new System.Windows.Forms.Button();
            this.grpCustInfo = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputString = new System.Windows.Forms.TextBox();
            this.btnGenerateLicense = new System.Windows.Forms.Button();
            this.txtKeyFileLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpLicensedUntil = new System.Windows.Forms.DateTimePicker();
            this.dsLicenseInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsLicenseInfo = new LicenseManager.dsLicenseInfo();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpDecryptedValues.SuspendLayout();
            this.grpCheckLicense.SuspendLayout();
            this.grpCustInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsLicenseInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLicenseInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(832, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(99, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(99, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(99, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(125, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 490);
            this.tabControl1.TabIndex = 2;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.groupBox1);
            this.tpSettings.Location = new System.Drawing.Point(4, 25);
            this.tpSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpSettings.Size = new System.Drawing.Size(824, 461);
            this.tpSettings.TabIndex = 0;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpDecryptedValues);
            this.groupBox1.Controls.Add(this.grpCheckLicense);
            this.groupBox1.Controls.Add(this.grpCustInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(816, 453);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key Generation";
            // 
            // grpDecryptedValues
            // 
            this.grpDecryptedValues.Controls.Add(this.txtMachineName);
            this.grpDecryptedValues.Controls.Add(this.txtUserDomainName);
            this.grpDecryptedValues.Controls.Add(this.txtMacID);
            this.grpDecryptedValues.Controls.Add(this.label6);
            this.grpDecryptedValues.Controls.Add(this.label5);
            this.grpDecryptedValues.Controls.Add(this.label4);
            this.grpDecryptedValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDecryptedValues.Location = new System.Drawing.Point(4, 215);
            this.grpDecryptedValues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDecryptedValues.Name = "grpDecryptedValues";
            this.grpDecryptedValues.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDecryptedValues.Size = new System.Drawing.Size(808, 142);
            this.grpDecryptedValues.TabIndex = 11;
            this.grpDecryptedValues.TabStop = false;
            this.grpDecryptedValues.Text = "Decrypted Values";
            this.grpDecryptedValues.Visible = false;
            // 
            // txtMachineName
            // 
            this.txtMachineName.Location = new System.Drawing.Point(153, 87);
            this.txtMachineName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(621, 22);
            this.txtMachineName.TabIndex = 5;
            // 
            // txtUserDomainName
            // 
            this.txtUserDomainName.Location = new System.Drawing.Point(153, 52);
            this.txtUserDomainName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserDomainName.Name = "txtUserDomainName";
            this.txtUserDomainName.Size = new System.Drawing.Size(621, 22);
            this.txtUserDomainName.TabIndex = 4;
            // 
            // txtMacID
            // 
            this.txtMacID.Location = new System.Drawing.Point(153, 16);
            this.txtMacID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMacID.Name = "txtMacID";
            this.txtMacID.Size = new System.Drawing.Size(621, 22);
            this.txtMacID.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Machine Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "User Domain Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "MAC ID";
            // 
            // grpCheckLicense
            // 
            this.grpCheckLicense.Controls.Add(this.btnCheckLicenseFile);
            this.grpCheckLicense.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCheckLicense.Location = new System.Drawing.Point(4, 357);
            this.grpCheckLicense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCheckLicense.Name = "grpCheckLicense";
            this.grpCheckLicense.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCheckLicense.Size = new System.Drawing.Size(808, 92);
            this.grpCheckLicense.TabIndex = 2;
            this.grpCheckLicense.TabStop = false;
            this.grpCheckLicense.Text = "Check License";
            // 
            // btnCheckLicenseFile
            // 
            this.btnCheckLicenseFile.Location = new System.Drawing.Point(13, 25);
            this.btnCheckLicenseFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheckLicenseFile.Name = "btnCheckLicenseFile";
            this.btnCheckLicenseFile.Size = new System.Drawing.Size(169, 28);
            this.btnCheckLicenseFile.TabIndex = 0;
            this.btnCheckLicenseFile.Text = "Check License File";
            this.btnCheckLicenseFile.UseVisualStyleBackColor = true;
            this.btnCheckLicenseFile.Click += new System.EventHandler(this.btnCheckLicenseFile_Click);
            // 
            // grpCustInfo
            // 
            this.grpCustInfo.Controls.Add(this.button1);
            this.grpCustInfo.Controls.Add(this.label1);
            this.grpCustInfo.Controls.Add(this.txtInputString);
            this.grpCustInfo.Controls.Add(this.btnGenerateLicense);
            this.grpCustInfo.Controls.Add(this.txtKeyFileLocation);
            this.grpCustInfo.Controls.Add(this.label2);
            this.grpCustInfo.Controls.Add(this.label3);
            this.grpCustInfo.Controls.Add(this.dtpLicensedUntil);
            this.grpCustInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCustInfo.Location = new System.Drawing.Point(4, 19);
            this.grpCustInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCustInfo.Name = "grpCustInfo";
            this.grpCustInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCustInfo.Size = new System.Drawing.Size(808, 196);
            this.grpCustInfo.TabIndex = 1;
            this.grpCustInfo.TabStop = false;
            this.grpCustInfo.Text = "Customer Info";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 80);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Input String";
            // 
            // txtInputString
            // 
            this.txtInputString.Location = new System.Drawing.Point(13, 43);
            this.txtInputString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInputString.Name = "txtInputString";
            this.txtInputString.Size = new System.Drawing.Size(783, 22);
            this.txtInputString.TabIndex = 7;
            this.txtInputString.TextChanged += new System.EventHandler(this.txtInputString_TextChanged);
            // 
            // btnGenerateLicense
            // 
            this.btnGenerateLicense.Location = new System.Drawing.Point(472, 75);
            this.btnGenerateLicense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerateLicense.Name = "btnGenerateLicense";
            this.btnGenerateLicense.Size = new System.Drawing.Size(100, 28);
            this.btnGenerateLicense.TabIndex = 6;
            this.btnGenerateLicense.Text = "Generate Key";
            this.btnGenerateLicense.UseVisualStyleBackColor = true;
            this.btnGenerateLicense.Click += new System.EventHandler(this.btnGenerateLicense_Click);
            // 
            // txtKeyFileLocation
            // 
            this.txtKeyFileLocation.Location = new System.Drawing.Point(12, 142);
            this.txtKeyFileLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKeyFileLocation.Name = "txtKeyFileLocation";
            this.txtKeyFileLocation.Size = new System.Drawing.Size(705, 22);
            this.txtKeyFileLocation.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Licensed Until";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Key File Location";
            // 
            // dtpLicensedUntil
            // 
            this.dtpLicensedUntil.Location = new System.Drawing.Point(120, 80);
            this.dtpLicensedUntil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpLicensedUntil.Name = "dtpLicensedUntil";
            this.dtpLicensedUntil.Size = new System.Drawing.Size(343, 22);
            this.dtpLicensedUntil.TabIndex = 2;
            // 
            // dsLicenseInfoBindingSource
            // 
            this.dsLicenseInfoBindingSource.DataSource = this.dsLicenseInfo;
            this.dsLicenseInfoBindingSource.Position = 0;
            // 
            // dsLicenseInfo
            // 
            this.dsLicenseInfo.DataSetName = "dsLicenseInfo";
            this.dsLicenseInfo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 518);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpDecryptedValues.ResumeLayout(false);
            this.grpDecryptedValues.PerformLayout();
            this.grpCheckLicense.ResumeLayout(false);
            this.grpCustInfo.ResumeLayout(false);
            this.grpCustInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsLicenseInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLicenseInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource dsLicenseInfoBindingSource;
        private dsLicenseInfo dsLicenseInfo;
        private System.Windows.Forms.TextBox txtKeyFileLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpCustInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpLicensedUntil;
        private System.Windows.Forms.GroupBox grpCheckLicense;
        private System.Windows.Forms.Button btnCheckLicenseFile;
        private System.Windows.Forms.Button btnGenerateLicense;
        private System.Windows.Forms.TextBox txtInputString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpDecryptedValues;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.TextBox txtUserDomainName;
        private System.Windows.Forms.TextBox txtMacID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

