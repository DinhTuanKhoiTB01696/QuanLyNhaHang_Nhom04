namespace QuanLyNhaHang
{
    partial class FormDatLaiMatKhau
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhauMoi;
        private Guna.UI2.WinForms.Guna2TextBox txtXacNhanMatKhau;
        private Guna.UI2.WinForms.Guna2Button btnLuuMatKhau;
        private Guna.UI2.WinForms.Guna2Button btnQuayLai;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picKey;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatLaiMatKhau));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtMatKhauMoi = new Guna.UI2.WinForms.Guna2TextBox();
            txtXacNhanMatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            btnLuuMatKhau = new Guna.UI2.WinForms.Guna2Button();
            btnQuayLai = new Guna.UI2.WinForms.Guna2Button();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            picKey = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)picKey).BeginInit();
            SuspendLayout();
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.BorderRadius = 10;
            txtMatKhauMoi.CustomizableEdges = customizableEdges10;
            txtMatKhauMoi.DefaultText = "";
            txtMatKhauMoi.Font = new Font("Segoe UI", 9F);
            txtMatKhauMoi.Location = new Point(90, 175);
            txtMatKhauMoi.Margin = new Padding(3, 4, 3, 4);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '●';
            txtMatKhauMoi.PlaceholderText = "Mật khẩu mới";
            txtMatKhauMoi.SelectedText = "";
            txtMatKhauMoi.ShadowDecoration.CustomizableEdges = customizableEdges11;
            txtMatKhauMoi.Size = new Size(250, 45);
            txtMatKhauMoi.TabIndex = 3;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.BorderRadius = 10;
            txtXacNhanMatKhau.CustomizableEdges = customizableEdges12;
            txtXacNhanMatKhau.DefaultText = "";
            txtXacNhanMatKhau.Font = new Font("Segoe UI", 9F);
            txtXacNhanMatKhau.Location = new Point(90, 235);
            txtXacNhanMatKhau.Margin = new Padding(3, 4, 3, 4);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PasswordChar = '●';
            txtXacNhanMatKhau.PlaceholderText = "Xác nhận mật khẩu";
            txtXacNhanMatKhau.SelectedText = "";
            txtXacNhanMatKhau.ShadowDecoration.CustomizableEdges = customizableEdges13;
            txtXacNhanMatKhau.Size = new Size(250, 45);
            txtXacNhanMatKhau.TabIndex = 2;
            // 
            // btnLuuMatKhau
            // 
            btnLuuMatKhau.BorderRadius = 10;
            btnLuuMatKhau.CustomizableEdges = customizableEdges14;
            btnLuuMatKhau.FillColor = Color.Teal;
            btnLuuMatKhau.Font = new Font("Segoe UI", 9F);
            btnLuuMatKhau.ForeColor = Color.White;
            btnLuuMatKhau.Location = new Point(90, 300);
            btnLuuMatKhau.Name = "btnLuuMatKhau";
            btnLuuMatKhau.ShadowDecoration.CustomizableEdges = customizableEdges15;
            btnLuuMatKhau.Size = new Size(250, 45);
            btnLuuMatKhau.TabIndex = 1;
            btnLuuMatKhau.Text = "Lưu mật khẩu";
            // 
            // btnQuayLai
            // 
            btnQuayLai.BorderRadius = 10;
            btnQuayLai.CustomizableEdges = customizableEdges16;
            btnQuayLai.FillColor = Color.Gray;
            btnQuayLai.Font = new Font("Segoe UI", 9F);
            btnQuayLai.ForeColor = Color.White;
            btnQuayLai.Location = new Point(90, 360);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.ShadowDecoration.CustomizableEdges = customizableEdges17;
            btnQuayLai.Size = new Size(250, 40);
            btnQuayLai.TabIndex = 0;
            btnQuayLai.Text = "Quay lại";
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(108, 121);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(219, 33);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "ĐẶT LẠI MẬT KHẨU";
            // 
            // picKey
            // 
            picKey.Image = (Image)resources.GetObject("picKey.Image");
            picKey.ImageRotate = 0F;
            picKey.Location = new Point(175, 25);
            picKey.Name = "picKey";
            picKey.ShadowDecoration.CustomizableEdges = customizableEdges18;
            picKey.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picKey.Size = new Size(90, 90);
            picKey.SizeMode = PictureBoxSizeMode.Zoom;
            picKey.TabIndex = 5;
            picKey.TabStop = false;
            // 
            // FormDatLaiMatKhau
            // 
            BackColor = Color.Beige;
            ClientSize = new Size(444, 430);
            Controls.Add(btnQuayLai);
            Controls.Add(btnLuuMatKhau);
            Controls.Add(txtXacNhanMatKhau);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(lblTitle);
            Controls.Add(picKey);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDatLaiMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đặt Lại Mật Khẩu";
            ((System.ComponentModel.ISupportInitialize)picKey).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}