USE [library_Manager]
GO
/****** Object:  Table [dbo].[CHUCNANG]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCNANG](
	[Ma_ChucNang] [varchar](50) NOT NULL,
	[Ten_ChucNang] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CHUCNANG] PRIMARY KEY CLUSTERED 
(
	[Ma_ChucNang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAI_TAIKHOAN]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI_TAIKHOAN](
	[Ma_LoaiTK] [varchar](50) NOT NULL,
	[Ten_LoaiTK] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LOAI_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[Ma_LoaiTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NXB]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NXB](
	[MaNXB] [nvarchar](50) NOT NULL,
	[TenNXB] [nvarchar](100) NOT NULL,
	[DienThoai] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[Ma_LoaiTK] [varchar](50) NOT NULL,
	[Ma_ChucNang] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PHANQUYEN] PRIMARY KEY CLUSTERED 
(
	[Ma_LoaiTK] ASC,
	[Ma_ChucNang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuMuon]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuMuon](
	[MaPhieuMuon] [nvarchar](50) NOT NULL,
	[MaSinhVien] [nvarchar](50) NULL,
	[NgayMuon] [date] NULL,
	[NgayTraDuKien] [date] NULL,
	[NgayTraThucTe] [date] NULL,
	[TinhTrang] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[MaSach] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nvarchar](50) NOT NULL,
	[TenSach] [nvarchar](255) NOT NULL,
	[MaLoaiSach] [nvarchar](50) NULL,
	[NamXB] [int] NULL,
	[MaNXB] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[MaViTri] [nvarchar](50) NULL,
	[MaTacGia] [nvarchar](50) NULL,
	[NgonNgu] [nvarchar](50) NULL,
	[TimeCreate] [datetime] NULL,
	[TimeUpdate] [datetime] NULL,
	[ImagePath] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSinhVien] [nvarchar](50) NOT NULL,
	[TenSinhVien] [nvarchar](255) NOT NULL,
	[NgaySinh] [date] NULL,
	[Email] [nvarchar](200) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[DienThoai] [nvarchar](20) NULL,
	[TaiKhoan] [nvarchar](100) NULL,
	[MatKhau] [nvarchar](100) NULL,
 CONSTRAINT [PK__SinhVien__939AE7759E29EB11] PRIMARY KEY CLUSTERED 
(
	[MaSinhVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTacGia] [nvarchar](50) NOT NULL,
	[TenTacGia] [nvarchar](255) NOT NULL,
	[DienThoai] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[Username] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Ma_LoaiTK] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTheLoai] [nvarchar](50) NOT NULL,
	[TenTheLoai] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ViTri]    Script Date: 6/3/2024 5:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViTri](
	[MaViTri] [nvarchar](50) NOT NULL,
	[Ngan] [nvarchar](255) NULL,
	[Ke] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaViTri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CHUCNANG] ([Ma_ChucNang], [Ten_ChucNang]) VALUES (N'A001', N'Chức năng Admin')
INSERT [dbo].[CHUCNANG] ([Ma_ChucNang], [Ten_ChucNang]) VALUES (N'B001', N'Xem danh mục Sách')
INSERT [dbo].[CHUCNANG] ([Ma_ChucNang], [Ten_ChucNang]) VALUES (N'B002', N'Xem chi tiết Sách')
INSERT [dbo].[CHUCNANG] ([Ma_ChucNang], [Ten_ChucNang]) VALUES (N'B003', N'Tạo sách mới')
INSERT [dbo].[CHUCNANG] ([Ma_ChucNang], [Ten_ChucNang]) VALUES (N'B004', N'Thay đổi thông tin')
INSERT [dbo].[CHUCNANG] ([Ma_ChucNang], [Ten_ChucNang]) VALUES (N'B005', N'Xóa Sách')
GO
INSERT [dbo].[LOAI_TAIKHOAN] ([Ma_LoaiTK], [Ten_LoaiTK]) VALUES (N'ADMIN', N'Admin')
INSERT [dbo].[LOAI_TAIKHOAN] ([Ma_LoaiTK], [Ten_LoaiTK]) VALUES (N'SINHVIEN', N'Sinh Viên')
GO
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [DienThoai], [DiaChi]) VALUES (N'1', N'NXB Hưng Yên', N'123456789', N'Hưng Yên')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [DienThoai], [DiaChi]) VALUES (N'2', N'NXB Hà Nội', N'0944098635', N'Hà Nội')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [DienThoai], [DiaChi]) VALUES (N'3', N'NXB Bình Dương', N'987456321', N'Bình Dương')
GO
INSERT [dbo].[PHANQUYEN] ([Ma_LoaiTK], [Ma_ChucNang]) VALUES (N'ADMIN', N'A001')
INSERT [dbo].[PHANQUYEN] ([Ma_LoaiTK], [Ma_ChucNang]) VALUES (N'ADMIN', N'B001')
INSERT [dbo].[PHANQUYEN] ([Ma_LoaiTK], [Ma_ChucNang]) VALUES (N'ADMIN', N'B002')
INSERT [dbo].[PHANQUYEN] ([Ma_LoaiTK], [Ma_ChucNang]) VALUES (N'ADMIN', N'B003')
INSERT [dbo].[PHANQUYEN] ([Ma_LoaiTK], [Ma_ChucNang]) VALUES (N'ADMIN', N'B004')
INSERT [dbo].[PHANQUYEN] ([Ma_LoaiTK], [Ma_ChucNang]) VALUES (N'ADMIN', N'B005')
INSERT [dbo].[PHANQUYEN] ([Ma_LoaiTK], [Ma_ChucNang]) VALUES (N'SINHVIEN', N'B001')
INSERT [dbo].[PHANQUYEN] ([Ma_LoaiTK], [Ma_ChucNang]) VALUES (N'SINHVIEN', N'B002')
GO
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [MaSinhVien], [NgayMuon], [NgayTraDuKien], [NgayTraThucTe], [TinhTrang], [GhiChu], [MaSach]) VALUES (N'PM_000001', N'2180607460', CAST(N'2000-04-16' AS Date), CAST(N'2000-04-18' AS Date), CAST(N'2000-04-18' AS Date), N'Đã trả', N'ko', N'Sach_000007')
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000001', N'Chú Thuật Hồi Chiến', N'9', 2019, N'2', 20, N'1A', N'2', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000001.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000002', N'Toán Học 10', N'5', 2000, N'1', 1, N'1A', N'1', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000002.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000003', N'Hóa Học 10', N'5', 2000, N'1', 10, N'1A', N'1', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000003.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000004', N'Doraemon', N'9', 2000, N'1', 20, N'1A', N'1', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000004.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000005', N'Dragonball', N'9', 2000, N'3', 2, N'1A', N'1', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000005.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000006', N'THỢ RÈN HUYỀN THOẠI', N'4', 2000, N'1', 1, N'1A', N'2', N'Anh Văn', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000006.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000007', N'THE BOXER', N'4', 2000, N'2', 1, N'1A', N'2', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000007.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000008', N'Lịch Sử 10', N'5', 2000, N'1', 1, N'1A', N'1', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000008.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000009', N'ANH HÙNG ONEPUNCH', N'10', 2000, N'2', 2, N'1A', N'1', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000009.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000010', N'Conan', N'10', 2000, N'1', 10, N'1A', N'1', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'sachSach_000010.jpg')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoaiSach], [NamXB], [MaNXB], [SoLuong], [MaViTri], [MaTacGia], [NgonNgu], [TimeCreate], [TimeUpdate], [ImagePath]) VALUES (N'Sach_000011', N'Thăng Cấp 1 Mình', N'10', 2000, N'2', 20, N'1A', N'1', N'Tiếng Việt', CAST(N'2000-04-14T00:00:00.000' AS DateTime), CAST(N'2000-04-14T00:00:00.000' AS DateTime), N'Sach_000011.jpg')
GO
INSERT [dbo].[SinhVien] ([MaSinhVien], [TenSinhVien], [NgaySinh], [Email], [GioiTinh], [DiaChi], [DienThoai], [TaiKhoan], [MatKhau]) VALUES (N'2180607460', N'Hoàng Hà', CAST(N'2003-01-08' AS Date), N'hoangha8103@gmail.com', N'Nam', N'Quận 9', N'0123528795', N'hoangha', N'1234')
INSERT [dbo].[SinhVien] ([MaSinhVien], [TenSinhVien], [NgaySinh], [Email], [GioiTinh], [DiaChi], [DienThoai], [TaiKhoan], [MatKhau]) VALUES (N'2180607498', N'Hoàng Anh', CAST(N'2003-08-01' AS Date), N'kien@gmail.com', N'Nữ', N'Quận 9- Tp.HCM', N'0944098635', N'kien', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')
GO
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [DiaChi]) VALUES (N'1', N'Nguyễn Ngạn', N'987456321', N'Bình Thạnh')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [DiaChi]) VALUES (N'2', N'Ngọc Ký', N'1231335', N'Hà Nội')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [DiaChi]) VALUES (N'3', N'Thái Bình', N'12313133', N'Bình Thạnh')
GO
INSERT [dbo].[TAIKHOAN] ([Username], [Password], [Ma_LoaiTK]) VALUES (N'Admin', N'1234', N'ADMIN')
INSERT [dbo].[TAIKHOAN] ([Username], [Password], [Ma_LoaiTK]) VALUES (N'hoangha', N'1234', N'SINHVIEN')
INSERT [dbo].[TAIKHOAN] ([Username], [Password], [Ma_LoaiTK]) VALUES (N'kien', N'123', N'SINHVIEN')
INSERT [dbo].[TAIKHOAN] ([Username], [Password], [Ma_LoaiTK]) VALUES (N'quynh ', N'123', N'SINHVIEN')
INSERT [dbo].[TAIKHOAN] ([Username], [Password], [Ma_LoaiTK]) VALUES (N'thu', N'1234', N'SINHVIEN')
GO
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'1', N'Tình Cảm')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'10', N'Truyện Tranh')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'2', N'Kinh Dị')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'3', N'Marketing')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'4', N'Manhwa')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'5', N'Giáo Dục')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'7', N'Tâm Lý')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'8', N'Văn Học Viễn Tưởng')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'9', N'Hoạt Hình')
GO
INSERT [dbo].[ViTri] ([MaViTri], [Ngan], [Ke]) VALUES (N'1A', N'1A', N'1A')
INSERT [dbo].[ViTri] ([MaViTri], [Ngan], [Ke]) VALUES (N'1B', N'1B', N'1B')
GO
ALTER TABLE [dbo].[Sach] ADD  DEFAULT (getdate()) FOR [TimeCreate]
GO
ALTER TABLE [dbo].[Sach] ADD  DEFAULT (getdate()) FOR [TimeUpdate]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN_CHUCNANG] FOREIGN KEY([Ma_ChucNang])
REFERENCES [dbo].[CHUCNANG] ([Ma_ChucNang])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN_CHUCNANG]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN_LOAI_TAIKHOAN] FOREIGN KEY([Ma_LoaiTK])
REFERENCES [dbo].[LOAI_TAIKHOAN] ([Ma_LoaiTK])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN_LOAI_TAIKHOAN]
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [FK_PhieuMuon_Sach]
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_SinhVien] FOREIGN KEY([MaSinhVien])
REFERENCES [dbo].[SinhVien] ([MaSinhVien])
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [FK_PhieuMuon_SinhVien]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NXB] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NXB] ([MaNXB])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NXB]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TacGia] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TacGia] ([MaTacGia])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TacGia]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TheLoai] FOREIGN KEY([MaLoaiSach])
REFERENCES [dbo].[TheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TheLoai]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_ViTri] FOREIGN KEY([MaViTri])
REFERENCES [dbo].[ViTri] ([MaViTri])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_ViTri]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN_LOAI_TAIKHOAN] FOREIGN KEY([Ma_LoaiTK])
REFERENCES [dbo].[LOAI_TAIKHOAN] ([Ma_LoaiTK])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TAIKHOAN_LOAI_TAIKHOAN]
GO
