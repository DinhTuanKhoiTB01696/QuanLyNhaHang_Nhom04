namespace DTO_QLNH
{
    public class NguoiDung
    {
        public int MaND { get; set; }
        public string TenND { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public bool TrangThai { get; set; }

        // Các thuộc tính hiển thị tiện lợi
        public string TrangThaiText => TrangThai ? "Đang làm việc" : "Nghỉ việc";
    }
}
