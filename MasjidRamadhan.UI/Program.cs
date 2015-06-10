using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace MasjidRamadhan.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                using (Model.SqliteConnectionHelper connection = new Model.SqliteConnectionHelper(ConfigurationManager.AppSettings["db_path"]))
                {
                    Model.Person p = new Model.Person(connection);
                    p.Get();
                }
            }
            catch { }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Manager());
        }
    }
}
