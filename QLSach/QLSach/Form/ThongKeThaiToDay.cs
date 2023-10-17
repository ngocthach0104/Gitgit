using Microsoft.Reporting.WinForms;
using QLSach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSach;

namespace QLSach
{
    public partial class ThongKeThaiToDay : Form
    {
        public ThongKeThaiToDay()
        {
            InitializeComponent();
        }

        DBcontextQuanLySach context = new DBcontextQuanLySach();
        private void ThongKeTheoNam_Load(object sender, EventArgs e)
        {
            List<LoaiSach> listLoaiSach = context.LoaiSaches.ToList();

            this.reportViewer1.LocalReport.ReportPath = "./rptSach.rdlc";

            ReportDataSource reportDataSource = new ReportDataSource("DataSetSach", listLoaiSach);

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
        }

    }
}
