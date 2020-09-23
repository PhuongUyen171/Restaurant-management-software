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
    public partial class frmGopBan : DevComponents.DotNetBar.RibbonForm
    {
        SqlConnection con;
        SqlDataAdapter daBan;
        DataSet dsBan= new DataSet();
        public frmGopBan()
        {
            con = new SqlConnection("Data Source=PHUONGUYEN\\PHUONGUYEN;Initial Catalog=QL_NhaHang;User ID=sa;Password=uyen");
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGopBan_Load(object sender, EventArgs e)
        {
            daBan = new SqlDataAdapter("select * from BAN", con);
            daBan.Fill(dsBan, "Ban");
            foreach (DataRow item in dsBan.Tables["Ban"].Rows)
            {
                DevComponents.DotNetBar.ButtonX btn = new ButtonX() { Width = 90, Height = 90 };
                btn.Text = "Bàn "+item["MaB"].ToString();
                btn.Click+=btn_Click;
                btn.Tag = item;
                btn.Image = Image.FromFile(@"C:\Users\Dell\Desktop\DeTai7\Hinh\table_48.png");
                btn.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                flpnGopBan.Controls.Add(btn);
            }
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn gộp hai bàn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.No)
                    return;
            //
        }
        private void btn_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn gộp hai bàn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                return;
        }
    }
}