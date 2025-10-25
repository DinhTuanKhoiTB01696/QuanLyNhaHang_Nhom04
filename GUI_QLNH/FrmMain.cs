using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI_QLNH;

namespace QuanLyNhaHang
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Addcontrols(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnexit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btndatban_Click_1(object sender, EventArgs e)
        {
            Addcontrols(new FrmQLDatBan());
            
        }

        private void btnNhanVien_Click_1(object sender, EventArgs e)
        {
            //Addcontrols(new FrmQLNhanVien());
        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            //Addcontrols(new FrmThanhToan());
        }

        private void btnbaocaothongke_Click_1(object sender, EventArgs e)
        {
            //Addcontrols(new FrmBaoCaoThongKe());
        }

        private void btntrangthaimenu_Click_1(object sender, EventArgs e)
        {
            //Addcontrols(new QLKhachHang());
        }
        private void btntrangthaidatban_Click_1(object sender, EventArgs e)
        {
            //Addcontrols(new FrmTrangThaiDatBan());
        }

        private void btnhome_Click(object sender, EventArgs e)
        {

        }
    }
}
