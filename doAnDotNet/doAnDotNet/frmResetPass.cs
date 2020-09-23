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
    public partial class frmResetPass : DevComponents.DotNetBar.RibbonForm
    {
        SqlConnection con;
        SqlDataAdapter daND;
        DataSet dsND = new DataSet();


        public frmResetPass()
        {
            if (con == null)
                con = new SqlConnection(@"Data Source=PHUONGUYEN\PHUONGUYEN;Initial Catalog=QL_NhaHang;User ID=sa;Password=uyen");
            
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void loadDuLieu()
        {
            //Người dùng
            daND = new SqlDataAdapter("select * from NGUOIDUNG", con);
            daND.Fill(dsND, "NguoiDung");
            DataColumn[] keyND = new DataColumn[1];
            keyND[0] = dsND.Tables["NguoiDung"].Columns[0];
            dsND.Tables["NguoiDung"].PrimaryKey = keyND;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (string.IsNullOrEmpty(txtMKcu.Text) || string.IsNullOrEmpty(txtMKmoi.Text) || string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtXacNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin","Báo lỗi");
                return;
            }
            //Kiểm tra xác nhận MK
            if (txtMKmoi.Text != txtXacNhan.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu chưa chính xác.\nVui lòng thử lại","Báo lỗi");
                return;
            }
            try
            {
                DataRow kt = dsND.Tables["NguoiDung"].Rows.Find(txtTenDN.Text);
                if (kt != null)
                {
                    string pass = kt["MatKhau"].ToString();
                    if (pass == txtMKcu.Text)
                    {
                        kt["MatKhau"] = txtMKmoi.Text;
                        SqlCommandBuilder cmb = new SqlCommandBuilder(daND);
                        daND.Update(dsND, "NguoiDung");
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu","Báo lỗi");
                        return;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.","Báo lỗi");
                return;
            }
            
        }

        private void frmResetPass_Load(object sender, EventArgs e)
        {
            loadDuLieu();
        }
    }
}
