using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MasjidRamadhan
{
    public partial class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            InitializeComponent();
        }

        public DoubleBufferedPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


    }
}
