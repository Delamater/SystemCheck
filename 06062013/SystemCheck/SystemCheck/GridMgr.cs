using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SystemCheck
{
    class GridMgr
    {
        dsChecklist.dtChecklistDataTable dt = new dsChecklist.dtChecklistDataTable();

        public void ApplyGridStyle(DataGridView dgv)
        {


            //if (dgv.Rows.Count > 0)
            //{
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToOrderColumns = true;
                dgv.AllowUserToResizeColumns = true;
                dgv.AllowUserToResizeRows = true;
                dgv.AllowDrop = false;

                dgv.RowsDefaultCellStyle.BackColor = Color.LightYellow;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
                dgv.ReadOnly = true;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
            //}
        }

        public void HideResultsDataGridViewColumns(DataGridView dgv)
        {
            
            dgv.Columns[dt.IsForOutputColumn.ColumnName].Visible = false;
            dgv.Columns[dt.IsExecuteColumn.ColumnName].Visible = false;
            dgv.Columns[dt.CodeTypeColumn.ColumnName].Visible = false;
            dgv.Columns[dt.WeightColumn.ColumnName].Visible = false;
            dgv.Columns[dt.CodeToRunColumn.ColumnName].Visible = false;
        }

    }
}
