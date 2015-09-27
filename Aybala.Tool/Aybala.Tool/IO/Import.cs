using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
namespace Aybala.Tool.IO
{
    public class Import
    {
        public static DataTable ImportExcel(string filePath) 
        {
            try
            {
                OleDbConnection conn = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + filePath + "';Extended Properties=Excel 12.0;");
                OleDbDataAdapter cmd = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", conn);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
               throw new Exception("Excel Okunamadı. Hata : " + ex.Message);
            }
        }

        public static DataTable ImportCsv(string filePath)
        {
            try
            {
                DataTable dt = new DataTable();
                List<string> columns = new List<string>();
                var reader = new CsvFileReader(filePath);
                bool first = true;
                string[] dataValues;
                string rowString;
                DataRow dr = null;
                while (reader.ReadRow(columns)) 
                {
                    rowString = string.Empty;
                    foreach (var item in columns)
                        rowString += item;
                    dataValues = rowString.Split(';');
                    for (int i = 0; i < dataValues.Length; i++)
                    {
                        if (first) 
                        {
                            dt.Columns.Add(dataValues[i]);
                        }
                        else
                        {
                            if (i == 0)
                                dr = dt.NewRow();
                            dr[i] = dataValues[i];
                            if (i == dataValues.Length - 1)
                                dt.Rows.Add(dr);
                        }
                    }
                    first = false;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("CSV Okunamadı. Hata : " + ex.Message);
            }
        }
    }
}
