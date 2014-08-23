using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

        int mode = 0;
        // 0 image mode
        // 1 sumbangan mode

        string[] images;
        int currImage;

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
                if (mode == 0)
                {
                    webBrowser1.Document.GetElementById("imgObj").InnerHtml = CreateImagePage();
                }
                else
                {
                    webBrowser1.Document.GetElementById("imgObj").InnerHtml = CreatePageTable();
                }
            };

            ExcelOleHelper.GetSheetRange("Laporan Keuangan$", sumbanganConnectionString, out sumbanganColCount, out sumbanganRowCount);
            images = Directory.GetFiles("files\\gbr Utama\\");
            currImage = 0;
            timer1.Enabled = true;
        }

        private void CreatePage()
        {
            try
            {
                webBrowser1.Navigate(Path.Combine(Directory.GetCurrentDirectory(), "sumbangan_page.html"));

                //string page = "";
                //using (StreamReader reader = new StreamReader("sumbangan_page.html"))
                //{
                //    page = reader.ReadToEnd();
                //    reader.Close();
                //}
                //
                //if (page == "")
                //    return;
                //
                //webBrowser1.Navigate("about:blank");
                //if (webBrowser1.Document != null)
                //{
                //    webBrowser1.Document.Write(string.Empty);
                //}
                //webBrowser1.DocumentText = page;
            }
            catch
            {
            }
        }

        private string CreatePageTable()
        {
            DataTable dt = SelectSumbangan();

            string table = "<table id=\"tabel_sumbangan\">";
            table +=
                "<thead>\r\n" +
                "    <tr>\r\n" +
                "        <td>TANGGAL</td>\r\n" +
                "        <td>NAMA</td>\r\n" +
                "        <td>ALAMAT</td>\r\n" +
                "        <td>SUMBANGAN (Rp)</td>\r\n" +
                "    </tr>\r\n" +
                "</thead>\r\n" +
                "<tbody>\r\n";
            table += "<tr class=\"ganjil\">";

            int j = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                table += "<td" + ((j == 3) ? " style=\"text-align:right;\"" : "") + ">" + dc.ColumnName + "</td>";
                j++;
            }
            int i = 0;
            table += "</tr>";
            foreach (DataRow dr in dt.Rows)
            {
                table += "<tr class=\"" + ((i % 2 == 0) ? "genap" : "ganjil") + "\">";
                j = 0;
                foreach (var cell in dr.ItemArray)
                {
                    table += "<td" + ((j == 3) ? " style=\"text-align:right;\"" : "") + ">" + cell.ToString() + "</td>";
                    j++;
                }
                table += "</tr>";
                i++;
            }
            table += "</tbody></table>";
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

        private string CreateImagePage()
        {
            if (images.Length > 0)
            {
                if (currImage < images.Length)
                {
                    return "<img style='width:100%; height:100%; position: absolute;' src='" + images[currImage++] + "' />";
                }
                else
                {
                    mode++;
                }
            }
            return "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    webBrowser1.Document.InvokeScript("doTrans", new object[] { CreateImagePage() });
                    break;
                case 1:
                    webBrowser1.Document.InvokeScript("doTrans", new object[] { CreatePageTable() });
                    break;
            };
        }
    }
}
