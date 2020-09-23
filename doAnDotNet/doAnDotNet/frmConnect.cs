using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace doAnDotNet
{
    public partial class frmConnect : DevComponents.DotNetBar.RibbonForm
    {
        SqlConnection con;
        public frmConnect()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string c = @"Data Source="+txtServer.Text+";Initial Catalog="+txtData.Text+";User ID="+txtUser.Text+"; Password="+txtPass.Text;
                con = new SqlConnection(c);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    this.Hide();
                    frmDangNhap frm = new frmDangNhap();
                    frm.Show();
                    MessageBox.Show("Kết nối thành công", "Thông báo");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối thất bại","Báo lỗi");
                return;
            }
        }
    }
}
