using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace SystemCheck
{
    class ExcelMgr
    {
        FileMgr _fileUtils = new FileMgr();
        Utilities.SchemaUtilities _schemaUtils = new Utilities.SchemaUtilities();

        private dsChecklist _dataSource = null;
        public dsChecklist DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }


        /// <summary>
        /// Exports a dataset to an Excel file. Excel will display, but it won't remain open.
        /// </summary>
        /// <param name="myDataset"></param>
        /// <returns>A string with the name of the full file name that was generated</returns>
        public string ExportToExcel(System.Data.DataSet myDataset)
        {
            string strFileName = "SystemCheckDataSet";
            string strFilePathToSave = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string strFullFileName = System.IO.Path.Combine(strFilePathToSave, strFileName);

            Microsoft.Office.Interop.Excel.Application oXl;
            Microsoft.Office.Interop.Excel.Workbook oWb;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRange;
            Microsoft.Office.Interop.Excel.Range oRangeHeader;

            // Start Excel and get Application Object
            oXl = new Microsoft.Office.Interop.Excel.Application();

            // Set some properties
            oXl.Visible = false;
            oXl.DisplayAlerts = false;

            // Get a new workbook
            oWb = oXl.Workbooks.Add(Missing.Value);

            foreach (System.Data.DataTable dt in myDataset.Tables)
            {
                if (_schemaUtils.IsSystemTable(dt.TableName) == true)
                {
                    //Do not add this table to the workbook as a worksheet
                    continue;
                }
                if (dt.Rows.Count > 0)
                {
                    // Get the active sheet
                    //oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWb.ActiveSheet;
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWb.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    oSheet.Name = SwitchExcelSheetName(dt.TableName);

                    //Process the DataTable
                    int rowCount = 1;
                    foreach (System.Data.DataRow dr in dt.Rows)
                    {
                        rowCount += 1;
                        for (int i = 1; i < dt.Columns.Count + 1; i++)
                        {
                            // Add the header the first time through
                            if (rowCount == 2)
                            {
                                oSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                            }
                            oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
                        }
                    }


                    // Resize the columns
                    //oRange = oSheet.get_Range(oSheet.Cells[1,1], oSheet.Cells[rowCount, dt.Columns.Count]);
                    oRange = oSheet.Range[oSheet.Cells[1, 1], oSheet.Cells[rowCount, dt.Columns.Count]];


                    //Format as table
                    oRange.Worksheet.ListObjects.AddEx
                        (Microsoft.Office.Interop.Excel.XlListObjectSourceType.xlSrcRange, 
                        oRange, 
                        System.Type.Missing, 
                        Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, 
                        System.Type.Missing).Name = oSheet.Name;
                    oRange.Select();
                    oRange.Worksheet.ListObjects[oSheet.Name].TableStyle = "TableStyleDark2";

                    oRange.EntireColumn.AutoFit();
                    //oRangeHeader.EntireColumn.AutoFit();
                    
                }
            }

            // Save the sheet and close
            oSheet = null;
            oRange = null;
            
            DialogResult dlgResult = new DialogResult();
            SaveFileDialog saveDlg = 
                _fileUtils.SaveFile(
                    strFullFileName, 
                    true, 
                    "Excel Files|xls", 
                    "xls", 
                    false, 
                    true, 
                    true, 
                    true);
            dlgResult = saveDlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                //Go ahead and save the workbook
                oWb.SaveAs(saveDlg.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value);
            }

            oWb.Close(Missing.Value,Missing.Value,Missing.Value);
            oWb = null;
            oXl.Quit();

            // Clean up
            // Note: When in release mode, this does the trick
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            return strFullFileName;
        }

        private string SwitchExcelSheetName(string SheetName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Replace(" ", "");

            if (SheetName.Length<31)
            {
                sb.Append(SheetName.Substring(0,SheetName.Length));
            }
            else
            {
                sb.Append(SheetName.Substring(0,31));
            }
            
            
            //Cannot contain special characters
            sb.Replace(@"\", string.Empty);
            sb.Replace("/", string.Empty);
            sb.Replace(":", string.Empty);
            sb.Replace("*", string.Empty);
            sb.Replace("?", string.Empty);
            sb.Replace("[", string.Empty);
            sb.Replace("]", string.Empty);

            return sb.ToString();
            
        }

        private string GenerateFileName(string context)
        {
            return context + "_" + DateTime.Now.ToString("yyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString();
        }
    }
}
