namespace GUI_QLNH
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            FrmThanhToan f = new FrmThanhToan();
            this.Show(); // ?n form hi?n t?i
            f.ShowDialog(); // Hi?n form m?i và ch? ?óng
            this.Show(); // Khi ?óng form m?i thì hi?n l?i form c?
        }
    }
}
