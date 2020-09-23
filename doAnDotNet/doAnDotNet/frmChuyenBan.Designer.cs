namespace doAnDotNet
{
    partial class frmChuyenBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenBan));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnChuyen = new DevComponents.DotNetBar.ButtonX();
            this.btnHuy = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lbFrom = new DevComponents.DotNetBar.LabelX();
            this.flpnFrom = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lbTo = new DevComponents.DotNetBar.LabelX();
            this.flpnTo = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnChuyen, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnHuy, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnThoat, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flpnFrom, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.flpnTo, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(640, 338);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.labelX1, 2);
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(389, 44);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "CHUYỂN BÀN";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnChuyen
            // 
            this.btnChuyen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChuyen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChuyen.Location = new System.Drawing.Point(248, 53);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(144, 35);
            this.btnChuyen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChuyen.TabIndex = 3;
            this.btnChuyen.Text = "Chuyển";
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHuy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHuy.Location = new System.Drawing.Point(248, 103);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(144, 35);
            this.btnHuy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(557, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 30);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel1.Controls.Add(this.labelX2);
            this.flowLayoutPanel1.Controls.Add(this.lbFrom);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 53);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(239, 44);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(149, 19);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Chọn bàn cần chuyển:";
            // 
            // lbFrom
            // 
            // 
            // 
            // 
            this.lbFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbFrom.ForeColor = System.Drawing.Color.Coral;
            this.lbFrom.Location = new System.Drawing.Point(158, 3);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(75, 23);
            this.lbFrom.TabIndex = 1;
            this.lbFrom.Text = "null";
            // 
            // flpnFrom
            // 
            this.flpnFrom.AutoScroll = true;
            this.flpnFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flpnFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnFrom.Location = new System.Drawing.Point(3, 103);
            this.flpnFrom.Name = "flpnFrom";
            this.flpnFrom.Size = new System.Drawing.Size(239, 232);
            this.flpnFrom.TabIndex = 8;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel3.Controls.Add(this.labelX3);
            this.flowLayoutPanel3.Controls.Add(this.lbTo);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(398, 53);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(239, 44);
            this.flowLayoutPanel3.TabIndex = 9;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(3, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(145, 19);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Chọn bàn chuyển đến";
            // 
            // lbTo
            // 
            // 
            // 
            // 
            this.lbTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTo.ForeColor = System.Drawing.Color.Coral;
            this.lbTo.Location = new System.Drawing.Point(154, 3);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(75, 23);
            this.lbTo.TabIndex = 1;
            this.lbTo.Text = "null";
            // 
            // flpnTo
            // 
            this.flpnTo.AutoScroll = true;
            this.flpnTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flpnTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnTo.Location = new System.Drawing.Point(398, 103);
            this.flpnTo.Name = "flpnTo";
            this.flpnTo.Size = new System.Drawing.Size(239, 232);
            this.flpnTo.TabIndex = 10;
            // 
            // frmChuyenBan
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(650, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmChuyenBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChuyenBan";
            this.Load += new System.EventHandler(this.frmChuyenBan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnChuyen;
        private DevComponents.DotNetBar.ButtonX btnHuy;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lbFrom;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.FlowLayoutPanel flpnFrom;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private DevComponents.DotNetBar.LabelX lbTo;
        private System.Windows.Forms.FlowLayoutPanel flpnTo;
    }
}