namespace GUI_QLNH
{
    partial class FrmTrangThaiMenu
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThucDon;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgvThucDon = new Guna.UI2.WinForms.Guna2DataGridView();
            Mamon = new DataGridViewTextBoxColumn();
            ten = new DataGridViewTextBoxColumn();
            Gia = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            btnThem = new Guna.UI2.WinForms.Guna2Button();
            txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            btnLuu = new Guna.UI2.WinForms.Guna2Button();
            btnDong = new Guna.UI2.WinForms.Guna2Button();
            btnsua = new Guna.UI2.WinForms.Guna2Button();
            btnlammoi = new Guna.UI2.WinForms.Guna2Button();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvThucDon).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvThucDon
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvThucDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvThucDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvThucDon.ColumnHeadersHeight = 29;
            dgvThucDon.Columns.AddRange(new DataGridViewColumn[] { Mamon, ten, Gia, TrangThai });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvThucDon.DefaultCellStyle = dataGridViewCellStyle3;
            dgvThucDon.GridColor = Color.FromArgb(231, 229, 255);
            dgvThucDon.Location = new Point(50, 129);
            dgvThucDon.Margin = new Padding(3, 4, 3, 4);
            dgvThucDon.Name = "dgvThucDon";
            dgvThucDon.RowHeadersVisible = false;
            dgvThucDon.RowHeadersWidth = 51;
            dgvThucDon.RowTemplate.Height = 40;
            dgvThucDon.Size = new Size(680, 375);
            dgvThucDon.TabIndex = 5;
            dgvThucDon.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvThucDon.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvThucDon.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvThucDon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvThucDon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvThucDon.ThemeStyle.BackColor = Color.White;
            dgvThucDon.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvThucDon.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvThucDon.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvThucDon.ThemeStyle.HeaderStyle.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvThucDon.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvThucDon.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvThucDon.ThemeStyle.HeaderStyle.Height = 29;
            dgvThucDon.ThemeStyle.ReadOnly = false;
            dgvThucDon.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvThucDon.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvThucDon.ThemeStyle.RowsStyle.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvThucDon.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvThucDon.ThemeStyle.RowsStyle.Height = 40;
            dgvThucDon.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvThucDon.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // Mamon
            // 
            Mamon.HeaderText = "Mã Món";
            Mamon.MinimumWidth = 6;
            Mamon.Name = "Mamon";
            // 
            // ten
            // 
            ten.HeaderText = "Tên Món";
            ten.MinimumWidth = 6;
            ten.Name = "ten";
            // 
            // Gia
            // 
            Gia.HeaderText = "Giá";
            Gia.MinimumWidth = 6;
            Gia.Name = "Gia";
            // 
            // TrangThai
            // 
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            // 
            // btnThem
            // 
            btnThem.BorderRadius = 10;
            btnThem.CustomizableEdges = customizableEdges1;
            btnThem.FillColor = Color.FromArgb(38, 166, 154);
            btnThem.Font = new Font("Segoe UI", 9F);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(50, 600);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnThem.Size = new Size(101, 57);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderRadius = 10;
            txtTimKiem.Cursor = Cursors.IBeam;
            txtTimKiem.CustomizableEdges = customizableEdges3;
            txtTimKiem.DefaultText = "";
            txtTimKiem.Font = new Font("Segoe UI", 9F);
            txtTimKiem.Location = new Point(50, 525);
            txtTimKiem.Margin = new Padding(3, 5, 3, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "🔍 Tìm kiếm...";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtTimKiem.Size = new Size(680, 50);
            txtTimKiem.TabIndex = 2;
            // 
            // btnLuu
            // 
            btnLuu.BorderRadius = 10;
            btnLuu.CustomizableEdges = customizableEdges5;
            btnLuu.Font = new Font("Segoe UI", 9F);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(444, 600);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLuu.Size = new Size(140, 57);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "Lưu Thay Đổi";
            // 
            // btnDong
            // 
            btnDong.BorderRadius = 10;
            btnDong.CustomizableEdges = customizableEdges7;
            btnDong.FillColor = Color.FromArgb(239, 83, 80);
            btnDong.Font = new Font("Segoe UI", 9F);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(590, 600);
            btnDong.Margin = new Padding(3, 4, 3, 4);
            btnDong.Name = "btnDong";
            btnDong.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnDong.Size = new Size(140, 57);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng";
            // 
            // btnsua
            // 
            btnsua.BorderRadius = 10;
            btnsua.CustomizableEdges = customizableEdges9;
            btnsua.FillColor = Color.FromArgb(255, 167, 38);
            btnsua.Font = new Font("Segoe UI", 9F);
            btnsua.ForeColor = Color.White;
            btnsua.Location = new Point(157, 600);
            btnsua.Margin = new Padding(3, 4, 3, 4);
            btnsua.Name = "btnsua";
            btnsua.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnsua.Size = new Size(101, 57);
            btnsua.TabIndex = 7;
            btnsua.Text = "Sửa";
            // 
            // btnlammoi
            // 
            btnlammoi.BorderRadius = 10;
            btnlammoi.CustomizableEdges = customizableEdges11;
            btnlammoi.FillColor = Color.Olive;
            btnlammoi.Font = new Font("Segoe UI", 9F);
            btnlammoi.ForeColor = Color.White;
            btnlammoi.Location = new Point(264, 600);
            btnlammoi.Margin = new Padding(3, 4, 3, 4);
            btnlammoi.Name = "btnlammoi";
            btnlammoi.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnlammoi.Size = new Size(101, 57);
            btnlammoi.TabIndex = 8;
            btnlammoi.Text = "Làm Mới";
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(2, 136, 209);
            lblTitle.Location = new Point(223, 13);
            lblTitle.Margin = new Padding(3, 4, 3, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(303, 43);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "QUẢN LÝ THỰC ĐƠN";
            lblTitle.Click += lblTitle_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblTitle);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 69);
            panel2.TabIndex = 27;
            // 
            // FrmTrangThaiMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(800, 700);
            Controls.Add(panel2);
            Controls.Add(btnlammoi);
            Controls.Add(btnsua);
            Controls.Add(btnDong);
            Controls.Add(btnLuu);
            Controls.Add(txtTimKiem);
            Controls.Add(btnThem);
            Controls.Add(dgvThucDon);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmTrangThaiMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ THỰC ĐƠN";
            ((System.ComponentModel.ISupportInitialize)dgvThucDon).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Mamon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private Guna.UI2.WinForms.Guna2Button btnsua;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private Guna.UI2.WinForms.Guna2Button btnlammoi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Panel panel2;
    }
}