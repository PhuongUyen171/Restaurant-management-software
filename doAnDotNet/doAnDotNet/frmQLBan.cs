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
    public partial class frmQLBan : DevComponents.DotNetBar.RibbonForm
    {
        //Khai báo thuộc tính
        SqlConnection con;
        SqlDataAdapter daKV,daBan;
        DataSet dsKV = new DataSet();
        DataSet dsBan = new DataSet();


        public frmQLBan()
        {
            if(con==null)
                con = new SqlConnection(@"Data Source=PHUONGUYEN\PHUONGUYEN;Initial Catalog=QL_NhaHang;User ID=sa;Password=uyen");
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void loadCbo()
        {
            daKV = new SqlDataAdapter("select * from KHUVUC", con);
            daKV.Fill(dsKV, "KhuVuc");
            cboMaKV.DataSource = dsKV.Tables["KhuVuc"];
            cboMaKV.DisplayMember = "TenKV";
            cboMaKV.ValueMember = "MaKV";

            cboTinhTrang.SelectedIndex = 0;
        }
        public void loadDuLieu()
        {
            daBan = new SqlDataAdapter("select * from BAN", con);
            daBan.Fill(dsBan, "Ban");
            dtgvBan.DataSource = dsBan.Tables["Ban"];

            DataColumn[] keyBan = new DataColumn[1];
            keyBan[0] = dsBan.Tables["Ban"].Columns[0];
            dsBan.Tables["Ban"].PrimaryKey = keyBan;
        }
        private void frmQLBan_Load(object sender, EventArgs e)
        {
            loadCbo();
            loadDuLieu();
        }

        private void dtgvBan_SelectionChanged(object sender, EventArgs e)
        {
            txtMaBan.Text = dtgvBan.CurrentRow.Cells[0].Value.ToString();
            cboMaKV.SelectedValue = dtgvBan.CurrentRow.Cells[1].Value.ToString();
            txtMaPD.Text = dtgvBan.CurrentRow.Cells[2].Value.ToString();
            cboTinhTrang.Text = dtgvBan.CurrentRow.Cells[3].Value.ToString();
        }

        private void mnuSuaBan_Click(object sender, EventArgs e)
        {
            btnSuaBan.PerformClick();
        }

        private void mnuXoaBan_Click(object sender, EventArgs e)
        {
            btnXoaBan.PerformClick();
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            
            DataRow them = dsBan.Tables["Ban"].NewRow();
            them["MaB"] = dsBan.Tables["Ban"].Rows.Count+1;
                them["MaPD"] = txtMaPD.Text;
            them["MaKV"] = cboMaKV.SelectedValue;
            them["TinhTrang"] = cboTinhTrang.Text;

            try
            {
                dsBan.Tables["Ban"].Rows.Add(them);
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại vì bạn chưa lưu", "Báo lỗi");
                return;
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;

            //Kiểm tra khóa ngoại
            

            //Xóa
            DataRow xoa = dsBan.Tables["Ban"].Rows.Find(txtMaBan.Text);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            DataRow sua = dsBan.Tables["Ban"].Rows.Find(txtMaBan.Text);
            if (sua != null)
            {
                sua["MaB"] = txtMaBan.Text;
                    sua["MaPD"] = txtMaPD.Text;
                sua["MaKV"] = cboMaKV.SelectedValue;
                sua["TinhTrang"] = cboTinhTrang.SelectedItem.ToString();

                MessageBox.Show("Sửa thành công", "Thông báo");
            }
        }

        private void btnLuuBan_Click(object sender, EventArgs e)
        {
            try
            {
                daBan = new SqlDataAdapter("select * from BAN", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daBan);
                daBan.Update(dsBan, "BAN");
                loadDuLieu();
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Báo lỗi");
                return;
            }
        }

        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDuLieu();
                return;
            }
        }

        private void cboTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTinhTrang.SelectedItem.ToString() == "Còn")
                txtMaPD.Text = "";
        }
    }
}