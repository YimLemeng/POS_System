using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using POS_504.Security;
using POS_504.Setup;

namespace POS_504
{
    internal static class Program
    {
        public static OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["POS_504.Properties.Settings.ConnectionString"].ConnectionString);


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                cn.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginFrm());
        }
    }
}
