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
        string[] columns;
        string[] types;
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

        private void loadButton_Click(object sender, EventArgs e)
        {
            DataTable dt = ExcelOleHelper.ExecuteReader(fileTextBox.Text, sheetTextBox.Text, rangeTextBox.Text);

            columns = colnamesTextBox.Text.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
            if (columns.Length != dt.Columns.Count)
                return;
            List<string> t = new List<string>();
            for (int i = 0; i < columns.Length; i++)
            {
                string[] col = columns[i].Split(':');
                if (col.Length < 2) continue;
                dt.Columns[i].ColumnName = col[0];
                t.Add(col[1]);
            }
            types = t.ToArray();

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = dt;
            validDgv.Columns.Clear();
            validDgv.DataSource = bs1;
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (validDgv.DataSource as BindingSource).DataSource as DataTable;

                errorDt.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    for (int j = 0; j < columns.Length; j++)
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
                                    AddError(i + 1, j + 1, "Failed to parse DateTime.");
                                }
                                if (monthComboBox.SelectedIndex + 1 != dateTime.Month || yearTextBox.Value != dateTime.Year)
                                {
                                    AddError(i + 1, j + 1, "Unexpected DateTime.");
                                }
                                break;
                            case "float":
                                try
                                {
                                    float f = float.Parse(row[j].ToString(), NumberStyles.Any);
                                }
                                catch
                                {
                                    AddError(i + 1, j + 1, "Failed to parse float.");
                                }
                                break;
                        }
                    }
                }

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

        private void AddError(int row, int column, string errorStr)
        {
            DataRow r = errorDt.NewRow();
            r["Description"] = errorStr;
            r["Row"] = row;
            r["Column"] = column;
            errorDt.Rows.Add(r);
        }
    }
}
