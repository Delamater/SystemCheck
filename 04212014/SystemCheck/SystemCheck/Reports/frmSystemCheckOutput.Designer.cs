namespace SystemCheck.Reports
{
    partial class frmSystemCheckOutput
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemCheckOutput));
            this.dtChecklistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsChecklist = new SystemCheck.dsChecklist();
            this.rvSystemCheck = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dtChecklistBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsChecklist)).BeginInit();
            this.SuspendLayout();
            // 
            // dtChecklistBindingSource
            // 
            this.dtChecklistBindingSource.DataMember = "dtChecklist";
            this.dtChecklistBindingSource.DataSource = this.dsChecklist;
            // 
            // dsChecklist
            // 
            this.dsChecklist.DataSetName = "dsChecklist";
            this.dsChecklist.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvSystemCheck
            // 
            this.rvSystemCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dtChecklistBindingSource;
            this.rvSystemCheck.LocalReport.DataSources.Add(reportDataSource1);
            this.rvSystemCheck.LocalReport.EnableHyperlinks = true;
            this.rvSystemCheck.LocalReport.ReportEmbeddedResource = "SystemCheck.Reports.rvSystemCheckOutput.rdlc";
            this.rvSystemCheck.Location = new System.Drawing.Point(0, 0);
            this.rvSystemCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rvSystemCheck.Name = "rvSystemCheck";
            this.rvSystemCheck.Size = new System.Drawing.Size(1056, 705);
            this.rvSystemCheck.TabIndex = 0;
            // 
            // frmSystemCheckOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 705);
            this.Controls.Add(this.rvSystemCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSystemCheckOutput";
            this.Text = "System Check Output";
            this.Load += new System.EventHandler(this.frmSystemCheckOutput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtChecklistBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsChecklist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvSystemCheck;
        private System.Windows.Forms.BindingSource dtChecklistBindingSource;
        private dsChecklist dsChecklist;
    }
}