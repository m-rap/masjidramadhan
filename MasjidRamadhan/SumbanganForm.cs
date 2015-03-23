using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MasjidRamadhan
{
    public partial class SumbanganForm : Form
    {
        MasjidRamadhanConnection connection;

        public SumbanganForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void SumbanganForm_Load(object sender, EventArgs e)
        {
            connection = new MasjidRamadhanConnection("MasjidRamadhan.db");
            DataTable dt = SumbanganModel.Get(ref connection, new DateTime(), new DateTime(), 0, 100);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            sumbanganDgv.Columns.Clear();
            sumbanganDgv.DataSource = bs;
        }
    }
}
