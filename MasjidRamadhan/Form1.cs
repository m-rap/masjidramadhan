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
using Excel = Microsoft.Office.Interop.Excel;

namespace MasjidRamadhan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
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

        private void CreateExcel()
        {
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=generated.xlsx;" +
                               "Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "CREATE TABLE [table1] (id INT, name VARCHAR, datecol DATE);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO [table1](id,name,datecol) VALUES(1,'AAAA','2014-01-01');";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
