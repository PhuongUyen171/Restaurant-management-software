namespace doAnDotNet
{
    partial class frmDangNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResetPass = new DevComponents.DotNetBar.ButtonX();
            this.btnConnect = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnLogin);
            this.groupPanel1.Controls.Add(this.btnThoat);
            this.groupPanel1.Controls.Add(this.checkBox1);
            this.groupPanel1.Controls.Add(this.txtPass);
            this.groupPanel1.Controls.Add(this.txtUser);
            this.groupPanel1.Controls.Add(this.pictureBox1);
            this.groupPanel1.Controls.Add(this.panel1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(5, 1);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(374, 258);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Đăng nhập";
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(177, 125);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(11);
            this.btnLogin.Size = new System.Drawing.Size(75, 30);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(284, 125);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(11);
            this.btnThoat.Size = new System.Drawing.Size(75, 30);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(177, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 22);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Hiện mật khẩu";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtPass
            // 
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass.Location = new System.Drawing.Point(180, 53);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(159, 24);
            this.txtPass.TabIndex = 3;
            this.txtPass.WatermarkImage = ((System.Drawing.Image)(resources.GetObject("txtPass.WatermarkImage")));
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.Location = new System.Drawing.Point(180, 23);
            this.txtUser.Name = "txtUser";
            this.txtUser.PreventEnterBeep = true;
            this.txtUser.Size = new System.Drawing.Size(159, 24);
            this.txtUser.TabIndex = 2;
            this.txtUser.WatermarkImage = ((System.Drawing.Image)(resources.GetObject("txtUser.WatermarkImage")));
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 166);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnResetPass);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 45);
            this.panel1.TabIndex = 0;
            // 
            // btnResetPass
            // 
            this.btnResetPass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnResetPass.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnResetPass.Location = new System.Drawing.Point(239, 6);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(120, 30);
            this.btnResetPass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnResetPass.TabIndex = 1;
            this.btnResetPass.Text = "Đặt lại mật khẩu";
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConnect.Location = new System.Drawing.Point(9, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 30);
            this.btnConnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = " Cấu hình kết nối";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDangNhap";
            this.Text = "frmDangNhap";
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnResetPass;
        private DevComponents.DotNetBar.ButtonX btnConnect;

    }
}