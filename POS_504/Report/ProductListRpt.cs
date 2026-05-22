using Microsoft.Reporting.WinForms;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_504.Report
{
    public partial class ProductListRpt : Form
    {
        public ProductListRpt()
        {
            InitializeComponent();
        }

        private void ProductListRpt_Load(object sender, EventArgs e)
        {

            OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM PRODUCT_V", Program.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            reportViewer1.LocalReport.ReportEmbeddedResource = "POS_504.Report.ProductListRpt.rdlc";
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables[0]));
            reportViewer1.RefreshReport();
        }
    }
}
