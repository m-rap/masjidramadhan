using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using MasjidRamadhan.Model;
using System.Globalization;

namespace MasjidRamadhan.UI
{
    public partial class ExcelChecker : Form
    {
        DataTable errorDt = new DataTable();

        public ExcelChecker()
        {
            InitializeComponent();
            errorDt.Columns.AddRange(
                new DataColumn[] {
                    new DataColumn("Description"),
                    new DataColumn("Row"),
                    new DataColumn("Column")
                }
            );
            monthComboBox.SelectedIndex = DateTime.Now.Month - 1;
            yearTextBox.Value = DateTime.Now.Year;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            fileTextBox.Text = openFileDialog1.FileName;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cols = colnamesTextBox.Text.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
                DataTable dt = ExcelOleHelper.ExecuteReader(fileTextBox.Text, sheetTextBox.Text, rangeTextBox.Text);
                if (cols.Length != dt.Columns.Count)
                    return;
                List<string> types = new List<string>();
                for (int i = 0; i < cols.Length; i++)
                {
                    string[] col = cols[i].Split(':');
                    if (col.Length < 2) continue;
                    dt.Columns[i].ColumnName = col[0];
                    types.Add(col[1]);
                }

                errorDt.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    for (int j = 0; j < cols.Length; j++)
                    {
                        switch (types[j])
                        {
                            case "DateTime":
                                DateTime dateTime;
                                double val;
                                bool isDouble = double.TryParse(row[j].ToString(), out val);
                                if (isDouble)
                                    dateTime = DateTime.FromOADate(val);
                                else if (!DateTime.TryParse(row[j].ToString(), out dateTime))
                                {
                                    DataRow r = errorDt.NewRow();
                                    r["Description"] = "Failed to parse DateTime.";
                                    r["Row"] = i.ToString();
                                    r["Column"] = j.ToString();
                                    errorDt.Rows.Add(r);
                                }
                                if (monthComboBox.SelectedIndex + 1 != dateTime.Month || yearTextBox.Value != dateTime.Year)
                                {
                                    DataRow r = errorDt.NewRow();
                                    r["Description"] = "Unexpected DateTime.";
                                    r["Row"] = i.ToString();
                                    r["Column"] = j.ToString();
                                    errorDt.Rows.Add(r);
                                }
                                break;
                            case "float":
                                try
                                {
                                    float f = float.Parse(row[j].ToString(), NumberStyles.Any);
                                }
                                catch
                                {
                                    DataRow r = errorDt.NewRow();
                                    r["Description"] = "Failed to parse float.";
                                    r["Row"] = i.ToString();
                                    r["Column"] = j.ToString();
                                    errorDt.Rows.Add(r);
                                }
                                break;
                        }
                    }
                }

                BindingSource bs1 = new BindingSource();
                bs1.DataSource = dt;
                validDgv.Columns.Clear();
                validDgv.DataSource = bs1;

                BindingSource bs2 = new BindingSource();
                bs2.DataSource = errorDt;
                errorDgv.Columns.Clear();
                errorDgv.DataSource = bs2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
