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
    public partial class SelectScreenForm : Form
    {
        public SelectScreenForm()
        {
            InitializeComponent();
        }

        private void SelectScreenForm_Load(object sender, EventArgs e)
        {
            foreach (Screen s in Screen.AllScreens)
            {
                comboBox1.Items.Add(s.DeviceName);
            }
        }

        public Screen SelectedScreen
        {
            get
            {
                foreach (Screen s in Screen.AllScreens)
                {
                    if (s.DeviceName == comboBox1.SelectedItem.ToString())
                        return s;
                }
                return null;
            }
        }
    }
}
