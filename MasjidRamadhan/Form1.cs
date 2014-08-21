using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Transitions;
using System.Data.OleDb;
using System.Threading;
using System.Globalization;
using System.IO;

namespace MasjidRamadhan
{
    public partial class Form1 : Form
    {
        static string connectionString1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=generated.xlsx;" +
                                          "Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
        static string sumbanganDataConnectionString =
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SUMBANGAN MASJID.xls;" +
            "Extended Properties=\"Excel 8.0;HDR=YES\"";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string page = "";
                using (StreamReader reader = new StreamReader("sumbangan_page.html"))
                {
                    page = reader.ReadToEnd();
                    reader.Close();
                }

                if (page == "")
                    return;

                string table = "<table>";
                DataTable dt = SelectSumbangan(0, 20);
                table += "<tr>";
                foreach (DataColumn dc in dt.Columns)
                {
                    table += "<td>" + dc.ColumnName + "</td>";
                }
                table += "</tr>";
                foreach (DataRow dr in dt.Rows)
                {
                    table += "<tr>";
                    foreach (var cell in dr.ItemArray)
                    {
                        table += "<td>" + cell.ToString() + "</td>";
                    }
                    table += "</tr>";
                }
                table += "</table>";

                page = page.Replace("${table}", table);

                webBrowser1.Navigate("about:blank");
                if (webBrowser1.Document != null)
                {
                    webBrowser1.Document.Write(string.Empty);
                }
                webBrowser1.DocumentText = page;
            }
            catch
            {
            }
            /*
            webBrowser1.DocumentText =
                "<HEAD>\r\n" +
                "<SCRIPT>                    \r\n" +
                "var startImage =\"fruit.gif\";\r\n" +
                "var endImage=\"mouse.gif\";   \r\n" +
                "function doTrans() {        \r\n" +
                "                            \r\n" +
                "        imgObj.filters[0].apply();                \r\n" +
                "        if (oImg.src.indexOf(startImage)!=-1) {   \r\n" +
                "            oImg.src = endImage;                  \r\n" +
                "            imgObj.style.backgroundColor = \"gold\";\r\n" +
                "            imgObjText.innerHTML =             \"<BR><B>Second Page</B><BR><BR>Using the <B>play</B> method reveals the changes in the SPAN element content.\"        }\r\n" +
                "        else {                                                                                                                                                       \r\n" +
                "            oImg.src = startImage;                                                                                                                                   \r\n" +
                "            imgObj.style.backgroundColor = \"skyblue\";                                                                                                                \r\n" +
                "            imgObjText.innerHTML =             \"<BR><b>First Page</b><BR><BR>Using the <B>apply</B> method prepares this SPAN element for content changes.\"        } \r\n" +
                "        imgObj.filters[0].play();                                                                                                                                    \r\n" +
                "}                                                                                                                                                                    \r\n" +
                "</SCRIPT>                                                                                                                                                            \r\n" +
                "</HEAD>                                                                                                                                                              \r\n" +
                "<BODY>                                                                                                                                                               \r\n" +
                "<SPAN style=\"FILTER: progid:DXImageTransform.Microsoft.RadialWipe(wipestyle=CLOCK); BACKGROUND-COLOR: skyblue; PADDING-LEFT: 13px; WIDTH: 305px; PADDING-RIGHT: 10px; FONT: 9pt/1.3 verdana; HEIGHT: 150px; COLOR: black\" id=imgObj><IMG style=\"MARGIN: 8px\" id=oImg align=left src=\"fruit.gif\">\r\n" +
                "<DIV id=imgObjText><BR><B>First Page</B><BR><BR>Using the <B>apply</B> method prepares this SPAN element for content changes.</DIV></SPAN><BR><BR>\r\n" +
                "<BUTTON onclick=\"doTrans()\">Play Transition</BUTTON>\r\n" +
                "</BODY>\r\n";
             */
        }

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private List<string> GetSheetList(string connectionString)
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

        private DataTable SelectSumbangan(int offset, int limit)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(sumbanganDataConnectionString))
                {
                    conn.Open();

                    int colCount, rowCount;
                    GetSheetRange("Laporan Keuangan$", conn, out colCount, out rowCount);

                    if (offset < rowCount)
                    {
                        string rangeString = GetRangeString(offset, limit, colCount, rowCount);
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Laporan Keuangan$" + rangeString + "]", conn);
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);
                    }

                    conn.Close();

                    return dt;
                }
            }
            catch
            {
                return dt;
            }
        }

        private static string GetRangeString(int offset, int limit, int colCount, int rowCount)
        {
            int lastRow = offset + limit;
            if (lastRow > rowCount)
            {
                lastRow = rowCount;
            }
            string rangeString = "A" + (offset + 1) + ":" + ((char)('A' + colCount - 1)) + lastRow;
            return rangeString;
        }

        private void GetSheetRange(string sheetName, out int colCount, out int rowCount)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(sumbanganDataConnectionString))
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

        private static void GetSheetRange(string sheetName, OleDbConnection conn, out int colCount, out int rowCount)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            colCount = dt.Columns.Count;
            rowCount = dt.Rows.Count;
        }
    }
}
