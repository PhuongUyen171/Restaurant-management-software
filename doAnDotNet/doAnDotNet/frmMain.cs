using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;

using System.IO;
using System.Windows.Forms.DataVisualization.Charting.ChartTypes;
using System.Globalization;


namespace doAnDotNet
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        SqlConnection con;

        //Khai báo
        SqlDataAdapter daKH, daNV, daNL, daKV, daMH, daNhomND, daPQ, daHD, daPN, daNDnhomND, daMonAn, daCTMA, daCTPN,daND,daBan,daPhong,daNCC;
        string hinhNV, hinhMA, hinhNL;
        string ten;

        DataSet dsBan = new DataSet();
        DataSet dsND = new DataSet();
        DataSet dsKH = new DataSet();
        DataSet dsNV = new DataSet();
        DataSet dsNL = new DataSet();
        DataSet dsKV = new DataSet();
        DataSet dsMH = new DataSet();
        DataSet dsNhomND = new DataSet();
        DataSet dsPQ = new DataSet();
        DataSet dsHD = new DataSet();
        DataSet dsPN = new DataSet();
        DataSet dsNDnhomND = new DataSet();
        DataSet dsMonAn = new DataSet();
        DataSet dsCTMA = new DataSet();
        DataSet dsCTPN = new DataSet();
        DataSet dsPhong = new DataSet();
        DataSet dsNCC = new DataSet();


        public frmMain()
        {
            InitializeComponent();
            if(con==null)
                con = new SqlConnection(@"Data Source=PHUONGUYEN\PHUONGUYEN;Initial Catalog=QL_NhaHang;User ID=sa;Password=uyen");
            //con = new SqlConnection(@"Data Source=DESKTOP-F1U6QJ8\SQLEXPRESS;Initial Catalog=QL_NhaHang;Integrated Security=True");
        }




        //---------------------------------------------//
        //Sự kiện form đóng
        private void tabMain_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
        {
            TabItem chon = tabMain.SelectedTab;
            DialogResult r = MessageBox.Show("Bạn muốn xóa trang " + chon.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                tabMain.Tabs.Remove(chon);
        }




        //----------------------------------------//
        //Sự kiện trên menu
        private void tabThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuQLKH_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabQLKH))
                tabMain.Tabs.Add(tabQLKH);
            tabMain.SelectedTab = tabQLKH;
        }

        private void mnuQLNV_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabQLNV))
                tabMain.Tabs.Add(tabQLNV);
            tabMain.SelectedTab = tabQLNV;
        }

        private void mnuPhanQuyen_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabPhanQuyen))
                tabMain.Tabs.Add(tabPhanQuyen);
            tabMain.SelectedTab = tabPhanQuyen;
        }

        private void mnuKhoNL_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabQLKhoNguyenLieu))
                tabMain.Tabs.Add(tabQLKhoNguyenLieu);
            tabMain.SelectedTab = tabQLKhoNguyenLieu;
        }
        private void mnuQLBanKV_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabQLBanKV))
                tabMain.Tabs.Add(tabQLBanKV);
            tabMain.SelectedTab = tabQLBanKV;
        }
        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            frmGioiThieu frm = new frmGioiThieu();
            frm.Show();
        }

        private void mnuThucDon_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabQLMA))
                tabMain.Tabs.Add(tabQLMA);
            tabMain.SelectedTab = tabQLMA;
        }

        private void mnuNguyenLieu_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabQLNguyenLieu))
                tabMain.Tabs.Add(tabQLNguyenLieu);
            tabMain.SelectedTab = tabQLNguyenLieu;
        }

        private void mnuHDPN_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabTKHDPhieuNhap))
                tabMain.Tabs.Add(tabTKHDPhieuNhap);
            tabMain.SelectedTab = tabTKHDPhieuNhap;
        }

        private void mnuTonkho_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabThemTKTK))
                tabMain.Tabs.Add(tabThemTKTK);
            tabMain.SelectedTab = tabThemTKTK;
        }

        private void mnuThemUser_Click(object sender, EventArgs e)
        {
            if (!tabMain.Tabs.Contains(tabQLThemND))
                tabMain.Tabs.Add(tabQLThemND);
            tabMain.SelectedTab = tabQLThemND;
        }
        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            frmQLNhaCungCap f = new frmQLNhaCungCap();
            f.Show();
        }
        private void mnuResetPass_Click(object sender, EventArgs e)
        {
            frmResetPass frm = new frmResetPass();
            frm.Show();
        }




        //---------------------------------------------//
        //Form main load
        private void frmMain_Load(object sender, EventArgs e)
        {
            loadCboLoaiKH();
            loadCboNCC();
            loadCboNL();
            loadCboNhomND();
            loadCboMaNCC();

            loadDataCTMA();
            loadDataCTPN();
            loadDataHD();
            loadDataKH();
            loadDataKV();
            loadDataMA();
            loadDataMH();
            loadDataNDnhomND();
            loadDataNhomND();
            loadDataNL();
            loadDataNV();
            loadDataPN();
            loadDataPQ();
            loadDataND();
            loadDataBan();
            loadDataPhong();


            loadNguoiDung();
            loadBieuDo();
            loadNguyenLieu();
            loadNguyenLieuMA();
            loadKhuVuc();
        }




        //---------------------------------------//
        //Load form giao diện
        //Người dùng
        public void loadNguoiDung()
        {
            List<NguoiDung> listND = LoadDSNguoiDung();
            foreach (NguoiDung item in listND)
            {
                DevComponents.DotNetBar.ButtonX btn = new ButtonX() { Width = 90, Height = 90 };
                btn.Text = item.tenDN.ToString();
                btn.Image = Image.FromFile(@"C:\Users\Dell\Desktop\DeTai7\Hinh\Person.png");
                btn.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                btn.BackColor = Color.LightPink;
                btn.Tag = item;
                btn.Click += btn_Click;
                flpnNguoiDung.Controls.Add(btn);
            }
        }
        private List<NguoiDung> LoadDSNguoiDung()
        {
            List<NguoiDung> listND = new List<NguoiDung>();

            foreach (DataRow item in dsND.Tables["NguoiDung"].Rows)
            {
                NguoiDung nd = new NguoiDung(item);
                listND.Add(nd);
            }
            return listND;
        }
        void btn_Click(object sender, EventArgs e)
        {
            ten = ((sender as DevComponents.DotNetBar.ButtonX).Tag as NguoiDung).tenDN;
            MessageBox.Show(ten, "Thông báo");
        }
        
        //Khu vực
        public void loadKhuVuc()
        {
            tabKV.Tabs.Clear();
            foreach (DataRow item in dsKV.Tables["KhuVuc"].Rows)
            {
                TabItem tab = new TabItem();
                tab.Text = item["TenKV"].ToString();

                TabControlPanel tcpn = new TabControlPanel();
                tcpn.Dock = System.Windows.Forms.DockStyle.Fill;
                FlowLayoutPanel flpnKV = new FlowLayoutPanel();
                flpnKV.BackColor = Color.LightBlue;
                foreach (DataRow row in dsBan.Tables["Ban"].Rows)
                    if (row["MaKV"].ToString() == item["MaKV"].ToString())
                    {
                        DevComponents.DotNetBar.ButtonX btnKV = new ButtonX() { Width = 90, Height = 90 };
                        btnKV.Text = "Bàn "+row["MaB"].ToString() + Environment.NewLine + row["TinhTrang"].ToString();
                        btnKV.BackColor = Color.LightPink;
                        btnKV.Tag = item;
                        btnKV.Click+=btnKV_Click;
                        flpnKV.Controls.Add(btnKV);
                    }
                foreach (DataRow row in dsPhong.Tables["Phong"].Rows)
                    if (row["MaKV"].ToString() == item["MaKV"].ToString())
                    {
                        DevComponents.DotNetBar.ButtonX btnPH = new ButtonX() { Width = 90, Height = 90 };
                        btnPH.Text = row["TenPH"].ToString() + Environment.NewLine + row["TinhTrang"].ToString();
                        btnPH.BackColor = Color.LightGray;
                        btnPH.Tag = item;
                        btnPH.Click+=btnPH_Click;
                        flpnKV.Controls.Add(btnPH);
                    }
                flpnKV.Dock = System.Windows.Forms.DockStyle.Fill;
                tcpn.Controls.Add(flpnKV);
                tcpn.TabItem = tab;
                tab.AttachedControl = tcpn;
                
                tabKV.Tabs.Add(tab);
            }
        }
        void btnKV_Click(object sender, EventArgs e)
        {
            frmQLBan frm = new frmQLBan();
            frm.Show();
        }
        void btnPH_Click(object sender, EventArgs e)
        {
            frmQLPhong frm = new frmQLPhong();
            frm.Show();
        }

        //Nguyên liệu
        public void loadNguyenLieu()
        {
            foreach (DataRow item in dsNL.Tables["NguyenLieu"].Rows)
            {
                DevComponents.DotNetBar.ButtonX btnNL = new ButtonX() { Width = 90, Height = 90 };
                btnNL.Text = item["TenNL"].ToString() + Environment.NewLine + item["KLTon"].ToString() + "/" + item["DVT"].ToString();
                btnNL.Click+=btnNL_Click;
                btnNL.Tag = item;
                flpnNL.Controls.Add(btnNL);
            }
        }
        void btnNL_Click(object sender, EventArgs e)
        {
            //txtMaNL2.Text = ((sender as DevComponents.DotNetBar.ButtonX).Tag as NguyenLieu).maNL+"";
            //txtTenNL.Text = ((sender as DevComponents.DotNetBar.ButtonX).Tag as NguyenLieu).tenNL + "";
            //txtDVTNL.Text = ((sender as DevComponents.DotNetBar.ButtonX).Tag as NguyenLieu).DVT + "";
        }
        //public List<NguyenLieu> loadDSNL()
        //{
        //    List<NguyenLieu> listND = new List<NguyenLieu>();

        //    foreach (DataRow item in dsNL.Tables["NguyenLieu"].Rows)
        //    {
        //        NguyenLieu nd = new NguyenLieu(item);
        //        listND.Add(nd);
        //    }
        //    return listND;
        //}

        //Nguyên liệu món ăn
        public void loadNguyenLieuMA()
        {
            foreach (DataRow item in dsNL.Tables["NguyenLieu"].Rows)
            {
                DevComponents.DotNetBar.ButtonX btn = new ButtonX() { Width = 90, Height = 90 };
                btn.Text = item["TenNL"].ToString() + Environment.NewLine + item["KLTon"].ToString() + "/" + item["DVT"].ToString();
                
                btn.Tag = item;
                flpnNguyenLieu.Controls.Add(btn);
            }
        }




        //---------------------------------------------//
        //Load dữ liệu ComboBox
        public void loadCboLoaiKH()
        {
            //Cbo loại khách hàng
            SqlDataAdapter daLoaiKH = new SqlDataAdapter("select * from LOAIKH", con);
            DataSet dsLoaiKH = new DataSet();
            daLoaiKH.Fill(dsLoaiKH, "LoaiKH");
            cboMaLKH.DataSource = dsLoaiKH.Tables["LoaiKH"];
            cboMaLKH.DisplayMember = "TenLKH";
            cboMaLKH.ValueMember = "MaLKH";
        }
        public void loadCboMaNCC()
        {
            //Cbo nhà cung cấp
            daNCC = new SqlDataAdapter("select * from NCC", con);
            
            daNCC.Fill(dsNCC, "NCC");
            cboMaNCC.DataSource = dsNCC.Tables["NCC"];
            cboMaNCC.DisplayMember = "TenNCC";
            cboMaNCC.ValueMember = "MaNCC";
        }
        public void loadCboNhomND()
        {
            //Cbo nhóm người dùng
            SqlDataAdapter daNND = new SqlDataAdapter("select * from NHOMNGUOIDUNG", con);
            DataSet dsNND = new DataSet();
            daNND.Fill(dsNND, "NND");
            cboNhomND.DataSource = dsNND.Tables["NND"];
            cboNhomND.DisplayMember = "TenNhom";
            cboNhomND.ValueMember = "MaNhomNguoiDung";
        }
        public void loadCboNCC()
        {
            //Cbo nhà cung cấp
            SqlDataAdapter daNCC = new SqlDataAdapter("select * from NCC", con);
            DataSet dsNCC = new DataSet();
            daNCC.Fill(dsNCC, "NCC");
            cboNCC.DataSource = dsNCC.Tables["NCC"];
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
        }
        public void loadCboNL()
        {
            //Cbo mã nguyên liệu
            cboMaNL.DataSource = dsNL.Tables["NguyenLieu"];
            cboMaNL.DisplayMember = "TenNL";
            cboMaNL.ValueMember = "MaNL";
        }
        public void loadCboNhomMA()
        {
            //Cbo nhóm món ăn
            SqlDataAdapter daNhomMA = new SqlDataAdapter("select * from NHOMMA", con);
            DataSet dsNhomMA = new DataSet();
            daNhomMA.Fill(dsNhomMA, "NhomMA");
            cboNhomMA.DataSource = dsNhomMA.Tables["NhomMA"];
            cboNhomMA.DisplayMember = "TenNMA";
            cboNhomMA.ValueMember = "MaNMA";
        }



        //---------------------------------------------//
        //Load bảng dữ liệu
        public void loadDataND()
        {
            //Người dùng
            daND = new SqlDataAdapter("select * from NGUOIDUNG", con);
            daND.Fill(dsND, "NguoiDung");
            DataColumn[] keyND = new DataColumn[1];
            keyND[0] = dsND.Tables["NguoiDung"].Columns[0];
            dsND.Tables["NguoiDung"].PrimaryKey = keyND;
        }
        public void loadDataKH()
        {
            //Khách hàng
            daKH = new SqlDataAdapter("select * from KHACHHANG", con);
            daKH.Fill(dsKH, "KhachHang");
            dtgvKhachHang.DataSource = dsKH.Tables["KhachHang"];
            DataColumn[] keyKH = new DataColumn[1];
            keyKH[0] = dsKH.Tables["KhachHang"].Columns[0];
            dsKH.Tables["KhachHang"].PrimaryKey = keyKH;
        }
        public void loadDataNV()
        {
            //Nhân viên
            daNV = new SqlDataAdapter("select * from NHANVIEN", con);
            daNV.Fill(dsNV, "NhanVien");
            dtgvNhanVien.DataSource = dsNV.Tables["NhanVien"];
            DataColumn[] keyNV = new DataColumn[1];
            keyNV[0] = dsNV.Tables["NhanVien"].Columns[0];
            dsNV.Tables["NhanVien"].PrimaryKey = keyNV;
        }
        public void loadDataNL()
        {
            //Nguyên liệu
            daNL = new SqlDataAdapter("select * from NGUYENLIEU", con);
            daNL.Fill(dsNL, "NguyenLieu");
            dtgvNguyenLieu.DataSource = dsNL.Tables["NguyenLieu"];
            DataColumn[] keyNL = new DataColumn[1];
            keyNL[0] = dsNL.Tables["NguyenLieu"].Columns[0];
            dsNL.Tables["NguyenLieu"].PrimaryKey = keyNL;
        }
        public void loadDataKV()
        {
            //Khu vực
            daKV = new SqlDataAdapter("select * from KHUVUC", con);
            daKV.Fill(dsKV, "KhuVuc");
            dtgvKhuVuc.DataSource = dsKV.Tables["KhuVuc"];
            DataColumn[] keyKV = new DataColumn[1];
            keyKV[0] = dsKV.Tables["KhuVuc"].Columns[0];
            dsKV.Tables["KhuVuc"].PrimaryKey = keyKV;
        }
        public void loadDataMH()
        {
            //Màn hình
            daMH = new SqlDataAdapter("select * from MANHINH", con);
            daMH.Fill(dsMH, "ManHinh");
            dtgvManHinh.DataSource = dsMH.Tables["ManHinh"];
            DataColumn[] keyMH = new DataColumn[1];
            keyMH[0] = dsMH.Tables["ManHinh"].Columns[0];
            dsMH.Tables["ManHinh"].PrimaryKey = keyMH;
        }
        public void loadDataNhomND()
        {
            //Nhóm người dùng
            daNhomND = new SqlDataAdapter("select * from NHOMNGUOIDUNG", con);
            daNhomND.Fill(dsNhomND, "NhomND");
            dtgvNhomND.DataSource = dsNhomND.Tables["NhomND"];
            DataColumn[] keyNhomND = new DataColumn[1];
            keyNhomND[0] = dsNhomND.Tables["NhomND"].Columns[0];
            dsNhomND.Tables["NhomND"].PrimaryKey = keyNhomND;
        }
        public void loadDataPQ()
        {
            //Phân quyền
            daPQ = new SqlDataAdapter("select * from PHANQUYEN", con);
            daPQ.Fill(dsPQ, "PhanQuyen");
            dtgvPhanQuyen.DataSource = dsPQ.Tables["PhanQuyen"];
            DataColumn[] keyPQ = new DataColumn[2];
            keyPQ[0] = dsPQ.Tables["PhanQuyen"].Columns[0];
            keyPQ[1] = dsPQ.Tables["PhanQuyen"].Columns[1];
            dsPQ.Tables["PhanQuyen"].PrimaryKey = keyPQ;
        }
        public void loadDataHD()
        {
            //Hóa đơn
            daHD = new SqlDataAdapter("select * from HOADON", con);
            daHD.Fill(dsHD, "HoaDon");
            dtgvHoaDon.DataSource = dsHD.Tables["HoaDon"];

            DataColumn[] keyHD = new DataColumn[1];
            keyHD[0] = dsHD.Tables["HoaDon"].Columns[0];
            dsHD.Tables["HoaDon"].PrimaryKey = keyHD;

            int s1 = 0;
            lbTienHD.Text = "";
            for (int i = 0; i < dsHD.Tables["HoaDon"].Rows.Count; i++)
                s1 += int.Parse(dtgvHoaDon.Rows[i].Cells[2].Value.ToString());
            lbTienHD.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", s1) + " VNĐ";
        }
        public void loadDataPN()
        {
            //Phiếu nhập
            daPN = new SqlDataAdapter("select * from PHIEUNHAP", con);
            daPN.Fill(dsPN, "PhieuNhap");
            dtgvPhieuNhap.DataSource = dsPN.Tables["PhieuNhap"];

            lbTienPN.Text = "";
            int s2 = 0;
            for (int i = 0; i < dsPN.Tables["PhieuNhap"].Rows.Count; i++)
                s2 += int.Parse(dtgvPhieuNhap.Rows[i].Cells[2].Value.ToString());
            lbTienPN.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", s2) + " VNĐ";

            DataColumn[] keyPN = new DataColumn[1];
            keyPN[0] = dsPN.Tables["PhieuNhap"].Columns[0];
            dsPN.Tables["PhieuNhap"].PrimaryKey = keyPN;
        }
        public void loadDataNDnhomND()
        {
            //ND nhóm ND
            daNDnhomND = new SqlDataAdapter("select * from NGUOIDUNGNHOMNGUOIDUNG", con);
            daNDnhomND.Fill(dsNDnhomND, "NDnhomND");
            dtgvNDnhomND.DataSource = dsNDnhomND.Tables["NDnhomND"];
            DataColumn[] keyNDnhomND = new DataColumn[2];
            keyNDnhomND[0] = dsNDnhomND.Tables["NDnhomND"].Columns[0];
            keyNDnhomND[1] = dsNDnhomND.Tables["NDnhomND"].Columns[1];
            dsNDnhomND.Tables["NDnhomND"].PrimaryKey = keyNDnhomND;
        }
        public void loadDataMA()
        {
            //Món ăn
            daMonAn = new SqlDataAdapter("select * from MONAN", con);
            daMonAn.Fill(dsMonAn, "MonAn");
            dtgvMonAn.DataSource = dsMonAn.Tables["MonAn"];
            DataColumn[] keyMA = new DataColumn[1];
            keyMA[0] = dsMonAn.Tables["MonAn"].Columns[0];
            dsMonAn.Tables["MonAn"].PrimaryKey = keyMA;
        }
        public void loadDataCTMA()
        {
            //CT Món ăn
            daCTMA = new SqlDataAdapter("select * from CT_CONGTHUC", con);
            daCTMA.Fill(dsCTMA, "CongThucMonAn");
            dtgvCTMA.DataSource = dsCTMA.Tables["CongThucMonAn"];
            DataColumn[] keyCTMA = new DataColumn[2];
            keyCTMA[0] = dsCTMA.Tables["CongThucMonAn"].Columns[0];
            keyCTMA[1] = dsCTMA.Tables["CongThucMonAn"].Columns[1];
            dsCTMA.Tables["CongThucMonAn"].PrimaryKey = keyCTMA;
        }
        public void loadDataCTPN()
        {
            //CT phiếu nhập
            daCTPN = new SqlDataAdapter("select * from CT_PHIEUNHAP", con);
            daCTPN.Fill(dsCTPN, "CTPhieuNhap");
            dtgvChiTietPN.DataSource = dsCTPN.Tables["CTPhieuNhap"];
            DataColumn[] keyCTPN = new DataColumn[2];
            keyCTPN[0] = dsCTPN.Tables["CTPhieuNhap"].Columns[0];
            keyCTPN[1] = dsCTPN.Tables["CTPhieuNhap"].Columns[1];
            dsCTPN.Tables["CTPhieuNhap"].PrimaryKey = keyCTPN;
        }
        public void loadDataBan()
        {
            //Bàn
            daBan = new SqlDataAdapter("select * from BAN", con);
            daBan.Fill(dsBan, "Ban");
        }
        public void loadDataPhong()
        {
            //Phòng
            daPhong = new SqlDataAdapter("select * from PHONG", con);
            daPhong.Fill(dsPhong, "Phong");
        }



        //------------------------------------------------//
        //Tab quản lý khách hàng
        private void dtgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            txtMaKH.Text = dtgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dtgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtDiaChiKH.Text = dtgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtSDTKH.Text = dtgvKhachHang.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dtgvKhachHang.CurrentRow.Cells[4].Value.ToString();
            txtCMND.Text = dtgvKhachHang.CurrentRow.Cells[5].Value.ToString();
            txtDiem.Text = dtgvKhachHang.CurrentRow.Cells[6].Value.ToString();
            cboMaLKH.SelectedValue = dtgvKhachHang.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnPreviousKH_Click(object sender, EventArgs e)
        {
            
        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (txtTenKH.Text.Trim() == "" || txtDiaChiKH.Text.Trim() == "" || txtSDTKH.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtCMND.Text.Trim() == "" || txtDiem.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng", "Báo lỗi");
                return;
            }

            DataRow them = dsKH.Tables["KhachHang"].NewRow();
            them["MaKH"] = dsKH.Tables["KhachHang"].Rows.Count+1;
            them["TenKH"] = txtTenKH.Text;
            them["SDT"] = txtSDTKH.Text;
            them["Email"] = txtEmail.Text;
            them["SoCMND"] = txtCMND.Text;
            them["DiaChi"] = txtDiaChiKH.Text;
            them["DiemTichLuy"] = txtDiem.Text;
            them["MaLKH"] = cboMaLKH.SelectedValue;
            try
            {
                dsKH.Tables["KhachHang"].Rows.Add(them);
                MessageBox.Show("Thêm thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại.", "Báo lỗi");
                return;
            }
        }

        private void mnuXoaKH_Click(object sender, EventArgs e)
        {
            btnXoaKH.PerformClick();
        }
        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;

            //Kiểm tra khóa ngoại
            SqlDataAdapter daKT1 = new SqlDataAdapter("select * from PHIEUDATMON where MaKH=" + txtMaKH.Text, con);
            DataTable dtKT1 = new DataTable();
            daKT1.Fill(dtKT1);
            if (dtKT1.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            SqlDataAdapter daKT2 = new SqlDataAdapter("select * from PHIEUDATVE where MaKH=" + txtMaKH.Text, con);
            DataTable dtKT2 = new DataTable();
            daKT2.Fill(dtKT2);
            if (dtKT2.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            //Xóa
            DataRow xoa = dsKH.Tables["KhachHang"].Rows.Find(txtMaKH.Text);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }

        }
        private void btnTimKH_Click(object sender, EventArgs e)
        {
            if (txtTimKH.Text.Trim() == "")
            {
                loadDataKH();
                MessageBox.Show("Vui lòng nhập thông tin muốn tìm", "Báo lỗi");
                return;
            }
            SqlDataAdapter daTim = new SqlDataAdapter("select * from KHACHHANG where TenKH like N'%" + txtTimKH.Text + "%'", con);
            DataSet dsTim = new DataSet();
            daTim.Fill(dsTim, "TimKhachHang");
            dtgvKhachHang.DataSource = dsTim.Tables["TimKhachHang"];
        }

        private void btnFirstKH_Click(object sender, EventArgs e)
        {
        }

        private void btnLastKH_Click(object sender, EventArgs e)
        {
        }
        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            try
            {
                daKH = new SqlDataAdapter("select * from KHACHHANG", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daKH);
                daKH.Update(dsKH, "KhachHang");
                loadDataKH();
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Báo lỗi");
                return;
            }

        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            DataRow sua = dsKH.Tables["KhachHang"].Rows.Find(txtMaKH.Text);
            if (sua != null)
            {
                sua["TenKH"] = txtTenKH.Text;
                sua["SDT"] = txtSDTKH.Text;
                sua["Email"] = txtEmail.Text;
                sua["SoCMND"] = txtCMND.Text;
                sua["DiaChi"] = txtDiaChiKH.Text;
                sua["DiemTichLuy"] = txtDiem.Text;
                sua["MaLKH"] = cboMaLKH.SelectedValue;
                MessageBox.Show("Sửa thành công", "Thông báo");
            }
        }

        private void mnuSuaKH_Click(object sender, EventArgs e)
        {
            btnSuaKH.PerformClick();
        }

        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDataKH();
                return;
            }
        }

        private void btnNextKH_Click(object sender, EventArgs e)
        {

        }




        //--------------------------------------------//
        //Tab quản lý nhân viên
        private void dtgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNV.Text = dtgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dtgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtDiaChiNV.Text = dtgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtSDTNV.Text = dtgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            
            //picNV.Image = chuyenByteSangImg(dtgvNhanVien.CurrentRow.Cells[4].Value.ToString());
            
            txtTenDN.Text = dtgvNhanVien.CurrentRow.Cells[5].Value.ToString();
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (txtTenNV.Text.Trim() == "" || txtDiaChiNV.Text.Trim() == "" || txtSDTNV.Text.Trim() == "" || txtTenDN.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng", "Báo lỗi");
                return;
            }

            DataRow them = dsNV.Tables["NhanVien"].NewRow();
            them["MaNV"] = dsNV.Tables["NhanVien"].Rows.Count + 1;
            them["TenNV"] = txtTenNV.Text;
            them["SDT"] = txtSDTNV.Text;
            them["DiaChi"] = txtDiaChiNV.Text;
            them["TenDangNhap"] = txtTenDN.Text;
            if (hinhNV != null)
                them["HinhAnh"] = hinhNV;
            try
            {
                dsNV.Tables["NhanVien"].Rows.Add(them);
                MessageBox.Show("Thêm thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại.", "Báo lỗi");
                return;
            }
        }
        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            try
            {
                daNV = new SqlDataAdapter("select * from NHANVIEN", con);
                SqlCommandBuilder cmbNV = new SqlCommandBuilder(daNV);
                daNV.Update(dsNV, "NhanVien");
                MessageBox.Show("Lưu thành công", "Thông báo");
                loadDataNV();
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Báo lỗi");
            }

        }
        private byte[] chuyenImgSangByte(string hinh)
        {
            FileStream fs = new FileStream(hinh, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }
        private Image chuyenByteSangImg(string byteString)
        {
            byte[] imgBytes = System.Text.Encoding.UTF8.GetBytes(byteString);
            //byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;
            //Kiểm tra khóa ngoại
            SqlDataAdapter daKT1 = new SqlDataAdapter("select * from HOADON where MaNV=" + txtMaNV.Text, con);
            DataTable dtKT1 = new DataTable();
            daKT1.Fill(dtKT1);
            if (dtKT1.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            SqlDataAdapter daKT2 = new SqlDataAdapter("select * from PHIEUGIAOHANG where MaNV=" + txtMaNV.Text, con);
            DataTable dtKT2 = new DataTable();
            daKT2.Fill(dtKT2);
            if (dtKT2.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            //Xóa
            DataRow xoa = dsNV.Tables["NhanVien"].Rows.Find(txtMaNV.Text);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            DataRow sua = dsNV.Tables["NhanVien"].Rows.Find(txtMaNV.Text);
            if (sua != null)
            {
                sua["TenNV"] = txtTenNV.Text;
                sua["DiaChi"] = txtDiaChiNV.Text;
                sua["SDT"] = txtSDTNV.Text;

                sua["TenDangNhap"] = txtTenDN.Text;
                if (hinhNV != null)
                    sua["HinhAnh"] = chuyenImgSangByte(hinhNV);
                MessageBox.Show("Sửa thành công", "Thông báo");
            }
        }

        private void mnuXoaNV_Click(object sender, EventArgs e)
        {
            btnXoaNV.PerformClick();
        }

        private void mnuSuaNV_Click(object sender, EventArgs e)
        {
            btnSuaNV.PerformClick();
        }
        private void btnChonHinhNV_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                hinhNV = op.FileName;
                picNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                picNV.Image = new Bitmap(hinhNV);
                //picNV.Image = Image.FromFile(hinh);
            }
        }
        private void btnHuyNV_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDataNV();
                return;
            }
        }


        //-------------------------------------------------------//
        //Tab phân quyền hệ thống
        private void btnXoaNhomND_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;
            //Kiểm tra khóa ngoại
            SqlDataAdapter daKT1 = new SqlDataAdapter("select * from NGUOIDUNGNHOMNGUOIDUNG where MaNhomNguoiDung=" + txtMaNhomND.Text, con);
            DataTable dtKT1 = new DataTable();
            daKT1.Fill(dtKT1);
            if (dtKT1.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            SqlDataAdapter daKT2 = new SqlDataAdapter("select * from PHANQUYEN where MaNhomNguoiDung=" + txtMaNhomND.Text, con);
            DataTable dtKT2 = new DataTable();
            daKT2.Fill(dtKT2);
            if (dtKT2.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            //Xóa
            DataRow xoa = dsNhomND.Tables["NhomND"].Rows.Find(txtMaNhomND.Text);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }

        private void btnSuaNhomND_Click(object sender, EventArgs e)
        {
            DataRow sua = dsNhomND.Tables["NhomND"].Rows.Find(txtMaNhomND.Text);
            if (sua != null)
            {
                sua["TenNhom"] = txtTenNhomND.Text;
                sua["GhiChu"] = txtGhiChu.Text;
                MessageBox.Show("Sửa thành công", "Thông báo");
            }
        }

        private void btnLuuNhomND_Click(object sender, EventArgs e)
        {
            try
            {
                daNhomND = new SqlDataAdapter("select * from NHOMNGUOIDUNG", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daNhomND);
                daNhomND.Update(dsNhomND, "NhomND");
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Thông báo");
            }

        }

        private void mnuXoaNhomND_Click(object sender, EventArgs e)
        {
            btnXoaNhomND.PerformClick();
        }

        private void mnuSuaNhomND_Click(object sender, EventArgs e)
        {
            btnSuaNhomND.PerformClick();
        }

        private void dtgvNhomND_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNhomND.Text = dtgvNhomND.CurrentRow.Cells[0].Value.ToString();
            txtTenNhomND.Text = dtgvNhomND.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = dtgvNhomND.CurrentRow.Cells[2].Value.ToString();
        }
        private void btnHuyNhomND_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDataNhomND();
                return;
            }
        }
        //Chưa xong






        //---------------------------------------------------//
        //Tab quản lý kho nguyên liệu

        private void dtgvNguyenLieu_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNL.Text = dtgvNguyenLieu.CurrentRow.Cells[0].Value.ToString();
            txtTenNL.Text = dtgvNguyenLieu.CurrentRow.Cells[1].Value.ToString();
            txtDVT.Text = dtgvNguyenLieu.CurrentRow.Cells[2].Value.ToString();
            try
            {
                cboNCC.SelectedValue = dtgvNguyenLieu.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                cboNCC.Text = "0";
            }

            txtSLTon.Text = dtgvNguyenLieu.CurrentRow.Cells[5].Value.ToString();
        }
        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (txtTenNL.Text.Trim() == "" || txtDVT.Text.Trim() == "" || txtSLTon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin muốn thêm.", "Báo lỗi");
                return;
            }
            DataRow them = dsNL.Tables["NguyenLieu"].NewRow();
            them["MaNL"] = dsNL.Tables["NguyenLieu"].Rows.Count + 1;
            them["TenNL"] = txtTenNL.Text;
            them["DVT"] = txtDVT.Text;
            them["MaNCC"] = cboNCC.SelectedValue;
            them["KLTon"] = txtSLTon.Text;
            if (hinhNL!=null)
                them["HinhAnh"] = hinhNL;
            try
            {
                dsNL.Tables["NguyenLieu"].Rows.Add(them);
                MessageBox.Show("Thêm thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại.", "Báo lỗi");
                return;
            }
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            DataRow sua = dsNL.Tables["NguyenLieu"].Rows.Find(txtMaNL.Text);
            if (sua != null)
            {
                sua["TenNL"] = txtTenNL.Text;
                sua["DVT"] = txtDVT.Text;
                sua["MaNCC"] = cboNCC.SelectedValue;
                sua["KLTon"] = double.Parse(txtSLTon.Text);
                if(hinhNL!=null)
                    sua["HinhAnh"] = chuyenImgSangByte(hinhNL);
                MessageBox.Show("Sửa thành công", "Thông báo");
            }
        }

        private void btnLuuNL_Click(object sender, EventArgs e)
        {
            try
            {
                daNL = new SqlDataAdapter("select * from NGUYENLIEU", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daNL);
                daNL.Update(dsNL, "NguyenLieu");
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Thông báo");
            }
        }
        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;

            //Kiểm tra khóa ngoại
            SqlDataAdapter daKT1 = new SqlDataAdapter("select * from CT_CONGTHUC where MaNL=" + txtMaNL.Text, con);
            DataTable dtKT1 = new DataTable();
            daKT1.Fill(dtKT1);
            if (dtKT1.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            SqlDataAdapter daKT2 = new SqlDataAdapter("select * from CT_PHIEUNHAP where MaNL=" + txtMaNL.Text, con);
            DataTable dtKT2 = new DataTable();
            daKT2.Fill(dtKT2);
            if (dtKT2.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            //Xóa
            DataRow xoa = dsNL.Tables["NguyenLieu"].Rows.Find(txtMaNL.Text);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }
        private void btnHuyNL_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDataNL();
                return;
            }
        }

        private void mnuXoaKhoNL_Click(object sender, EventArgs e)
        {
            btnXoaNL.PerformClick();
        }

        private void mnuSuaKhoNL_Click(object sender, EventArgs e)
        {
            btnSuaNL.PerformClick();
        }
        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Pictures files (.jpg, *.jpeg, *.jpe, *.jfif, *.png)|.jpg; .jpeg; *.jpe; *.jfif; *.png|All files (.*)|*.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                hinhNL = op.FileName;
                picNL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                picNL.Image = new Bitmap(hinhNL);
            }
        }

        



        //--------------------------------------------//
        //Tab quản lý khu vực
        private void dtgvKhuVuc_SelectionChanged(object sender, EventArgs e)
        {
            txtMaKV.Text = dtgvKhuVuc.CurrentRow.Cells[0].Value.ToString();
            txtTenKV.Text = dtgvKhuVuc.CurrentRow.Cells[1].Value.ToString();
            cboTinhTrang.SelectedItem = dtgvKhuVuc.CurrentRow.Cells[2].Value.ToString();
        }


        private void btnXoaKV_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;

            //Kiểm tra khóa ngoại
            SqlDataAdapter daKT1 = new SqlDataAdapter("select * from BAN where MaKV=" + txtMaKV.Text, con);
            DataTable dtKT1 = new DataTable();
            daKT1.Fill(dtKT1);
            if (dtKT1.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            SqlDataAdapter daKT2 = new SqlDataAdapter("select * from PHONG where MaKV=" + txtMaKV.Text, con);
            DataTable dtKT2 = new DataTable();
            daKT2.Fill(dtKT2);
            if (dtKT2.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            //Xóa
            DataRow xoa = dsKV.Tables["KhuVuc"].Rows.Find(txtMaKV.Text);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }

        private void btnHuyKV_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDataKV();
                return;
            }
        }

        private void btnLuuKV_Click(object sender, EventArgs e)
        {
            try
            {
                daKV = new SqlDataAdapter("select * from KHUVUC", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daKV);
                daKV.Update(dsKV, "KhuVuc");
                loadKhuVuc();
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Thông báo");
            }
        }

        private void btnSuaKV_Click(object sender, EventArgs e)
        {
            DataRow sua = dsKV.Tables["KhuVuc"].Rows.Find(txtMaKV.Text);
            if (sua != null)
            {
                sua["TenKV"] = txtTenKV.Text;
                sua["TinhTrang"] = cboTinhTrang.SelectedItem.ToString();
                MessageBox.Show("Sửa thành công", "Thông báo");
            }
        }

        private void mnuXoaKV_Click(object sender, EventArgs e)
        {
            btnXoaKV.PerformClick();
        }

        private void mnuSuaKV_Click(object sender, EventArgs e)
        {
            btnSuaKV.PerformClick();
        }
        private void btnThemKV_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (txtTenKV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khu vực", "Báo lỗi");
                return;
            }

            DataRow them = dsKV.Tables["KhuVuc"].NewRow();
            them["MaKV"] = dsKV.Tables["KhuVuc"].Rows.Count + 1;
            them["TenKV"] = txtTenKV.Text;
            them["TinhTrang"] = cboTinhTrang.SelectedItem.ToString();
            try
            {
                dsKV.Tables["KhuVuc"].Rows.Add(them);
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại vì bạn chưa lưu", "Báo lỗi");
                return;
            }

        }


        //---------------------------------------------------//
        //Tab thống kê doanh thu
        private void btnTimTheoDoanhThu_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(txtNgay1.Value.Date, txtNgay2.Value.Date) > 0 || DateTime.Compare(txtNgay1.Value.Date, DateTime.Now.Date) > 0 || DateTime.Compare(txtNgay2.Value.Date, DateTime.Now.Date) > 0)
            {
                MessageBox.Show("Dữ liệu ngày không phù hợp.\nVui lòng nhập lại", "Báo lỗi");
                return;
            }

            //Bảng HOADON
            SqlDataAdapter daHDtim = new SqlDataAdapter("set dateformat dmy select * from HOADON where NgayLap between '" + txtNgay1.Text + "' and '" + txtNgay2.Text + "'", con);
            DataSet dsHDtim = new DataSet();
            daHDtim.Fill(dsHDtim, "HoaDonTim");
            dtgvHoaDon.DataSource = dsHDtim.Tables["HoaDonTim"];

            int s1 = 0;
            lbTienHD.Text = "";
            for (int i = 0; i < dsHDtim.Tables["HoaDonTim"].Rows.Count; i++)
                s1 += int.Parse(dtgvHoaDon.Rows[i].Cells[2].Value.ToString());
            lbTienHD.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", s1) + " VNĐ";


            //Bảng PHIEUNHAP
            SqlDataAdapter daPNtim = new SqlDataAdapter("set dateformat dmy select * from PHIEUNHAP where NgayLap between '" + txtNgay1.Text + "' and '" + txtNgay2.Text + "'", con);
            DataSet dsPNtim = new DataSet();
            daPNtim.Fill(dsPNtim, "PhieuNhapTim");
            dtgvPhieuNhap.DataSource = dsPNtim.Tables["PhieuNhapTim"];

            int s2 = 0;
            lbTienPN.Text = "";
            for (int i = 0; i < dsPNtim.Tables["PhieuNhapTim"].Rows.Count; i++)
                s2 += int.Parse(dtgvPhieuNhap.Rows[i].Cells[2].Value.ToString());
            lbTienPN.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", s2) + " VNĐ";
        }




        //--------------------------------------------------//
        //Tab thêm thống kê tồn kho
        public void loadBieuDo()
        {
            //Biểu đồ tròn
            bieuDoTron.DataSource = dsNL.Tables["NguyenLieu"];
            bieuDoTron.Series["bieuDoTron"].XValueMember = "TenNL";
            bieuDoTron.Series["bieuDoTron"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            bieuDoTron.Series["bieuDoTron"].YValueMembers = "KLTon";
            bieuDoTron.Series["bieuDoTron"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

            //Biểu đồ cột
            bieuDoCot.DataSource = dsNL.Tables["NguyenLieu"];
            bieuDoCot.Series["bieuDoCot"].XValueMember = "TenNL";
            bieuDoCot.Series["bieuDoCot"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            bieuDoCot.Series["bieuDoCot"].YValueMembers = "KLTon";
            bieuDoCot.Series["bieuDoCot"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        }




        //--------------------------------------------------//
        //Tab quản lý món ăn
        private void dtgvMonAn_SelectionChanged(object sender, EventArgs e)
        {
            txtMaMA.Text = dtgvMonAn.CurrentRow.Cells[0].Value.ToString();
            txtTenMA.Text = dtgvMonAn.CurrentRow.Cells[1].Value.ToString();
            txtDonGiaMA.Text = dtgvMonAn.CurrentRow.Cells[2].Value.ToString();
            txtDVTMA.Text = dtgvMonAn.CurrentRow.Cells[3].Value.ToString();
            cboNhomMA.SelectedValue = dtgvMonAn.CurrentRow.Cells[4].Value.ToString();
        }

        private void dtgvCTMA_SelectionChanged(object sender, EventArgs e)
        {
            txtMaCTMA.Text = dtgvCTMA.CurrentRow.Cells[0].Value.ToString();
            txtMaNLMA.Text = dtgvCTMA.CurrentRow.Cells[1].Value.ToString();
            txtKLNL.Text = dtgvCTMA.CurrentRow.Cells[2].Value.ToString();
            txtDVTNL.Text = dtgvCTMA.CurrentRow.Cells[3].Value.ToString();
        }
        
        private void btnChonHinhMA_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Pictures files (.jpg, *.jpeg, *.jpe, *.jfif, *.png)|.jpg; .jpeg; *.jpe; *.jfif; *.png|All files (.*)|*.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                hinhMA = op.FileName;
                picMA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                //picMA.Image = new Bitmap(hinhMA);
                picMA.Image = Image.FromFile(hinhMA);
            }
        }
        private void btnThemMA_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (txtTenMA.Text.Trim() == "" || txtDVTMA.Text.Trim() == "" || txtDonGiaMA.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin món ăn", "Báo lỗi");
                return;
            }

            DataRow them = dsMonAn.Tables["MonAn"].NewRow();
            them["MaMA"] = dsMonAn.Tables["MonAn"].Rows.Count + 1;
            them["TenMA"] = txtTenMA.Text;
            them["Gia"] = txtDonGiaMA.Text;
            them["DVT"] = txtDVTMA.Text;
            them["MaNMA"] = cboNhomMA.SelectedValue;
            if (hinhMA != null)
                them["HinhAnh"] = hinhMA;
            try
            {
                dsMonAn.Tables["MonAn"].Rows.Add(them);
                MessageBox.Show("Thêm thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại.", "Báo lỗi");
                return;
            }
        }

        private void btnXoaMA_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;

            //Kiểm tra khóa ngoại
            SqlDataAdapter daKT1 = new SqlDataAdapter("select * from CT_MONAN where MaMA=" + txtMaMA.Text, con);
            DataTable dtKT1 = new DataTable();
            daKT1.Fill(dtKT1);
            if (dtKT1.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            SqlDataAdapter daKT2 = new SqlDataAdapter("select * from CONGTHUCMA where MaMA=" + txtMaMA.Text, con);
            DataTable dtKT2 = new DataTable();
            daKT2.Fill(dtKT2);
            if (dtKT2.Rows.Count > 0)
            {
                MessageBox.Show("Dữ liệu đang được sử dụng.\nKhông thể xóa", "Báo lỗi");
                return;
            }

            //Xóa
            DataRow xoa = dsMonAn.Tables["MonAn"].Rows.Find(txtMaMA.Text);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }
        private void btnSuaMA_Click(object sender, EventArgs e)
        {
            
            DataRow sua = dsMonAn.Tables["MonAn"].Rows.Find(txtMaMA.Text);
            if (sua != null)
            {
                sua["TenMA"] = txtTenMA.Text;
                sua["Gia"] = txtDonGiaMA.Text;
                sua["DVT"] = txtDVTMA.Text;
                sua["MaNMA"] = cboNhomMA.SelectedValue;
                if (hinhMA != null)
                    sua["HinhAnh"] = chuyenImgSangByte(hinhMA);
                MessageBox.Show("Sửa thành công", "Thông báo");
            }
        }

        private void btnLuuMA_Click(object sender, EventArgs e)
        {
            try
            {
                daMonAn = new SqlDataAdapter("select * from MONAN", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daMonAn);
                daMonAn.Update(dsMonAn, "MonAn");
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Thông báo");
            }
        }

        private void btnHuyMA_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDataMA();
                return;
            }
        }
        private void mnuXoaMA_Click(object sender, EventArgs e)
        {
            btnXoaMA.PerformClick();
        }

        private void mnuSuaMA_Click(object sender, EventArgs e)
        {
            btnSuaMA.PerformClick();
        }




        //---------------------------------------------------//
        //Tab quản lý món ăn: thông tin nguyên liệu
        private void btnThemNLvaoMA_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaNLtrongMA_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;
            //Kiểm tra khóa ngoại
            

            //Xóa
            string[] timKiem = { txtMaCTMA.Text, txtMaNLMA.Text };
            DataRow xoa = dsCTMA.Tables["CongThucMonAn"].Rows.Find(timKiem);
            if (xoa != null)
            {
                xoa.Delete();
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
        }

        private void btnLuuNLvaoMA_Click(object sender, EventArgs e)
        {
            try
            {
                daCTMA = new SqlDataAdapter("select * from CT_CONGTHUC", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daCTMA);
                daCTMA.Update(dsCTMA, "CT_CONGTHUC");
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Thông báo");
            }
        }

        private void btnTimNL_Click(object sender, EventArgs e)
        {
            if (txtTimNL.Text.Trim() == "")
            {
                flpnNguyenLieu.Controls.Clear();
                foreach (DataRow item in dsNL.Tables["NguyenLieu"].Rows)
                {
                    DevComponents.DotNetBar.ButtonX btn = new ButtonX() { Width = 90, Height = 90 };
                    btn.Text = item["TenNL"].ToString();
                    btn.Tag = item;
                    flpnNguyenLieu.Controls.Add(btn);
                }
            }
            SqlDataAdapter daTim = new SqlDataAdapter("select * from NGUYENLIEU where TenNL like N'%" + txtTimNL.Text + "%'", con);
            DataSet dsTim = new DataSet();
            daTim.Fill(dsTim, "TimNguyenLieu");
            flpnNguyenLieu.Controls.Clear();
            foreach (DataRow item in dsTim.Tables["TimNguyenLieu"].Rows)
            {
                DevComponents.DotNetBar.ButtonX btn = new ButtonX() { Width = 90, Height = 90 };
                btn.Text = item["TenNL"].ToString();
                btn.Tag = item;
                flpnNguyenLieu.Controls.Add(btn);
            }
        }
        



        //---------------------------------------------//
        //Tab quản lý thêm người dùng
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            frmGhiChu frm = new frmGhiChu();
            frm.ShowDialog();
            string ma = dtgvNDnhomND.CurrentRow.Cells[0].Value.ToString();
            ten = dtgvNDnhomND.CurrentRow.Cells[1].Value.ToString();
            string[] kt = { ma, ten };
            try
            {
                DataRow sua = dsNDnhomND.Tables["NDnhomND"].Rows.Find(kt);
                if (sua != null)
                {
                    sua["GhiChu"] = frm.ghiChu;
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại","Báo lỗi");
                return;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daNDnhomND = new SqlDataAdapter("select * from  NGUOIDUNGNHOMNGUOIDUNG", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daNDnhomND);
                daNDnhomND.Update(dsNDnhomND, "NDnhomND");
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Báo lỗi");
                return;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = dtgvNDnhomND.CurrentRow.Cells[0].Value.ToString();
            ten = dtgvNDnhomND.CurrentRow.Cells[1].Value.ToString();
            string[] kt = { ma, ten };
            DataRow xoa = dsNDnhomND.Tables["NDnhomND"].Rows.Find(kt);
            if (xoa != null)
                xoa.Delete();
            MessageBox.Show("Xóa thành công", "Thông báo");
            //Chưa thêm vào sqlDataAdapter
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = cboNhomND.SelectedValue.ToString();
            string[] khoa = {ma,ten};
            DataRow ktra = dsNDnhomND.Tables["NDnhomND"].Rows.Find(khoa);
            if (ktra != null)
            {
                MessageBox.Show("Dữ liệu đang tồn tại.\nKhông thể thêm mới", "Báo lỗi");
                return;
            }
            DataRow them = dsNDnhomND.Tables["NDnhomND"].NewRow();
            them["MaNhomNguoiDung"] = cboNhomND.SelectedValue;
            them["TenDangNhap"] = ten;
            them["GhiChu"] = cboNhomND.Text;
            dsNDnhomND.Tables["NDnhomND"].Rows.Add(them);
            MessageBox.Show("Thêm thành công", "Thông báo");
        }

        private void mnuSuaNDnhomND_Click(object sender, EventArgs e)
        {
            btnCapNhat.PerformClick();
        }

        private void mnuXoaNDnhomND_Click(object sender, EventArgs e)
        {
            btnXoa.PerformClick();
        }


        //Chưa tìm ra
        private void dtgvChiTietPN_SelectionChanged(object sender, EventArgs e)
        {
            txtMaPN.Text = dtgvChiTietPN.CurrentRow.Cells[0].Value.ToString();
            txtSL.Text = dtgvChiTietPN.CurrentRow.Cells[2].Value.ToString();
            txtDonGia.Text = dtgvChiTietPN.CurrentRow.Cells[3].Value.ToString();
        }

        
        //Chưa xong
        private void dtgvPhanQuyen_SelectionChanged(object sender, EventArgs e)
        {
            string maManHinh = dtgvPhanQuyen.CurrentRow.Cells[1].Value.ToString();

        }

        private void btnThemNhomND_Click(object sender, EventArgs e)
        {
            if (txtTenNhomND.Text.Trim() == "" )
            {
                MessageBox.Show("Vui lòng nhập thông tin nhóm người dùng", "Báo lỗi");
                return;
            }

            DataRow them = dsNhomND.Tables["NhomND"].NewRow();
            them["MaNhomNguoiDung"] = dsNhomND.Tables["NhomND"].Rows.Count + 1;
            them["TenNhom"] = txtTenNhomND.Text;
            if(txtGhiChu.Text.Trim()!="")
                them["GhiChu"] = txtGhiChu.Text;
            try
            {
                dsNhomND.Tables["NhomND"].Rows.Add(them);
                MessageBox.Show("Thêm thành công.", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại.", "Báo lỗi");
                return;
            }
        }

        private void btnHuyNL2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lưu thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                loadDataCTPN();
                return;
            }
        }

        private void btnLuuNL2_Click(object sender, EventArgs e)
        {
            try
            {
                daCTPN = new SqlDataAdapter("select * from CT_PHIEUNHAP", con);
                SqlCommandBuilder cmb = new SqlCommandBuilder(daCTPN);
                daCTPN.Update(dsCTPN, "CT_PHIEUNHAP");
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Thông báo");
            }
        }

    }
}
