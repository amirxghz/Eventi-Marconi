using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using MySqlConnector;

namespace EsLab_Eventi_Ghouzlani
{
    static class Program
    {
        public static MySqlConnection conn;
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString = Properties.Settings.Default.dbConnString;
            conn = new MySqlConnection(connectionString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
