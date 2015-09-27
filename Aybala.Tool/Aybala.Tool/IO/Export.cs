using System;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
namespace Aybala.Tool.IO
{
    public class Export
    {
        private Export() { }

        public static void ExportToCsv(System.Web.HttpResponse response, DataTable exportData, string exportName)
        {
            response.Clear();
            byte[] BOM = { 0xEF, 0xBB, 0xBF }; // UTF-8 BOM karakterleri
            response.BinaryWrite(BOM);
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn dc in exportData.Columns)
            {
                sb.Append((char)(34) + dc.ColumnName + (char)(34));
                sb.Append(";");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendLine();
            foreach (DataRow dr in exportData.Rows)
            {

                for (int i = 0; i < exportData.Columns.Count; i++)
                {
                    sb.Append(dr[i].ToString().Replace(';', ',').Replace('\n', ' ').Replace('\t', ' ').Replace('\r', ' '));
                    sb.Append(";");
                }
                sb = sb.Remove(sb.Length - 1, 1);
                sb.AppendLine();
            }
            response.ContentType = "text/csv";
            response.AppendHeader("Content-Disposition", "attachment; filename=" + exportName + ".csv");
            response.Write(sb.ToString());
            response.End();

        }

        public static bool ExportToCsv(DataTable exportData)
        {
            bool result = false;
            try
            {
                StringBuilder sbDelimited = new StringBuilder();
                foreach (DataColumn item in exportData.Columns)
                {
                    sbDelimited.Append((char)(34) + item.ColumnName + (char)(34));
                    sbDelimited.Append(";");
                }
                sbDelimited.Remove(sbDelimited.Length - 1, 1);
                sbDelimited.AppendLine();
                for (int i = 0; i < exportData.Rows.Count; i++)
                {
                    foreach (DataColumn item in exportData.Columns)
                    {
                        sbDelimited.Append((char)(34) + exportData.Rows[i][item.ColumnName].ToString() + (char)(34));
                        sbDelimited.Append(";");
                    }
                    sbDelimited.Remove(sbDelimited.Length - 1, 1);
                    sbDelimited.AppendLine();
                }

                System.Windows.Forms.SaveFileDialog fileDialog = new System.Windows.Forms.SaveFileDialog();
                fileDialog.Filter = "csv Dosyaları (*.csv)|*.csv";

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(fileDialog.FileName, false, System.Text.Encoding.GetEncoding(1254));
                    file.Write(sbDelimited);
                    file.Close();
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Dosya Export Edilemedi. Hata : " + ex.Message);
            }
            return result;
        }

        public static void ExportToExcel(System.Web.HttpResponse response, DataTable exportData, string exportName)
        {
            string attachment = "attachment; filename=" + exportName + ".xls";
            response.ClearContent();
            response.AddHeader("content-disposition", attachment);
            response.ContentType = "application/vnd.ms-excel";
            response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
            response.Charset = "windows-1254";
            string tab = "";
            foreach (DataColumn dc in exportData.Columns)
            {
                response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            response.Write("\n");
            foreach (DataRow dr in exportData.Rows)
            {
                tab = "";
                for (int i = 0; i < exportData.Columns.Count; i++)
                {
                    response.Write(tab + (string.IsNullOrEmpty(dr[i].ToString()) ? "-" : dr[i].ToString().Replace("\t", "").Replace("\r", "").Replace("\n", "")));
                    tab = "\t";
                }
                response.Write("\n");
            }
            response.End();
        }

        public static bool ExportToExcel(DataTable exportData)
        {
            bool result = false;
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                for (int i = 0; i < exportData.Rows.Count; i++)
                    for (int j = 0; j < exportData.Columns.Count; j++)
                        xlWorkSheet.Cells[i + 1, j + 1] = exportData.Rows[j][i];

                System.Windows.Forms.SaveFileDialog fileDialog = new System.Windows.Forms.SaveFileDialog();
                fileDialog.Filter = "xlsx ve xls Dosyaları (*.xlsx,*.xls)|*.xlsx,*xls";

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    xlWorkBook.SaveAs(fileDialog.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                }
                result = true;
                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
            }
            catch (Exception ex)
            { throw new Exception("Excel Oluşturulamadı. Hata : " + ex.Message); }
            return result;
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw new Exception("Nesne Release Edilemedi. Hata : " + ex.Message);
            }
            finally { GC.Collect(); }
        }
    }
}
