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

        // 0 image mode
        // 1 sumbangan mode
        // 2 saldo mode
        int mode = 2;

        List<string> images;
        int currImage;

        List<string> images_bawah1;
        int currImage_bawah1;

        List<string> images_bawah2;
        int currImage_bawah2;

        List<string> images_bawah3;
        int currImage_bawah3;

        List<string> images_bawah4;
        int currImage_bawah4;

        List<string> images_bawah5;
        int currImage_bawah5;

        int sumbanganOffset = 0;
        const int sumbanganLimit = 10;
        int sumbanganColCount, sumbanganRowCount;
        private List<string> teksList;
        private int currentTeks;
        private Video video;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GoFullscreen(true);

            timer_panelBesar.Enabled = true;
            timer_teksBerjalan.Enabled = true;
            timer_panelBawah1.Enabled = true;

            ExcelOleHelper.GetSheetRange("Laporan Keuangan$", sumbanganConnectionString, out sumbanganColCount, out sumbanganRowCount);
            
            images = Directory.GetFiles("files\\gbr Utama\\").ToList();
            currImage = 0;
            images_bawah1 = Directory.GetFiles("files\\gbr1\\").ToList();
            currImage_bawah1 = 0;
            images_bawah2 = Directory.GetFiles("files\\gbr2\\").ToList();
            currImage_bawah2 = 0;
            images_bawah3 = Directory.GetFiles("files\\gbr3\\").ToList();
            currImage_bawah3 = 0;
            images_bawah4 = Directory.GetFiles("files\\gbr4\\").ToList();
            currImage_bawah4 = 0;
            images_bawah5 = Directory.GetFiles("files\\gbr5\\").ToList();
            currImage_bawah5 = 0;

            CreatePage();

            Point loc = label_berjalan.Location;
            loc.X = panel2.Size.Width;
            label_berjalan.Location = loc;
            ReadTeks();
            currentTeks = 0;
            try
            {
                label_berjalan.Text = teksList[currentTeks];
            }
            catch
            {
            }

            try
            {
                video = new Video("files\\video\\Video Mushola.wmv");
                video.Owner = panel_video;
                video.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ":" + ex.StackTrace);
            }
        }

        private void ReadTeks()
        {
            try
            {
                using (StreamReader reader = new StreamReader("files\\teks\\txt1.txt"))
                {
                    teksList = new List<string>();
                    while (!reader.EndOfStream)
                        teksList.Add(reader.ReadLine());
                }
            }
            catch
            {
            }
        }

        private void CreatePage()
        {
            try
            {
                string pagePath = Path.Combine(Directory.GetCurrentDirectory(), "page_bawah.html");
                webBrowser_besar.Navigate (Path.Combine(Directory.GetCurrentDirectory(), "sumbangan_page.html"));
                webBrowser_bawah1.Navigate(pagePath);
                webBrowser_bawah2.Navigate(pagePath);
                webBrowser_bawah3.Navigate(pagePath);
                webBrowser_bawah4.Navigate(pagePath);
                webBrowser_bawah5.Navigate(pagePath);

                webBrowser_besar.DocumentCompleted += (ws, we) =>
                {
                    webBrowser_besar.Document.GetElementById("imgObj").InnerHtml = InnerHtml();
                };
                //webBrowser_bawah1.DocumentCompleted += (ws, we) =>
                //{
                //    webBrowser_bawah1.Document.GetElementById("imgObj").InnerHtml = ShowImage(ref images_bawah1, ref currImage_bawah1);
                //};
                //webBrowser_bawah2.DocumentCompleted += (ws, we) =>
                //{
                //    webBrowser_bawah2.Document.GetElementById("imgObj").InnerHtml = ShowImage(ref images_bawah2, ref currImage_bawah2);
                //};
                //webBrowser_bawah3.DocumentCompleted += (ws, we) =>
                //{
                //    webBrowser_bawah3.Document.GetElementById("imgObj").InnerHtml = ShowImage(ref images_bawah3, ref currImage_bawah3);
                //};
                //webBrowser_bawah4.DocumentCompleted += (ws, we) =>
                //{
                //    webBrowser_bawah4.Document.GetElementById("imgObj").InnerHtml = ShowImage(ref images_bawah4, ref currImage_bawah4);
                //};
                //webBrowser_bawah5.DocumentCompleted += (ws, we) =>
                //{
                //    webBrowser_bawah5.Document.GetElementById("imgObj").InnerHtml = ShowImage(ref images_bawah5, ref currImage_bawah5);
                //};
            }
            catch
            {
            }
        }

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                SelectScreenForm selectScreenForm = new SelectScreenForm();
                if (DialogResult.OK == selectScreenForm.ShowDialog())
                {
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    this.Bounds = selectScreenForm.SelectedScreen.Bounds;
                }
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
                    if (sumbanganOffset >= sumbanganRowCount)
                    {
                        return dt;
                    }

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

                    conn.Close();

                    return dt;
                }
            }
            catch
            {
                return null;
            }
        }

        private static string ShowImage(ref List<string> images, ref int currImage)
        {
            lock (images)
            {
                if (currImage >= images.Count)
                    currImage = 0;
                string imgTag = "<img class=\"midvertical\" src='" + images[currImage] + "' />";

                string format;
                do
                {
                    currImage = (currImage + 1) % images.Count;
                    format = images[currImage].Substring(images[currImage].LastIndexOf('.') + 1).ToLower();
                } while (format != "jpg");
                    
                return imgTag;
            }
        }

        private string ShowTabelSumbangan()
        {
            if (sumbanganOffset >= sumbanganRowCount)
            {
                sumbanganOffset = 0;
                NextMode();
                return InnerHtml();
            }

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

        private string ShowSaldo()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(sumbanganConnectionString))
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Pengeluaran$H4:H7]", conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    float temp;
                    string terima, keluar, saldo;

                    if (float.TryParse(dt.Rows[0].ItemArray[0].ToString(), out temp))
                        terima = temp.ToString("N2");
                    else
                        terima = "";
                    if (float.TryParse(dt.Rows[1].ItemArray[0].ToString(), out temp))
                        keluar = temp.ToString("N2");
                    else
                        keluar = "";
                    if (float.TryParse(dt.Rows[2].ItemArray[0].ToString(), out temp))
                        saldo = temp.ToString("N2");
                    else
                        saldo = "";

                    string result =
                        "<div id=\"div_saldo\">\r\n" +
                        "</div>\r\n" +
                        "<table id=\"tabel_saldo\">\r\n" +
                        "<tr>\r\n" +
                        "    <td>Total Seluruh Penerimaan</td>\r\n" +
                        "    <td>:</td>\r\n" +
                        "    <td style=\"text-align: right;\">" + terima + "</td>\r\n" +
                        "</tr>\r\n" +
                        "<tr>\r\n" +
                        "    <td>Total Seluruh Pengeluaran</td>\r\n" +
                        "    <td>:</td>\r\n" +
                        "    <td>" + keluar + "</td>\r\n" +
                        "</tr>\r\n" +
                        "<tr>\r\n" +
                        "    <td>Saldo</td>\r\n" +
                        "    <td>:</td>\r\n" +
                        "    <td style=\"text-align: right;\">" + saldo + "</td>\r\n" +
                        "</tr>\r\n" +
                        "</table>";
                    
                    conn.Close();

                    NextMode();

                    return result;
                }
            }
            catch
            {
                return "";
            }
        }

        private void NextMode()
        {
            mode++;
            if (mode > 2)
                mode = 0;
        }

        private void timer_panelBesar_Tick(object sender, EventArgs e)
        {
            webBrowser_besar.Document.InvokeScript("doTrans", new object[] { InnerHtml() });
        }

        private string InnerHtml()
        {
            switch (mode)
            {
                case 0:
                    if (currImage < images.Count)
                        return ShowImage(ref images, ref currImage);
                    else
                    {
                        NextMode();
                        return InnerHtml();
                    }
                case 2:
                    return ShowTabelSumbangan();
                case 1:
                    return ShowSaldo();
                default:
                    return "";
            }
        }

        private void timer_teksBerjalan_Tick(object sender, EventArgs e)
        {
            Point loc = label_berjalan.Location;
            if (loc.X + label_berjalan.Size.Width < 0)
            {
                loc.X = panel2.Size.Width;
                ReadTeks();
                currentTeks = (currentTeks + 1) % teksList.Count;
                label_berjalan.Text = teksList[currentTeks];
            }
            else
                loc.X -= 5;
            label_berjalan.Location = loc;
        }

        private void timer_panelBawah1_Tick(object sender, EventArgs e)
        {
            webBrowser_bawah1.Document.InvokeScript("doTrans", new object[] { ShowImage(ref images_bawah1, ref currImage_bawah1) });
            
            if (!timer_panelBawah2.Enabled)
                timer_panelBawah2.Enabled = true;
        }

        private void timer_panelBawah2_Tick(object sender, EventArgs e)
        {
            webBrowser_bawah2.Document.InvokeScript("doTrans", new object[] { ShowImage(ref images_bawah2, ref currImage_bawah2) });
            
            if (!timer_panelBawah3.Enabled)
                timer_panelBawah3.Enabled = true;
        }

        private void timer_panelBawah3_Tick(object sender, EventArgs e)
        {
            webBrowser_bawah3.Document.InvokeScript("doTrans", new object[] { ShowImage(ref images_bawah3, ref currImage_bawah3) });

            if (!timer_panelBawah4.Enabled)
                timer_panelBawah4.Enabled = true;
        }

        private void timer_panelBawah4_Tick(object sender, EventArgs e)
        {
            webBrowser_bawah4.Document.InvokeScript("doTrans", new object[] { ShowImage(ref images_bawah4, ref currImage_bawah4) });

            if (!timer_panelBawah5.Enabled)
                timer_panelBawah5.Enabled = true;
        }

        private void timer_panelBawah5_Tick(object sender, EventArgs e)
        {
            webBrowser_bawah5.Document.InvokeScript("doTrans", new object[] { ShowImage(ref images_bawah5, ref currImage_bawah5) });
        }

        bool isFullScreen = false;
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                isFullScreen = !isFullScreen;
                GoFullscreen(isFullScreen);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                isFullScreen = !isFullScreen;
                GoFullscreen(isFullScreen);
            }
        }
    }
}
