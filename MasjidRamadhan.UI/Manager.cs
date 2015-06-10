using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MasjidRamadhan.Model;

namespace MasjidRamadhan.UI
{
    public partial class Manager : Form
    {
        SqliteConnectionHelper connection;

        public Manager()
        {
            InitializeComponent();
            comboBox1.MouseWheel += new MouseEventHandler(comboBox1_MouseWheel);
            comboBox1.SelectedIndex = 0;
            monthComboBox.SelectedIndex = DateTime.Now.Month - 1;
            yearTextBox.Value = DateTime.Now.Year;
            connection = new SqliteConnectionHelper(ConfigurationManager.AppSettings["db_path"]);
        }

        void comboBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        void LoadTable()
        {
            try
            {
                Sumbangan sumbangan = new Sumbangan(connection);
                DateTime start = new DateTime(int.Parse(yearTextBox.Text), monthComboBox.SelectedIndex + 1, 1);
                DateTime end = start.AddMonths(1).Subtract(TimeSpan.FromDays(1));
                DataTable dt = sumbangan.Get(start, end, 0);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                sumbanganDgv.Columns.Clear();
                sumbanganDgv.DataSource = bs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void yearTextBox_ValueChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (SumbanganForm sumbanganForm = new SumbanganForm(new SumbanganForm.AddMode(), monthComboBox.SelectedIndex + 1, (int)yearTextBox.Value))
            {
                if (sumbanganForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTable();
                    sumbanganDgv.FirstDisplayedScrollingRowIndex = sumbanganDgv.Rows.Count - 1;
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            int sumbanganId = -1;
            int rowIndex = -1;
            foreach (DataGridViewCell cell in sumbanganDgv.SelectedCells)
            {
                rowIndex = cell.RowIndex;
                DataGridViewRow row = sumbanganDgv.Rows[rowIndex];
                if (int.TryParse(row.Cells["ID"].Value.ToString(), out sumbanganId))
                    break;
            }
            if (sumbanganId < 0)
                return;
            using (SumbanganForm sumbanganForm = new SumbanganForm(new SumbanganForm.EditMode(sumbanganId), monthComboBox.SelectedIndex + 1, (int)yearTextBox.Value))
            {
                if (sumbanganForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTable();
                    sumbanganDgv.FirstDisplayedScrollingRowIndex = rowIndex;
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apa Anda yakin menghapus data yang dipilih?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Sumbangan sumbangan = new Sumbangan(connection);
                foreach (DataGridViewCell cell in sumbanganDgv.SelectedCells)
                {
                    int sumbanganId;
                    DataGridViewRow row = sumbanganDgv.Rows[cell.RowIndex];
                    if (int.TryParse(row.Cells["ID"].Value.ToString(), out sumbanganId) && sumbanganId >= 0)
                        sumbangan.Delete(sumbanganId);
                }
                LoadTable();
            }
        }
    }
}
