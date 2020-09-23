using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;

namespace doAnDotNet
{
    public partial class frmQLNhaCungCap : DevComponents.DotNetBar.RibbonForm
    {
        //Khai báo thuộc tính
        SqlConnection con;
        SqlDataAdapter daNCC;
        DataSet dsNCC = new DataSet();

        public frmQLNhaCungCap()
        {
            if (con == null)
                con = new SqlConnection(@"Data Source=PHUONGUYEN\PHUONGUYEN;Initial Catalog=QL_NhaHang;User ID=sa;Password=uyen");
                //con = new SqlConnection(@"Data Source=LAPTOP-NHATKUN\XUANNHAT;Initial Catalog=QL_NhaHang;Integrated Security=True");
            InitializeComponent();
        }

        public void loadDuLieuNCC()
        {
            daNCC = new SqlDataAdapter("select * from NCC", con);
            daNCC.Fill(dsNCC, "NCC");
            dtgvNCC.DataSource = dsNCC.Tables["NCC"];

            DataColumn[] keyNCC = new DataColumn[1];
            keyNCC[0] = dsNCC.Tables["NCC"].Columns[0];
            dsNCC.Tables["NCC"].PrimaryKey = keyNCC;
        }

        

        private void mnuXoaNCC_Click(object sender, EventArgs e)
        {
            btnXoaNCC.PerformClick();
        }

        private void mnuSuaNCC_Click(object sender, EventArgs e)
        {
            btnSuaNCC.PerformClick();
        }

        private void btnThoatNCC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (txtTenNCC.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtSDTNCC.Text.Trim() == "" || txtEmailNCC.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng", "Báo lỗi");
                return;
            }

            DataRow them = dsNCC.Tables["NCC"].NewRow();
            them["MaNCC"] = dsNCC.Tables["NCC"].Rows.Count+1;
            them["TenNCC"] = txtTenNCC.Text;
            them["DiaChi"] = txtDiaChi.Text;
            them["SDT"] = txtSDTNCC.Text;
            them["Email"] = txtEmailNCC.Text;
            try
            {
                dsNCC.Tables["NCC"].Rows.Add(them);
                MessageBox.Show("Thêm thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại.", "Báo lỗi");
                return;
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;

            //Kiểm tra khóa ngoại
            SqlDataAdapter daKT1 = new SqlDataAdapter("select * from NGUYENLIEU where MaNCC=" + txtMaNCC.Text, con);
            DataTable dtKT1 = new DataTable();
            daKT1.Fill(dtKT1);
            if (dtKT1.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            SqlDataAdapter daKT2 = new SqlDataAdapter("select * from PHIEUNHAP where MaNCC=" + txtMaNCC.Text, con);
            DataTable dtKT2 = new DataTable();
            daKT2.Fill(dtKT2);
            if (dtKT2.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }
            //Xóa
            DataRow xoa = dsNCC.Tables["NCC"].Rows.Find(txtMaNCC.Text);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            DataRow sua = dsNCC.Tables["NCC"].Rows.Find(txtMaNCC.Text);
            if (sua != null)
            {
                sua["TenNCC"] = txtTenNCC.Text;
                sua["DiaChi"] = txtDiaChi.Text;
                sua["SDT"] = txtSDTNCC.Text;
                sua["Email"] = txtEmailNCC.Text;
                MessageBox.Show("Sửa thành công", "Thông báo");
            }
        }

        private void btnLuuNCC_Click(object sender, EventArgs e)
        {
            try
            {
                daNCC = new SqlDataAdapter("select * from NCC", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daNCC);
                daNCC.Update(dsNCC, "NCC");
                loadDuLieuNCC();
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Báo lỗi");
                return;
            }
        }

        private void btnHuyNCC_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDuLieuNCC();
                return;
            }
        }

        private void dtgvNCC_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNCC.Text = dtgvNCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = dtgvNCC.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dtgvNCC.CurrentRow.Cells[2].Value.ToString();
            txtSDTNCC.Text = dtgvNCC.CurrentRow.Cells[3].Value.ToString();
            txtEmailNCC.Text = dtgvNCC.CurrentRow.Cells[4].Value.ToString();
        }

        private void frmQLNhaCungCap_Load(object sender, EventArgs e)
        {
            loadDuLieuNCC();
        }
        
    }
}