namespace SystemCheck
{
    partial class ctlRunLog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbarCheckProgress = new System.Windows.Forms.ProgressBar();
            this.dsChecklist1 = new SystemCheck.dsChecklist();
            this.dtRunLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvRunLog = new System.Windows.Forms.DataGridView();
            this.errorValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executionStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scriptNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRunLog = new System.Windows.Forms.GroupBox();
            this.errorDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsChecklist1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRunLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRunLog)).BeginInit();
            this.grpRunLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbarCheckProgress
            // 
            this.pbarCheckProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbarCheckProgress.Location = new System.Drawing.Point(0, 377);
            this.pbarCheckProgress.Name = "pbarCheckProgress";
            this.pbarCheckProgress.Size = new System.Drawing.Size(700, 23);
            this.pbarCheckProgress.TabIndex = 2;
            // 
            // dsChecklist1
            // 
            this.dsChecklist1.DataSetName = "dsChecklist";
            this.dsChecklist1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtRunLogBindingSource
            // 
            this.dtRunLogBindingSource.DataMember = "dtRunLog";
            this.dtRunLogBindingSource.DataSource = this.dsChecklist1;
            // 
            // dgvRunLog
            // 
            this.dgvRunLog.AutoGenerateColumns = false;
            this.dgvRunLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRunLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.runIDDataGridViewTextBoxColumn,
            this.scriptNameDataGridViewTextBoxColumn,
            this.loginNameDataGridViewTextBoxColumn,
            this.executionStartDataGridViewTextBoxColumn,
            this.errorValueDataGridViewTextBoxColumn});
            this.dgvRunLog.DataSource = this.dtRunLogBindingSource;
            this.dgvRunLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRunLog.Location = new System.Drawing.Point(3, 16);
            this.dgvRunLog.Name = "dgvRunLog";
            this.dgvRunLog.Size = new System.Drawing.Size(694, 381);
            this.dgvRunLog.TabIndex = 0;
            // 
            // errorValueDataGridViewTextBoxColumn
            // 
            this.errorValueDataGridViewTextBoxColumn.DataPropertyName = "ErrorValue";
            this.errorValueDataGridViewTextBoxColumn.HeaderText = "ErrorValue";
            this.errorValueDataGridViewTextBoxColumn.Name = "errorValueDataGridViewTextBoxColumn";
            // 
            // executionStartDataGridViewTextBoxColumn
            // 
            this.executionStartDataGridViewTextBoxColumn.DataPropertyName = "ExecutionStart";
            this.executionStartDataGridViewTextBoxColumn.HeaderText = "ExecutionStart";
            this.executionStartDataGridViewTextBoxColumn.Name = "executionStartDataGridViewTextBoxColumn";
            // 
            // loginNameDataGridViewTextBoxColumn
            // 
            this.loginNameDataGridViewTextBoxColumn.DataPropertyName = "LoginName";
            this.loginNameDataGridViewTextBoxColumn.HeaderText = "LoginName";
            this.loginNameDataGridViewTextBoxColumn.Name = "loginNameDataGridViewTextBoxColumn";
            // 
            // scriptNameDataGridViewTextBoxColumn
            // 
            this.scriptNameDataGridViewTextBoxColumn.DataPropertyName = "ScriptName";
            this.scriptNameDataGridViewTextBoxColumn.HeaderText = "ScriptName";
            this.scriptNameDataGridViewTextBoxColumn.Name = "scriptNameDataGridViewTextBoxColumn";
            // 
            // runIDDataGridViewTextBoxColumn
            // 
            this.runIDDataGridViewTextBoxColumn.DataPropertyName = "RunID";
            this.runIDDataGridViewTextBoxColumn.HeaderText = "RunID";
            this.runIDDataGridViewTextBoxColumn.Name = "runIDDataGridViewTextBoxColumn";
            // 
            // grpRunLog
            // 
            this.grpRunLog.Controls.Add(this.dgvRunLog);
            this.grpRunLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRunLog.Location = new System.Drawing.Point(0, 0);
            this.grpRunLog.Name = "grpRunLog";
            this.grpRunLog.Size = new System.Drawing.Size(700, 400);
            this.grpRunLog.TabIndex = 1;
            this.grpRunLog.TabStop = false;
            this.grpRunLog.Text = "Run Log";
            // 
            // errorDescDataGridViewTextBoxColumn
            // 
            this.errorDescDataGridViewTextBoxColumn.DataPropertyName = "ErrorDesc";
            this.errorDescDataGridViewTextBoxColumn.HeaderText = "ErrorDesc";
            this.errorDescDataGridViewTextBoxColumn.Name = "errorDescDataGridViewTextBoxColumn";
            // 
            // ctlRunLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbarCheckProgress);
            this.Controls.Add(this.grpRunLog);
            this.Name = "ctlRunLog";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.RunLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsChecklist1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRunLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRunLog)).EndInit();
            this.grpRunLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn sPIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.ProgressBar pbarCheckProgress;
        private dsChecklist dsChecklist1;
        private System.Windows.Forms.BindingSource dtRunLogBindingSource;
        private System.Windows.Forms.DataGridView dgvRunLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn runIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scriptNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn executionStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox grpRunLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorDescDataGridViewTextBoxColumn;
    }
}
