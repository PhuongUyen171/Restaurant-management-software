namespace doAnDotNet
{
    partial class frmGopBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGopBan));
            this.btnHuy = new DevComponents.DotNetBar.ButtonX();
            this.btnGopBan = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.flpnGopBan = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHuy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHuy.Location = new System.Drawing.Point(315, 252);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(306, 44);
            this.btnHuy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            // 
            // btnGopBan
            // 
            this.btnGopBan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGopBan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGopBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGopBan.Location = new System.Drawing.Point(3, 252);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(306, 44);
            this.btnGopBan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGopBan.TabIndex = 1;
            this.btnGopBan.Text = "Gộp bàn";
            this.btnGopBan.Click += new System.EventHandler(this.btnGopBan_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnGopBan, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnHuy, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnThoat, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpnGopBan, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 299);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(546, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 30);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(185, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(124, 35);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "GỘP BÀN";
            // 
            // flpnGopBan
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flpnGopBan, 2);
            this.flpnGopBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnGopBan.Location = new System.Drawing.Point(3, 53);
            this.flpnGopBan.Name = "flpnGopBan";
            this.flpnGopBan.Size = new System.Drawing.Size(618, 193);
            this.flpnGopBan.TabIndex = 6;
            // 
            // frmGopBan
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(634, 302);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmGopBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGopBan";
            this.Load += new System.EventHandler(this.frmGopBan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX btnGopBan;
        private DevComponents.DotNetBar.ButtonX btnHuy;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.FlowLayoutPanel flpnGopBan;

    }
}