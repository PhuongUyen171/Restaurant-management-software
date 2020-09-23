namespace doAnDotNet
{
    partial class frmGhiChu
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.RichTextBox();
            this.btnNhap = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bổ sung ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(20, 55);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(266, 61);
            this.txtGhiChu.TabIndex = 1;
            this.txtGhiChu.Text = "";
            // 
            // btnNhap
            // 
            this.btnNhap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNhap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNhap.Location = new System.Drawing.Point(211, 138);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(75, 30);
            this.btnNhap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNhap.TabIndex = 3;
            this.btnNhap.Text = "Nhập";
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(130, 139);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 29);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmGhiChu
            // 
            this.ClientSize = new System.Drawing.Size(300, 182);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmGhiChu";
            this.Text = "frmGhiChu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private DevComponents.DotNetBar.ButtonX btnNhap;
        private DevComponents.DotNetBar.ButtonX btnThoat;
    }
}