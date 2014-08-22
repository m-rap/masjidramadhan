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
using Microsoft.DirectX.AudioVideoPlayback;

namespace MasjidRamadhan
{
    public partial class Form1 : Form
    {
        static string sumbanganConnectionString =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SUMBANGAN MASJID.xls;" +
            "Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

        int sumbanganOffset = 0;
        const int sumbanganLimit = 10;
        int sumbanganColCount, sumbanganRowCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GoFullscreen(true);

            CreatePage();
            webBrowser1.DocumentCompleted += (ws, we) =>
            {
                webBrowser1.Document.GetElementById("imgObj").InnerHtml = CreatePageTable();
            };

            ExcelOleHelper.GetSheetRange("Laporan Keuangan$", sumbanganConnectionString, out sumbanganColCount, out sumbanganRowCount);
            timer1.Enabled = true;
        }

        private void CreatePage()
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
        }

        private string CreatePageTable()
        {
            DataTable dt = SelectSumbangan();

            string table = "<table>";
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
            return table;
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

        private DataTable SelectSumbangan()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(sumbanganConnectionString))
                {
                    conn.Open();

                    DataTable dt = new DataTable();
                    if (sumbanganOffset < sumbanganRowCount)
                    {
                        string rangeString = ExcelOleHelper.GetRangeString(sumbanganOffset, sumbanganRowCount - sumbanganLimit, sumbanganColCount, sumbanganRowCount);
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Laporan Keuangan$" + rangeString + "]", conn);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        int i = 0, count = 0;
                        bool isFirst = true;
                        while (reader.Read() && count < sumbanganLimit)
                        {
                            DateTime dateValue;
                            bool isDate = DateTime.TryParse(reader[1].ToString(), out dateValue);
                            if (isDate)
                            {
                                string dateString = dateValue.ToString("dd/MM/yyyy");
                                float uang;
                                string uangString;
                                if (float.TryParse(reader[4].ToString(), out uang))
                                {
                                    uangString = uang.ToString("N2");
                                }
                                else
                                {
                                    uangString = reader[4].ToString();
                                }

                                if (isFirst)
                                {
                                    dt.Columns.AddRange(new DataColumn[] {
                                        new DataColumn(dateString),
                                        new DataColumn(reader[2].ToString()),
                                        new DataColumn(reader[3].ToString()),
                                        new DataColumn(uangString)
                                    });
                                    isFirst = false;
                                }
                                else
                                {
                                    DataRow row = dt.NewRow();
                                    row[0] = dateString;
                                    row[1] = reader[2].ToString();
                                    row[2] = reader[3].ToString();
                                    row[3] = uangString;
                                    dt.Rows.Add(row);
                                }
                                count++;
                            }
                            i++;
                        }
                        sumbanganOffset += i;
                        if (sumbanganOffset > sumbanganRowCount)
                            sumbanganOffset = 0;
                    }

                    conn.Close();

                    return dt;
                }
            }
            catch
            {
                return null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string table = CreatePageTable();
            object[] args = new object[] { table };
            webBrowser1.Document.InvokeScript("doTrans", args);
        }
    }
}
