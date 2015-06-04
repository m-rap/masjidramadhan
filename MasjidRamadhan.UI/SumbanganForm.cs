using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using MasjidRamadhan.Model;

namespace MasjidRamadhan.UI
{
    public partial class SumbanganForm : Form
    {
        FormMode mode;

        public SumbanganForm(FormMode mode, int month, int year)
        {
            InitializeComponent();
            this.mode = mode;
            mode.Init(month, year);
            mode.F = this;

            contohLabel.Text =
                "Contoh:\n" +
                "\"Seratus ribu rupiah\" tulis dengan 100000\n" +
                "\"Seratus ribu koma empat lima rupiah\" tulis dengan " + (100000.45).ToString();

            AutoCompleteStringCollection namaCollection = new AutoCompleteStringCollection();
            namaCollection.AddRange(Person.NamaCache.ToArray());
            namaTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            namaTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            namaTextBox.AutoCompleteCustomSource = namaCollection;

            AutoCompleteStringCollection alamatCollection = new AutoCompleteStringCollection();
            alamatCollection.AddRange(Person.AlamatCache.ToArray());
            alamatTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            alamatTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            alamatTextBox.AutoCompleteCustomSource = alamatCollection;
        }

        public abstract class FormMode
        {
            public SumbanganForm F
            {
                get;
                set;
            }

            public abstract void Init(int month, int year);
            public abstract void Save();
        }

        public class AddMode : FormMode
        {
            public override void Init(int month, int year)
            {
                if (month == DateTime.Now.Month && year == DateTime.Now.Year)
                    F.dateTimePicker1.Value = DateTime.Now;
                else
                    F.dateTimePicker1.Value = new DateTime(year, month, 1);
            }

            public override void Save()
            {
                using (SqliteConnectionHelper connection = new SqliteConnectionHelper(ConfigurationManager.AppSettings["db_path"]))
                {
                    Sumbangan sumbangan = new Sumbangan(connection);
                    sumbangan.Insert(F.dateTimePicker1.Value, F.namaTextBox.Text.Trim(), F.alamatTextBox.Text.Trim(), double.Parse(F.jumlahTextBox.Text), F.keteranganTextBox.Text.Trim());
                }
            }
        }

        public class EditMode : FormMode
        {
            int sumbanganId = -1;

            public EditMode(int sumbanganId)
            {
                this.sumbanganId = sumbanganId;
            }

            public override void Init(int month, int year)
            {
                using (SqliteConnectionHelper connection = new SqliteConnectionHelper(ConfigurationManager.AppSettings["db_path"]))
                {
                    Sumbangan sumbanganModel = new Sumbangan(connection);
                    DataTable sumbangan = sumbanganModel.Get(sumbanganId);
                    foreach (DataRow row in sumbangan.Rows)
                    {
                        F.dateTimePicker1.Value = DateTime.Parse(row["sbg_tanggal"].ToString());
                        F.namaTextBox.Text = row["prs_nama"].ToString();
                        F.alamatTextBox.Text = row["prs_alamat"].ToString();
                        F.jumlahTextBox.Text = row["sbg_jumlah"].ToString();
                        F.keteranganTextBox.Text = row["sbg_keterangan"].ToString();
                    }
                }
            }

            public override void Save()
            {
                if (sumbanganId == -1)
                    return;
                using (SqliteConnectionHelper connection = new SqliteConnectionHelper(ConfigurationManager.AppSettings["db_path"]))
                {
                    Sumbangan sumbangan = new Sumbangan(connection);
                    sumbangan.Update(sumbanganId, F.dateTimePicker1.Value, F.namaTextBox.Text, F.alamatTextBox.Text, double.Parse(F.jumlahTextBox.Text), F.keteranganTextBox.Text);
                }
            }
        }

        private void jumlahTextBox_Validating(object sender, CancelEventArgs e)
        {
            float val;
            if (!float.TryParse(jumlahTextBox.Text, out val))
            {
                ErrorProviderExtensions.SetError(errorProvider1, jumlahTextBox, contohLabel.Text);
            }
            else
            {
                ErrorProviderExtensions.SetError(errorProvider1, jumlahTextBox, null);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ErrorProviderExtensions.HasErrors(errorProvider1))
            {
                DialogResult = DialogResult.None;
                return;
            }
            mode.Save();
            DialogResult = DialogResult.OK;
        }
    }
}
