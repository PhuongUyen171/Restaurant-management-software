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
    public partial class frmDangNhap : DevComponents.DotNetBar.RibbonForm
    {
        SqlConnection con;
        public frmDangNhap()
        {
            if(con==null)
                con = new SqlConnection(@"Data Source=PHUONGUYEN\PHUONGUYEN;Initial Catalog=QL_NhaHang;User ID=sa;Password=uyen");
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            frmConnect frm = new frmConnect();
            frm.Show();
            this.Hide();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            frmResetPass frm = new frmResetPass();
            frm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra
                if (con.State == ConnectionState.Closed)
                {
                    
                    con.Open();
                }
                SqlCommand cm = new SqlCommand("select count(*) from NGUOIDUNG where TenDangNhap='"+txtUser.Text+"'",con);
                if ((int)cm.ExecuteScalar() > 0)
                {
                    //Kết nối
                    frmMain frm = new frmMain();
                    frm.Show();
                    this.Hide();
                    con.Close();
                    MessageBox.Show("Kết nối thành công.", "Thành công");
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu hoặc tên đăng nhập", " Báo lỗi");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối thất bại.","Báo lỗi");
                return;
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                txtPass.PasswordChar = '*';
            else
                txtPass.PasswordChar = (char)0;
        }
    }
}
