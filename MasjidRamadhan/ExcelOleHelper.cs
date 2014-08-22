using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace MasjidRamadhan
{
    public class ExcelOleHelper
    {
        public static string GetRangeString(int offset, int limit, int colCount, int rowCount)
        {
            int lastRow = offset + limit;
            if (lastRow > rowCount)
            {
                lastRow = rowCount;
            }
            string rangeString = "A" + (offset + 1) + ":" + ((char)('A' + colCount - 1)) + lastRow;
            return rangeString;
        }

        public static void GetSheetRange(string sheetName, string connectionString, out int colCount, out int rowCount)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    GetSheetRange(sheetName, conn, out colCount, out rowCount);

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GetSheetRange(string sheetName, OleDbConnection conn, out int colCount, out int rowCount)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            colCount = dt.Columns.Count;
            rowCount = dt.Rows.Count;
        }

        public static List<string> GetSheetList(string connectionString)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;

                    DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    List<string> result = new List<string>();
                    foreach (DataRow dr in dtSheet.Rows)
                    {
                        result.Add(dr["TABLE_NAME"].ToString());
                    }

                    conn.Close();

                    return result;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
