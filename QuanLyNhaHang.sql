CREATE DATABASE QUAN_LY_NHA_HANG;
USE QUAN_LY_NHA_HANG

CREATE TABLE NhanVien (
    MaNV INT IDENTITY PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15),
    ChucVu NVARCHAR(50),
    MatKhau NVARCHAR(50)
);

CREATE TABLE BanAn (
    MaBan INT IDENTITY PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(30) DEFAULT N'Trống' 
    -- 'Trống' | 'Đang phục vụ' | 'Đã thanh toán'
);

CREATE TABLE MonAn (
    MaMon INT IDENTITY PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    SoLuongTon INT DEFAULT 0,
    TrangThai NVARCHAR(30) DEFAULT N'Còn' 
    -- 'Còn' hoặc 'Hết'
);

CREATE TABLE HoaDon (
    MaHD INT IDENTITY PRIMARY KEY,
    MaBan INT REFERENCES BanAn(MaBan),
    MaNV INT REFERENCES NhanVien(MaNV),
    NgayLap DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(30) DEFAULT N'Chưa thanh toán'
    -- 'Chưa thanh toán' | 'Đã thanh toán'
);

CREATE TABLE ChiTietHoaDon (
    MaCTHD INT IDENTITY PRIMARY KEY,
    MaHD INT REFERENCES HoaDon(MaHD),
    MaMon INT REFERENCES MonAn(MaMon),
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2),
    ThanhTien AS (SoLuong * DonGia)
);

CREATE TABLE ThanhToan (
    MaTT INT IDENTITY PRIMARY KEY,
    MaHD INT REFERENCES HoaDon(MaHD),
    TongTien DECIMAL(18,2),
    NgayThanhToan DATETIME DEFAULT GETDATE(),
    HinhThuc NVARCHAR(30) -- Tiền mặt, Chuyển khoản, Momo, v.v.
);


	CREATE TRIGGER trg_Update_TrangThai_MonAn
ON MonAn
AFTER UPDATE
AS
BEGIN
    UPDATE MonAn
    SET TrangThai = CASE WHEN SoLuongTon <= 0 THEN N'Hết' ELSE N'Còn' END
    WHERE MaMon IN (SELECT MaMon FROM inserted);
END;
GO



	CREATE TRIGGER trg_Update_TrangThai_Ban_ThemHD
ON HoaDon
AFTER INSERT
AS
BEGIN
    UPDATE BanAn
    SET TrangThai = N'Đang phục vụ'
    WHERE MaBan IN (SELECT MaBan FROM inserted);
END;
GO



	CREATE TRIGGER trg_Update_TrangThai_SauThanhToan
ON ThanhToan
AFTER INSERT
AS
BEGIN
    UPDATE HoaDon
    SET TrangThai = N'Đã thanh toán'
    WHERE MaHD IN (SELECT MaHD FROM inserted);

    UPDATE BanAn
    SET TrangThai = N'Đã thanh toán'
    WHERE MaBan IN (
        SELECT MaBan FROM HoaDon WHERE MaHD IN (SELECT MaHD FROM inserted)
    );

    -- Sau 1 lúc, bạn có thể tự cập nhật lại bàn thành "Trống" (nếu cần).
END;
GO
