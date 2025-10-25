-- 1️ Tạo database
CREATE DATABASE QLNhaHang;
GO
USE QLNhaHang;
GO

------------------------------------------------------------
-- 2️ Bảng Người dùng (Nhân viên / Quản lý / Bếp / Thu ngân / Lễ tân)
CREATE TABLE NguoiDung (
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    TenND NVARCHAR(100) NOT NULL,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(100) NOT NULL,
    VaiTro NVARCHAR(50) NOT NULL,  -- Quản lý / Thu ngân / Phục vụ / Lễ tân / Bếp
    TrangThai BIT DEFAULT 1         -- 1: đang làm việc, 0: nghỉ
);
------------------------------------------------------------

-- 3️ Bảng Trạng thái đặt bàn
CREATE TABLE TrangThaiDatBan (
    MaTT INT IDENTITY(1,1) PRIMARY KEY,
    TenTT NVARCHAR(50) NOT NULL  -- VD: Đã đặt, Đang phục vụ, Đã thanh toán, Đã hủy
);
------------------------------------------------------------

-- 4️ Bảng Bàn ăn
CREATE TABLE BanAn (
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    ViTri NVARCHAR(100),
    SoGhe INT,
    TrangThai NVARCHAR(50) DEFAULT N'Trống'  -- Trống / Đã đặt / Đang phục vụ
);
------------------------------------------------------------

-- 5️ Bảng Loại món ăn
CREATE TABLE LoaiMonAn (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL
);
------------------------------------------------------------

-- 6️ Bảng Món ăn
CREATE TABLE MonAn (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    DonViTinh NVARCHAR(50),
    MaLoai INT FOREIGN KEY REFERENCES LoaiMonAn(MaLoai),
    TrangThai BIT DEFAULT 1   -- 1: còn bán, 0: ngừng bán
);
------------------------------------------------------------

-- 7️ Bảng Đặt bàn
CREATE TABLE DatBan (
    MaDatBan INT IDENTITY PRIMARY KEY,
    TenKhach NVARCHAR(50),
    SoDienThoai VARCHAR(15),
    MaBan INT FOREIGN KEY REFERENCES BanAn(MaBan),
    MaNV INT FOREIGN KEY REFERENCES NguoiDung(MaND),
    MaTT INT FOREIGN KEY REFERENCES TrangThaiDatBan(MaTT),
    ThoiGianDat DATETIME,
    GioDen DATETIME NULL,
    GioDi DATETIME NULL,
    GhiChu NVARCHAR(100)
);
------------------------------------------------------------

-- 8️ Bảng Chi tiết đặt món
CREATE TABLE ChiTietDatMon (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaDatBan INT FOREIGN KEY REFERENCES DatBan(MaDatBan) ON DELETE CASCADE,
    MaMon INT FOREIGN KEY REFERENCES MonAn(MaMon),
    SoLuong INT DEFAULT 1,
    ThanhTien DECIMAL(18,2) NULL
);
------------------------------------------------------------

-- 9️ Bảng Hóa đơn thanh toán
CREATE TABLE HoaDonThanhToan (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaDatBan INT FOREIGN KEY REFERENCES DatBan(MaDatBan),
    NgayThanhToan DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2),
    GiamGia DECIMAL(18,2) DEFAULT 0,
    ThucThu AS (TongTien - GiamGia) PERSISTED,
    MaNV INT FOREIGN KEY REFERENCES NguoiDung(MaND)
);
------------------------------------------------------------

-- 🔟 DỮ LIỆU MẪU -------------------------------------------------

-- Người dùng
INSERT INTO NguoiDung (TenND, TenDangNhap, MatKhau, VaiTro, TrangThai)
VALUES 
(N'Nguyễn Văn An', 'anpv', '123', N'Phục vụ', 1),
(N'Lê Thị Hoa', 'hoalt', '123', N'Thu ngân', 1),
(N'Trần Quốc Bảo', 'baotq', '123', N'Quản lý', 1),
(N'Phạm Ngọc Hân', 'hanpn', '123', N'Lễ tân', 1),
(N'Lưu Văn Thắng', 'thanglv', '123', N'Bếp', 1);

-- Loại món ăn
INSERT INTO LoaiMonAn (TenLoai)
VALUES 
(N'Món chính'),
(N'Khai vị'),
(N'Tráng miệng'),
(N'Đồ uống');

-- Món ăn
INSERT INTO MonAn (TenMon, DonGia, DonViTinh, MaLoai, TrangThai)
VALUES 
-- 🍛 Món chính
(N'Cơm chiên hải sản', 55000, N'Đĩa', 1, 1),
(N'Bò lúc lắc khoai tây', 95000, N'Đĩa', 1, 1),
(N'Cá basa kho tộ', 75000, N'Phần', 1, 1),
(N'Thịt kho trứng', 65000, N'Phần', 1, 1),
(N'Gà nướng mật ong', 85000, N'Phần', 1, 1),

-- 🥗 Khai vị
(N'Gỏi cuốn tôm thịt', 40000, N'Phần', 2, 1),
(N'Súp cua trứng bắc thảo', 35000, N'Chén', 2, 1),
(N'Gỏi ngó sen tôm thịt', 45000, N'Đĩa', 2, 1),
(N'Chả giò hải sản', 42000, N'Phần', 2, 1),

-- 🍮 Tráng miệng
(N'Bánh flan caramel', 25000, N'Cái', 3, 1),
(N'Chè khúc bạch', 30000, N'Chén', 3, 1),
(N'Trái cây dĩa', 35000, N'Dĩa', 3, 1),

-- 🍹 Đồ uống
(N'Trà đào cam sả', 35000, N'Ly', 4, 1),
(N'Cà phê sữa đá', 30000, N'Ly', 4, 1),
(N'Nước suối', 15000, N'Chai', 4, 1),
(N'Nước cam ép', 30000, N'Ly', 4, 1),
(N'Sinh tố bơ', 40000, N'Ly', 4, 1);


-- Bàn ăn
INSERT INTO BanAn (TenBan, ViTri, SoGhe, TrangThai)
VALUES 
(N'Bàn 1', N'Tầng 1', 4, N'Trống'),
(N'Bàn 2', N'Tầng 1', 4, N'Trống'),
(N'Bàn 3', N'Tầng 2', 6, N'Trống'),
(N'Bàn 4', N'Tầng 2', 8, N'Trống'),
(N'Bàn 5', N'Sân vườn', 4, N'Trống');

-- Trạng thái đặt bàn
INSERT INTO TrangThaiDatBan (TenTT)
VALUES 
(N'Đã đặt'),
(N'Đang phục vụ'),
(N'Đã thanh toán'),
(N'Đã hủy');

-- Đặt bàn
INSERT INTO DatBan (TenKhach, SoDienThoai, MaBan, MaNV, MaTT, ThoiGianDat, GioDen, GioDi, GhiChu)
VALUES
(N'Trần Minh Khang', '0988777666', 1, 1, 2, '2025-10-24 19:30:00', '2025-10-24 20:00:00', NULL, N'Khách quen'),
(N'Lê Hồng Nhung', '0977665544', 2, 1, 1, '2025-10-24 18:45:00', NULL, NULL, N'Đặt bàn trước'),
(N'Nguyễn Thanh Tùng', '0911222333', 3, 4, 2, '2025-10-24 20:10:00', '2025-10-24 20:30:00', NULL, N'Đang phục vụ'),
(N'Phạm Anh Tuấn', '0909555444', 4, 1, 3, '2025-10-24 17:00:00', '2025-10-24 17:15:00', '2025-10-24 18:00:00', N'Đã thanh toán'),
(N'Lý Ngọc Mai', '0933111222', 5, 4, 4, '2025-10-24 16:30:00', NULL, NULL, N'Hủy do đổi kế hoạch');

-- Chi tiết đặt món
INSERT INTO ChiTietDatMon (MaDatBan, MaMon, SoLuong)
VALUES 
(1, 1, 2),  
(1, 6, 2),  
(2, 2, 3),  
(2, 8, 2),  
(3, 3, 1),  
(3, 6, 2),  
(4, 1, 2),  
(4, 5, 2),  
(4, 7, 2),  
(5, 2, 1);

-- Hóa đơn thanh toán
INSERT INTO HoaDonThanhToan (MaDatBan, TongTien, GiamGia, MaNV)
VALUES 
(4, 260000, 10000, 2),  
(1, 180000, 0, 2);
