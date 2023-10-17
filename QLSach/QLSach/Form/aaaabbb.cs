using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach
{
    public partial class aaaabbb : Form
    {
        public aaaabbb()
        {
            InitializeComponent();
        }

        private void btn_QuanLySach_Click(object sender, EventArgs e)
        {
            QuanLySach frm = new QuanLySach();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btn_ThongKeTheoSach_Click(object sender, EventArgs e)
        {
            ThongKeThaiToDay frm = new ThongKeThaiToDay();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
