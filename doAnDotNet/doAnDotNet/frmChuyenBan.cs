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
    public partial class frmChuyenBan : DevComponents.DotNetBar.RibbonForm
    {
        SqlConnection con;
        SqlDataAdapter daBan;
        DataSet dsBan = new DataSet();
        int b1, b2;
        public frmChuyenBan()
        {
            if (con == null)
                con = new SqlConnection(@"Data Source=PHUONGUYEN\PHUONGUYEN;Initial Catalog=QL_NhaHang;User ID=sa;Password=uyen");
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChuyenBan_Load(object sender, EventArgs e)
        {
            loadDuLieu();
            loadBan();
        }
        public void loadDuLieu()
        {
            //Bàn
            daBan = new SqlDataAdapter("select * from BAN", con);
            daBan.Fill(dsBan, "Ban");
        }
        public void loadBan()
        {
            List<Ban> listBan = loadDSBan();
            foreach (Ban item in listBan)
            {
                if (item.tinhTrang.ToString() == "Đã Đặt" || item.tinhTrang.ToString() == "Hết")
                {
                    DevComponents.DotNetBar.ButtonX btnP = new ButtonX() { Width = 90, Height = 90 };
                    btnP.Text = "Bàn " + item.maBan.ToString() + Environment.NewLine + item.tinhTrang.ToString();
                    btnP.BackColor = Color.LightPink;
                    btnP.Tag = item;
                    btnP.Click += btnP_Click;
                    flpnFrom.Controls.Add(btnP);
                }
                else
                {
                    DevComponents.DotNetBar.ButtonX btnT = new ButtonX() { Width = 90, Height = 90 };
                    btnT.Text = "Bàn " + item.maBan.ToString() + Environment.NewLine + item.tinhTrang.ToString();
                    btnT.BackColor = Color.LightPink;
                    btnT.Tag = item;
                    btnT.Click += btnT_Click;
                    flpnTo.Controls.Add(btnT);
                }
            }
        }
        void btnT_Click(object sender, EventArgs e)
        {
            b1 = ((sender as DevComponents.DotNetBar.ButtonX).Tag as Ban).maBan;
            string ma = "Bàn " + b1;
            lbTo.Text=ma;
        }
        void btnP_Click(object sender, EventArgs e)
        {
            b2 = ((sender as DevComponents.DotNetBar.ButtonX).Tag as Ban).maBan;
            string ma = "Bàn " + b2;
            lbFrom.Text = ma;
        }

        public List<Ban> loadDSBan()
        {
            List<Ban> listBan = new List<Ban>();

            foreach (DataRow item in dsBan.Tables["Ban"].Rows)
            {
                Ban b = new Ban(item);
                listBan.Add(b);
            }
            return listBan;
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            chuyenBan(b1, b2);
        }
        public void chuyenBan(int b1, int b2)
        {
            SqlDataAdapter daChuyen = new SqlDataAdapter("execute chuyen_ban "+b1+","+b2,con);
            SqlCommandBuilder cmb = new SqlCommandBuilder(daChuyen);
            
            daChuyen.Update(dsBan,"Ban");
            flpnFrom.Controls.Clear();
            flpnTo.Controls.Clear();
            loadBan();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daChuyen = new SqlDataAdapter("execute huy_chuyen_ban ", con);
            SqlCommandBuilder cmb = new SqlCommandBuilder(daChuyen);

            daChuyen.Update(dsBan, "Ban");
            flpnFrom.Controls.Clear();
            flpnTo.Controls.Clear();
            loadBan();
        }
    }
}