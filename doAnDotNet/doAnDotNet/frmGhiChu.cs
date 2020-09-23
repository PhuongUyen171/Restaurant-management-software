using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace doAnDotNet
{
    public partial class frmGhiChu : DevComponents.DotNetBar.RibbonForm
    {
        public frmGhiChu()
        {
            InitializeComponent();
        }
        public string _ghichu;
        public string ghiChu
        {
            get { return _ghichu; }
            set { _ghichu = value; }
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            this.Close();
            ghiChu = txtGhiChu.Text;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}