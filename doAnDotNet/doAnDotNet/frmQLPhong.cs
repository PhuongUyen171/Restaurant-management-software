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
    public partial class frmQLPhong : DevComponents.DotNetBar.RibbonForm
    {
        //Khai báo thuộc tính
        SqlConnection con;
        SqlDataAdapter daLoaiPhong, daKV,daPhong;
        DataSet dsLoaiPhong = new DataSet();
        DataSet dsKV = new DataSet();
        DataSet dsPhong = new DataSet();

        public frmQLPhong()
        {
            if (con == null)
                con = new SqlConnection(@"Data Source=PHUONGUYEN\PHUONGUYEN;Initial Catalog=QL_NhaHang;User ID=sa;Password=uyen");
            
            InitializeComponent();
        }

        //Load dữ liệu
        public void loadCbo()
        {
            //Cbo loại phòng
            daLoaiPhong = new SqlDataAdapter("select * from LOAIPHONG", con);
            daLoaiPhong.Fill(dsLoaiPhong, "LoaiPhong");
            cboMaLP.DataSource = dsLoaiPhong.Tables["LoaiPhong"];
            cboMaLP.DisplayMember = "TenLP";
            cboMaLP.ValueMember = "MaLP";

            //Cbo khu vực
            daKV = new SqlDataAdapter("select * from KHUVUC", con);
            daKV.Fill(dsKV, "KhuVuc");
            cboMaKV.DataSource = dsKV.Tables["KhuVuc"];
            cboMaKV.DisplayMember = "TenKV";
            cboMaKV.ValueMember = "MaKV";

            //Cbo tình trạng
            cboTinhTrang.SelectedIndex = 0;
        }
        public void loadDuLieu()
        {
            daPhong = new SqlDataAdapter("select * from PHONG", con);
            daPhong.Fill(dsPhong, "Phong");
            dtgvPhong.DataSource = dsPhong.Tables["Phong"];

            DataColumn[] keyPH = new DataColumn[1];
            keyPH[0] = dsPhong.Tables["Phong"].Columns[0];
            dsPhong.Tables["Phong"].PrimaryKey = keyPH;
        }

        //Xử lý sự kiện
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQLPhong_Load(object sender, EventArgs e)
        {
            loadCbo();
            loadDuLieu();
        }

        private void dtgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            txtMaPH.Text = dtgvPhong.CurrentRow.Cells[0].Value.ToString();
            txtTenPH.Text = dtgvPhong.CurrentRow.Cells[1].Value.ToString();
            txtSucChua.Text = dtgvPhong.CurrentRow.Cells[2].Value.ToString();
            
            cboMaKV.SelectedValue = dtgvPhong.CurrentRow.Cells[4].Value.ToString();
            cboMaLP.SelectedValue = dtgvPhong.CurrentRow.Cells[3].Value.ToString();
            cboTinhTrang.Text = dtgvPhong.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;

            //Kiểm tra khóa ngoại
            SqlDataAdapter daKT1 = new SqlDataAdapter("select * from CT_DICHVU where MaPH=" + txtMaPH.Text, con);
            DataTable dtKT1 = new DataTable();
            daKT1.Fill(dtKT1);
            if (dtKT1.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            //Xóa
            DataRow xoa = dsPhong.Tables["Phong"].Rows.Find(txtMaPH.Text);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            DataRow sua = dsPhong.Tables["Phong"].Rows.Find(txtMaPH.Text);
            if (sua != null)
            {
                sua["MaPH"] = txtMaPH.Text;
                sua["TenPH"] = txtTenPH.Text;
                sua["SucChua"] = txtSucChua.Text;
                sua["MaLP"] = cboMaLP.SelectedValue;
                sua["MaKV"] = cboMaKV.SelectedValue;
                sua["TinhTrang"] = cboTinhTrang.Text;

                MessageBox.Show("Sửa thành công", "Thông báo");
            }
        }

        private void btnLuuPhong_Click(object sender, EventArgs e)
        {
            try
            {
                daPhong = new SqlDataAdapter("select * from PHONG", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daPhong);
                daPhong.Update(dsPhong, "Phong");
                loadDuLieu();
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Báo lỗi");
                return;
            }
        }

        private void btnHuyPhong_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDuLieu();
                return;
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (txtMaPH.Text.Trim() == "" || txtSucChua.Text.Trim() == "" || txtTenPH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phòng","Báo lỗi");
                return;
            }
            DataRow them = dsPhong.Tables["Phong"].NewRow();
            them["MaPH"] = dsPhong.Tables["Phong"].Rows.Count + 1;
            them["TenPH"] = txtTenPH.Text;
            them["SucChua"] = txtSucChua.Text;
            them["MaLP"] = cboMaLP.SelectedValue;
            them["MaKV"] = cboMaKV.SelectedValue;
            them["TinhTrang"] = cboTinhTrang.Text;
            try
            {
                dsPhong.Tables["Phong"].Rows.Add(them);
                MessageBox.Show("Thêm thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại.", "Báo lỗi");
                return;
            }
        }

        private void mnuXoaPhong_Click(object sender, EventArgs e)
        {
            btnXoaPhong.PerformClick();
        }

        private void mnuSuaPhong_Click(object sender, EventArgs e)
        {
            btnSuaPhong.PerformClick();
        }
    }
}