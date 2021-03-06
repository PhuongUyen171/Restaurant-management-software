USE [QL_NhaHang]
GO
/****** Object:  StoredProcedure [dbo].[cap_nhat_theo_nguyen_lieu]    Script Date: 12/02/2019 1:54:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE[dbo].[cap_nhat_theo_nguyen_lieu] 
@SL int =NULL,
@MaMA INT =NULL
AS
BEGIN
SELECT ct.MaNL,(nl.KLTon - (@SL*ct.KhoiLuong))AS NLCon
INTO #bang
FROM dbo.CT_CONGTHUC ct
JOIN dbo.CONGTHUCMA ctm ON ct.MaCT = ctm.MaCT
JOIN dbo.MONAN ma ON ma.MaMA = ctm.MaMA
JOIN dbo.NGUYENLIEU nl ON nl.MaNL=ct.MaNL
WHERE ma.MaMA =@MaMA
UPDATE dbo.NGUYENLIEU 
SET NGUYENLIEU.KLTon = b.NLCon 
FROM dbo.NGUYENLIEU nl 
JOIN #bang b ON b.MaNL = nl.MaNL
DROP TABLE #bang
END


GO
/****** Object:  StoredProcedure [dbo].[chuyen_ban]    Script Date: 12/02/2019 1:54:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[chuyen_ban] 
@BanChuyen int,
@BanDuocChuyen INT
AS
BEGIN
DECLARE @PD INT =NULL;
SET @PD = (SELECT MaPD FROM dbo.BAN WHERE MaB=@BanChuyen)
BEGIN
UPDATE dbo.BAN SET MaPD = @PD,TinhTrang=N'Hết' WHERE MaB =@BanDuocChuyen
END
BEGIN
UPDATE dbo.BAN SET MaPD = NULL,TinhTrang=N'Còn' WHERE MaB =@BanChuyen
END
END

GO
/****** Object:  StoredProcedure [dbo].[gop_ban]    Script Date: 12/02/2019 1:54:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE[dbo].[gop_ban] 
@BanDHGop int =NULL,--1
@BanGop INT =NULL--10
AS
DECLARE @PD INT = (SELECT MaPD FROM dbo.BAN WHERE MaB =@BanDHGop)
DECLARE @PDXOA INT = (SELECT MaPD FROM dbo.BAN WHERE MaB =@BanGop)
BEGIN
UPDATE dbo.BAN SET MaPD = NULL , TinhTrang =N'Còn' WHERE MaB = @BanGop
--kiểm tra ma món ăn có bị trùng nếu không trùng thì cập nhập phiếu đặt
--UPDATE dbo.CT_MONAN SET MaPD = @PD WHERE MaPD=@PDXOA
SELECT * 
INTO #Temp
FROM dbo.CT_MONAN 
WHERE MaPD = @PDXOA
DELETE dbo.CT_MONAN WHERE MaPD = @PDXOA
					 
While (Select Count(*) From #Temp) > 0
Begin
	IF((SELECT COUNT(*) FROM dbo.CT_MONAN ct WHERE ct.MaPD=@PD and  ct.MaMA =(SELECT TOP 1 MaMA FROM #Temp)) = 1)
	BEGIN
    UPDATE dbo.CT_MONAN SET SoLuong = (SoLuong +  (SELECT TOP 1 SoLuong FROM #Temp)) WHERE MaPD = @PD
	END
    ELSE
    BEGIN
	INSERT INTO dbo.CT_MONAN
	        ( MaMA, MaPD, SoLuong )
	VALUES  ( (SELECT TOP 1 MaMA FROM #Temp), -- MaMA - int
	          @PD, -- MaPD - int
	          (SELECT TOP 1 SoLuong FROM #Temp)  -- SoLuong - int
	          )
	END
	Delete #Temp Where MaMA = (SELECT TOP 1 MaMA FROM #Temp)
END
DROP TABLE #Temp
END



GO
/****** Object:  StoredProcedure [dbo].[huy_chuyen_ban]    Script Date: 12/02/2019 1:54:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE[dbo].[huy_chuyen_ban] 
AS
BEGIN
UPDATE dbo.BAN
SET TinhTrang = N'Còn'
WHERE
MaPD IS NULL
END


GO
/****** Object:  StoredProcedure [dbo].[su_kien_kich_vao_chuyen_ban]    Script Date: 12/02/2019 1:54:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE[dbo].[su_kien_kich_vao_chuyen_ban] 
@MaBan int =NULL
AS
BEGIN
UPDATE dbo.BAN
SET TinhTrang = N'Còn'
WHERE
MaPD IS NULL
UPDATE dbo.BAN
SET TinhTrang = N'Hết'
WHERE MaB=@MaBan
END


GO
/****** Object:  Table [dbo].[BAN]    Script Date: 12/02/2019 1:54:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAN](
	[MaB] [int] IDENTITY(1,1) NOT NULL,
	[MaKV] [int] NULL,
	[MaPD] [int] NULL,
	[TinhTrang] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CONGTHUCMA]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONGTHUCMA](
	[MaCT] [int] IDENTITY(1,1) NOT NULL,
	[MaMA] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_CONGTHUC]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_CONGTHUC](
	[MaCT] [int] NOT NULL,
	[MaNL] [int] NOT NULL,
	[KhoiLuong] [float] NULL,
	[DVT] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCT] ASC,
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_DICHVU]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_DICHVU](
	[MaDV] [int] NOT NULL,
	[MaPH] [int] NOT NULL,
	[ThoiGian] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC,
	[MaPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_MONAN]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_MONAN](
	[MaMA] [int] NOT NULL,
	[MaPD] [int] NOT NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMA] ASC,
	[MaPD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_PHIEUGIAOHANG]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_PHIEUGIAOHANG](
	[MaMA] [int] NOT NULL,
	[MaPGH] [int] NOT NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMA] ASC,
	[MaPGH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_PHIEUNHAP]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_PHIEUNHAP](
	[MaPN] [int] NOT NULL,
	[MaNL] [int] NOT NULL,
	[SoLuong] [float] NULL,
	[DonGiaNhap] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC,
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DICHVU]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DICHVU](
	[MaDV] [int] IDENTITY(1,1) NOT NULL,
	[TenDV] [nvarchar](50) NULL,
	[Gia] [float] NULL,
	[DVT] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [date] NULL,
	[TongTien] [float] NULL,
	[VAT] [float] NULL,
	[ThanhToan] [float] NULL,
	[MaPD] [int] NULL,
	[MaNV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SoCMND] [int] NULL,
	[DiemTichLuy] [int] NULL,
	[MaLKH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHUVUC]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHUVUC](
	[MaKV] [int] IDENTITY(1,1) NOT NULL,
	[TenKV] [nvarchar](50) NULL,
	[TinhTrang] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAIKH]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIKH](
	[MaLKH] [int] IDENTITY(1,1) NOT NULL,
	[TenLKH] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAIPHONG]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIPHONG](
	[MaLP] [int] IDENTITY(1,1) NOT NULL,
	[TenLP] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MANHINH]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MANHINH](
	[MaManHinh] [int] IDENTITY(1,1) NOT NULL,
	[TenManHinh] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MONAN]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONAN](
	[MaMA] [int] IDENTITY(1,1) NOT NULL,
	[TenMA] [nvarchar](50) NULL,
	[Gia] [float] NULL,
	[DVT] [nvarchar](50) NULL,
	[MaNMA] [int] NULL,
	[HinhAnh] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NCC]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCC](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
	[HoatDong] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGUOIDUNGNHOMNGUOIDUNG]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNGNHOMNGUOIDUNG](
	[MaNhomNguoiDung] [int] NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhomNguoiDung] ASC,
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGUYENLIEU]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUYENLIEU](
	[MaNL] [int] IDENTITY(1,1) NOT NULL,
	[TenNL] [nvarchar](50) NULL,
	[DVT] [nvarchar](50) NULL,
	[MaNCC] [int] NULL,
	[HinhAnh] [image] NULL,
	[KLTon] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[HinhAnh] [image] NULL,
	[TenDangNhap] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHOMMA]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMMA](
	[MaNMA] [int] IDENTITY(1,1) NOT NULL,
	[TenNMA] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNMA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHOMNGUOIDUNG]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMNGUOIDUNG](
	[MaNhomNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenNhom] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhomNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[MaNhomNguoiDung] [int] NOT NULL,
	[MaManHinh] [int] NOT NULL,
	[CoQuyen] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC,
	[MaNhomNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUDATMON]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUDATMON](
	[MaPD] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [date] NULL,
	[GioDat] [time](7) NULL,
	[SoLuong] [int] NULL,
	[TienCoc] [float] NULL,
	[MaKH] [int] NULL,
	[HetHan] [date] NULL,
	[TinhTrang] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUDATVE]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUDATVE](
	[MaPDV] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [date] NULL,
	[GioDat] [time](7) NULL,
	[MaKH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUGIAOHANG]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUGIAOHANG](
	[MaPGH] [int] IDENTITY(1,1) NOT NULL,
	[TongTien] [float] NULL,
	[MaPDV] [int] NULL,
	[MaNV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPGH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[MaPN] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [date] NULL,
	[TongTien] [float] NULL,
	[MaNCC] [int] NULL,
	[MaNV] [int] NULL,
	[GioLap] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 12/02/2019 1:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[MaPH] [int] IDENTITY(1,1) NOT NULL,
	[TenPH] [nvarchar](50) NULL,
	[SucChua] [int] NULL,
	[MaLP] [int] NULL,
	[MaKV] [int] NULL,
	[MaPD] [int] NULL,
	[TinhTrang] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BAN] ON 

INSERT [dbo].[BAN] ([MaB], [MaKV], [MaPD], [TinhTrang]) VALUES (8, 1, 4, N'Đã Đặt')
INSERT [dbo].[BAN] ([MaB], [MaKV], [MaPD], [TinhTrang]) VALUES (9, 2, 5, N'Đã Đặt')
INSERT [dbo].[BAN] ([MaB], [MaKV], [MaPD], [TinhTrang]) VALUES (10, 3, 6, N'Đã Đặt')
INSERT [dbo].[BAN] ([MaB], [MaKV], [MaPD], [TinhTrang]) VALUES (11, 1, 7, N'Đã Đặt')
INSERT [dbo].[BAN] ([MaB], [MaKV], [MaPD], [TinhTrang]) VALUES (12, 2, 8, N'Đã Đặt')
INSERT [dbo].[BAN] ([MaB], [MaKV], [MaPD], [TinhTrang]) VALUES (13, 3, 9, N'Đã Đặt')
SET IDENTITY_INSERT [dbo].[BAN] OFF
SET IDENTITY_INSERT [dbo].[CONGTHUCMA] ON 

INSERT [dbo].[CONGTHUCMA] ([MaCT], [MaMA]) VALUES (2, 1)
INSERT [dbo].[CONGTHUCMA] ([MaCT], [MaMA]) VALUES (3, 2)
INSERT [dbo].[CONGTHUCMA] ([MaCT], [MaMA]) VALUES (4, 3)
INSERT [dbo].[CONGTHUCMA] ([MaCT], [MaMA]) VALUES (5, 4)
INSERT [dbo].[CONGTHUCMA] ([MaCT], [MaMA]) VALUES (6, 5)
SET IDENTITY_INSERT [dbo].[CONGTHUCMA] OFF
INSERT [dbo].[CT_CONGTHUC] ([MaCT], [MaNL], [KhoiLuong], [DVT]) VALUES (2, 1, 0.5, N'KG')
INSERT [dbo].[CT_CONGTHUC] ([MaCT], [MaNL], [KhoiLuong], [DVT]) VALUES (3, 2, 1, N'KG')
INSERT [dbo].[CT_CONGTHUC] ([MaCT], [MaNL], [KhoiLuong], [DVT]) VALUES (4, 3, 3, N'KG')
INSERT [dbo].[CT_CONGTHUC] ([MaCT], [MaNL], [KhoiLuong], [DVT]) VALUES (5, 4, 500, N'GR')
INSERT [dbo].[CT_PHIEUNHAP] ([MaPN], [MaNL], [SoLuong], [DonGiaNhap]) VALUES (1, 1, 10, 50000)
INSERT [dbo].[CT_PHIEUNHAP] ([MaPN], [MaNL], [SoLuong], [DonGiaNhap]) VALUES (2, 2, 10, 60000)
INSERT [dbo].[CT_PHIEUNHAP] ([MaPN], [MaNL], [SoLuong], [DonGiaNhap]) VALUES (3, 3, 10, 70000)
INSERT [dbo].[CT_PHIEUNHAP] ([MaPN], [MaNL], [SoLuong], [DonGiaNhap]) VALUES (4, 4, 10, 80000)
INSERT [dbo].[CT_PHIEUNHAP] ([MaPN], [MaNL], [SoLuong], [DonGiaNhap]) VALUES (5, 5, 10, 100000)
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([MaHD], [NgayLap], [TongTien], [VAT], [ThanhToan], [MaPD], [MaNV]) VALUES (1, CAST(0x2E3F0B00 AS Date), 900000, 90000, 990000, 4, 1)
INSERT [dbo].[HOADON] ([MaHD], [NgayLap], [TongTien], [VAT], [ThanhToan], [MaPD], [MaNV]) VALUES (2, CAST(0x483F0B00 AS Date), 2900000, 290000, 3190000, 5, 1)
INSERT [dbo].[HOADON] ([MaHD], [NgayLap], [TongTien], [VAT], [ThanhToan], [MaPD], [MaNV]) VALUES (3, CAST(0x493F0B00 AS Date), 1600000, 160000, 1760000, 6, 1)
INSERT [dbo].[HOADON] ([MaHD], [NgayLap], [TongTien], [VAT], [ThanhToan], [MaPD], [MaNV]) VALUES (4, CAST(0x493F0B00 AS Date), 1900000, 190000, 2090000, 7, 1)
INSERT [dbo].[HOADON] ([MaHD], [NgayLap], [TongTien], [VAT], [ThanhToan], [MaPD], [MaNV]) VALUES (5, CAST(0x493F0B00 AS Date), 2800000, 280000, 3080000, 8, 1)
INSERT [dbo].[HOADON] ([MaHD], [NgayLap], [TongTien], [VAT], [ThanhToan], [MaPD], [MaNV]) VALUES (6, CAST(0x453F0B00 AS Date), 2500000, 250000, 2750000, 9, 1)
SET IDENTITY_INSERT [dbo].[HOADON] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (1, N'Florentino', N'TP.HCM', N'09645522650', N'nguoidung3421@gmail.com', 256485641, 100, 1)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (2, N'Triệu Vân', N'TP.HCM', N'05671358912', N'nguoidung3423@gmail.com', 276849518, 21, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (3, N'Ngộ Không', N'Vũng Tàu', N'02354685412', N'nguoidung3422@gmail.com', 248654861, 12, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (4, N'Murad', N'Bình Định', N'02134596413', N'nguoidung34223@gmail.com', 215648526, 65, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (5, N'Jinna', N'Quảng Trị', N'05864856185', N'nguoidung342132@gmail.com', 248254625, 44, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (6, N'Zuka', N'Bắc Cạn', N'02865696456', N'nguoidung341232@gmail.com', 128655448, 77, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (7, N'Violet', N'Bạc Liêu', N'05464674556', N'nguoidung3542@gmail.com', 264565655, 45, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (8, N'Alice', N'Tiền Giang', N'07957897454', N'nguoidung37742@gmail.com', 441253533, 33, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (9, N'Lindis', N'Bà Rịa', N'04576464678', N'nguoidung34772@gmail.com', 234323222, 111, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (10, N'Nakroth', N'Quảng Ngãi', N'04674648465', N'nguoidung34352@gmail.com', 242313211, 32, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (11, N'Toro', N'Quảng Bình', N'05167465144', N'nguoidung3454352@gmail.com', 121313221, 356, 1)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (12, N'Grakk', N'Nghệ An', N'07465154841', N'nguoidung343452@gmail.com', 213212211, 46, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (13, N'Liliana', N'Huế', N'05464534351', N'nguoidung334542@gmail.com', 546545645, 21, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (14, N'Mina', N'Hà Nội', N'05465464546', N'nguoidung334542@gmail.com', 546312422, 74, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (15, N'Arum', N'Cần Thơ', N'02468746444', N'nguoidung334542@gmail.com', 641521034, 52, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (16, N'Ryoma', N'Tây Ninh', N'05648645155', N'nguoidung313242@gmail.com', 121212121, 46, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (17, N'Baldum', N'Phú Yên', N'05464545748', N'nguoidung34982@gmail.com', 541320132, 47, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (18, N'Yorn', N'Nha Trang', N'04664646744', N'nguoidung348652@gmail.com', 431203121, 33, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (19, N'Payna', N'Lào Cai', N'01687651654', N'nguoidung343542@gmail.com', 454545556, 11, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (20, N'Elsu', N'Quảng Nam', N'04967845164', N'nguoidung343542@gmail.com', 564521452, 55, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (21, N'Tulen', N'Bình Thuận', N'01897664849', N'nguoidung344352@gmail.com', 545645645, 66, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (22, N'Raz', N'Bình Dương', N'06484121646', N'nguoidung345432@gmail.com', 546545454, 88, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (23, N'Krixi', N'Đồng Nai', N'01546789416', N'nguoidung343452@gmail.com', 546412554, 16, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (24, N'Thane', N'TP.HCM', N'04678951656', N'nguoidung343542@gmail.com', 845164545, 23, 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [SoCMND], [DiemTichLuy], [MaLKH]) VALUES (25, N'Điêu Thuyền', N'TP.HCM', N'06484151115', N'nguoidung323442@gmail.com', 456451544, 44, NULL)
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
SET IDENTITY_INSERT [dbo].[KHUVUC] ON 

INSERT [dbo].[KHUVUC] ([MaKV], [TenKV], [TinhTrang]) VALUES (1, N'Khu Vực 1', N'Phòng')
INSERT [dbo].[KHUVUC] ([MaKV], [TenKV], [TinhTrang]) VALUES (2, N'Khu Vực 2', N'Bàn')
INSERT [dbo].[KHUVUC] ([MaKV], [TenKV], [TinhTrang]) VALUES (3, N'Khu Vực 3', N'Bàn')
SET IDENTITY_INSERT [dbo].[KHUVUC] OFF
SET IDENTITY_INSERT [dbo].[LOAIKH] ON 

INSERT [dbo].[LOAIKH] ([MaLKH], [TenLKH]) VALUES (1, N'VIP')
INSERT [dbo].[LOAIKH] ([MaLKH], [TenLKH]) VALUES (2, N'Thường')
SET IDENTITY_INSERT [dbo].[LOAIKH] OFF
SET IDENTITY_INSERT [dbo].[LOAIPHONG] ON 

INSERT [dbo].[LOAIPHONG] ([MaLP], [TenLP]) VALUES (1, N'VIP')
INSERT [dbo].[LOAIPHONG] ([MaLP], [TenLP]) VALUES (2, N'THƯỜNG')
SET IDENTITY_INSERT [dbo].[LOAIPHONG] OFF
SET IDENTITY_INSERT [dbo].[MONAN] ON 

INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (1, N'Súp Vi Cá Bống Trứng ', 20000, N'Chén', 1, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (2, N'Súp Gà Siêu Cay', 20000, N'Chén', 1, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (3, N'Nước Suối', 10000, N'Chai', 2, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (4, N'Tiger', 17000, N'Chai', 2, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (5, N'Sting', 10000, N'Lon', 2, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (6, N'Red bull', 15000, N'Lon', 2, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (7, N'Gà Hấp Xả Hành', 49000, N'Đĩa', 3, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (8, N'Gà Chiên Nước Mắm', 49000, N'Đĩa', 3, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (9, N'Lẩu Gà Lá Chanh', 149000, N'Nồi', 3, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (10, N'Gà Sốt Phô Mai', 59000, N'Đĩa', 3, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (11, N'Gà Hàn Sốt Cay', 59000, N'Đĩa', 3, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (12, N'Cơm Gà Xối Mỡ', 19000, N'Đĩa', 3, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (13, N'Gà Kho Gừng', 29000, N'Đĩa', 3, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (14, N'Bò Xào Cần Tây', 89000, N'Đĩa', 3, NULL)
INSERT [dbo].[MONAN] ([MaMA], [TenMA], [Gia], [DVT], [MaNMA], [HinhAnh]) VALUES (15, N'Tôm Càng Xanh Nhảy Múa', 299000, N'Đĩa', 3, NULL)
SET IDENTITY_INSERT [dbo].[MONAN] OFF
SET IDENTITY_INSERT [dbo].[NCC] ON 

INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email]) VALUES (1, N'TÂN PHÁT', N'TP.HCM', 467667684, N'NCC1@GMAIL.COM')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email]) VALUES (2, N'NHẤT TIÊN', N'TP.HCM', 767868764, N'NCC2@GMAIL.COM')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email]) VALUES (3, N'CÀ NÁ', N'TP.HCM', 466546546, N'NCC3@GMAIL.COM')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email]) VALUES (4, N'NHA TRANG', N'TP.HCM', 456546456, N'NCC4@GMAIL.COM')
SET IDENTITY_INSERT [dbo].[NCC] OFF
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [HoatDong]) VALUES (N'HAN123', N'1', NULL)
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [HoatDong]) VALUES (N'HUYEN123', N'1', NULL)
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [HoatDong]) VALUES (N'NGOC123', N'1', NULL)
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [HoatDong]) VALUES (N'TRAN123', N'1', NULL)
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [HoatDong]) VALUES (N'TRANG123', N'1', NULL)
INSERT [dbo].[NGUOIDUNGNHOMNGUOIDUNG] ([MaNhomNguoiDung], [TenDangNhap], [GhiChu]) VALUES (1, N'HAN123', N'QUẢN LÝ HÓA ĐƠN')
INSERT [dbo].[NGUOIDUNGNHOMNGUOIDUNG] ([MaNhomNguoiDung], [TenDangNhap], [GhiChu]) VALUES (2, N'HUYEN123', N'NHÂN VIÊN QUẢN TRỊ')
INSERT [dbo].[NGUOIDUNGNHOMNGUOIDUNG] ([MaNhomNguoiDung], [TenDangNhap], [GhiChu]) VALUES (3, N'TRANG123', N'QUẢN LÝ KHO')
INSERT [dbo].[NGUOIDUNGNHOMNGUOIDUNG] ([MaNhomNguoiDung], [TenDangNhap], [GhiChu]) VALUES (4, N'NGOC123', N'TRÔNG QUẦY')
INSERT [dbo].[NGUOIDUNGNHOMNGUOIDUNG] ([MaNhomNguoiDung], [TenDangNhap], [GhiChu]) VALUES (4, N'TRAN123', N'TRÔNG QUẦY')
SET IDENTITY_INSERT [dbo].[NGUYENLIEU] ON 

INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (1, N'THỊT GÀ', N'KG', 1, NULL, 32)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (2, N'THỊT CÁ', N'KG', 2, NULL, 33)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (3, N'THỊT TRÂU', N'KG', 3, NULL, 10)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (4, N'TÔM', N'GR', 4, NULL, 17)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (5, N'THỊT BÒ', N'KG', 1, NULL, 22)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (6, N'MUỐI ', N'KG', 2, NULL, 323)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (7, N'ỚT', N'KG', 3, NULL, 467)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (8, N'NƯỚC SUỐI ', N'CHAI', NULL, NULL, 324)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (9, N'RED BULL', N'LON', NULL, NULL, 432)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (10, N'STING', N'LON', NULL, NULL, 543)
INSERT [dbo].[NGUYENLIEU] ([MaNL], [TenNL], [DVT], [MaNCC], [HinhAnh], [KLTon]) VALUES (11, N'RAU CẢI', N'KG', NULL, NULL, 321)
SET IDENTITY_INSERT [dbo].[NGUYENLIEU] OFF
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [DiaChi], [SDT], [HinhAnh], [TenDangNhap]) VALUES (1, N'HÂN', N'TP.HCM', 125495642, NULL, N'HAN123')
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [DiaChi], [SDT], [HinhAnh], [TenDangNhap]) VALUES (14, N'HUYỀN', N'TP.HCM', 965748566, NULL, N'HUYEN123')
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [DiaChi], [SDT], [HinhAnh], [TenDangNhap]) VALUES (15, N'TRÂN', N'TP.HCM', 965548966, NULL, N'TRAN123')
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [DiaChi], [SDT], [HinhAnh], [TenDangNhap]) VALUES (16, N'TRANG', N'TP.HCM', 965654654, NULL, N'TRANG123')
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [DiaChi], [SDT], [HinhAnh], [TenDangNhap]) VALUES (17, N'NGỌC', N'TP.HCM', 956465588, NULL, N'NGOC123')
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
SET IDENTITY_INSERT [dbo].[NHOMMA] ON 

INSERT [dbo].[NHOMMA] ([MaNMA], [TenNMA]) VALUES (1, N'Khai Vị')
INSERT [dbo].[NHOMMA] ([MaNMA], [TenNMA]) VALUES (2, N'Nước uống')
INSERT [dbo].[NHOMMA] ([MaNMA], [TenNMA]) VALUES (3, N'Món Nhậu')
SET IDENTITY_INSERT [dbo].[NHOMMA] OFF
SET IDENTITY_INSERT [dbo].[NHOMNGUOIDUNG] ON 

INSERT [dbo].[NHOMNGUOIDUNG] ([MaNhomNguoiDung], [TenNhom], [GhiChu]) VALUES (1, N'QL Hóa Đơn', NULL)
INSERT [dbo].[NHOMNGUOIDUNG] ([MaNhomNguoiDung], [TenNhom], [GhiChu]) VALUES (2, N'NV Quản Trị', NULL)
INSERT [dbo].[NHOMNGUOIDUNG] ([MaNhomNguoiDung], [TenNhom], [GhiChu]) VALUES (3, N'QL Kho', NULL)
INSERT [dbo].[NHOMNGUOIDUNG] ([MaNhomNguoiDung], [TenNhom], [GhiChu]) VALUES (4, N'Trông Quầy', NULL)
SET IDENTITY_INSERT [dbo].[NHOMNGUOIDUNG] OFF
SET IDENTITY_INSERT [dbo].[PHIEUDATMON] ON 

INSERT [dbo].[PHIEUDATMON] ([MaPD], [NgayDat], [GioDat], [SoLuong], [TienCoc], [MaKH], [HetHan], [TinhTrang]) VALUES (4, CAST(0x2E3F0B00 AS Date), CAST(0x0700E03495640000 AS Time), 1, 500000, 1, NULL, N'Đã đặt')
INSERT [dbo].[PHIEUDATMON] ([MaPD], [NgayDat], [GioDat], [SoLuong], [TienCoc], [MaKH], [HetHan], [TinhTrang]) VALUES (5, CAST(0x483F0B00 AS Date), CAST(0x0700E03495640000 AS Time), 5, 2500000, 2, NULL, N'Đã đặt')
INSERT [dbo].[PHIEUDATMON] ([MaPD], [NgayDat], [GioDat], [SoLuong], [TienCoc], [MaKH], [HetHan], [TinhTrang]) VALUES (6, CAST(0x493F0B00 AS Date), CAST(0x0700E03495640000 AS Time), 2, 1000000, 3, NULL, N'Đã đặt')
INSERT [dbo].[PHIEUDATMON] ([MaPD], [NgayDat], [GioDat], [SoLuong], [TienCoc], [MaKH], [HetHan], [TinhTrang]) VALUES (7, CAST(0x493F0B00 AS Date), CAST(0x0700E03495640000 AS Time), 3, 1500000, 4, NULL, N'Đã đặt')
INSERT [dbo].[PHIEUDATMON] ([MaPD], [NgayDat], [GioDat], [SoLuong], [TienCoc], [MaKH], [HetHan], [TinhTrang]) VALUES (8, CAST(0x493F0B00 AS Date), CAST(0x0700E03495640000 AS Time), 5, 2500000, 5, NULL, N'Đã đặt')
INSERT [dbo].[PHIEUDATMON] ([MaPD], [NgayDat], [GioDat], [SoLuong], [TienCoc], [MaKH], [HetHan], [TinhTrang]) VALUES (9, CAST(0x453F0B00 AS Date), CAST(0x0700E03495640000 AS Time), 1, 500000, 6, NULL, N'Đã đặt')
SET IDENTITY_INSERT [dbo].[PHIEUDATMON] OFF
SET IDENTITY_INSERT [dbo].[PHIEUNHAP] ON 

INSERT [dbo].[PHIEUNHAP] ([MaPN], [NgayLap], [TongTien], [MaNCC], [MaNV], [GioLap]) VALUES (1, CAST(0x3F400B00 AS Date), 500000, 1, 1, CAST(0x070028D0BB1E0000 AS Time))
INSERT [dbo].[PHIEUNHAP] ([MaPN], [NgayLap], [TongTien], [MaNCC], [MaNV], [GioLap]) VALUES (2, CAST(0x4C3F0B00 AS Date), 600000, 2, 14, CAST(0x0700F0C859290000 AS Time))
INSERT [dbo].[PHIEUNHAP] ([MaPN], [NgayLap], [TongTien], [MaNCC], [MaNV], [GioLap]) VALUES (3, CAST(0x6E400B00 AS Date), 700000, 3, 15, CAST(0x07003CB8192E0000 AS Time))
INSERT [dbo].[PHIEUNHAP] ([MaPN], [NgayLap], [TongTien], [MaNCC], [MaNV], [GioLap]) VALUES (4, CAST(0x5D400B00 AS Date), 800000, 4, 16, CAST(0x0700E89552110000 AS Time))
INSERT [dbo].[PHIEUNHAP] ([MaPN], [NgayLap], [TongTien], [MaNCC], [MaNV], [GioLap]) VALUES (5, CAST(0x65400B00 AS Date), 1000000, 4, 17, CAST(0x0700C2B5A63B0000 AS Time))
SET IDENTITY_INSERT [dbo].[PHIEUNHAP] OFF
SET IDENTITY_INSERT [dbo].[PHONG] ON 

INSERT [dbo].[PHONG] ([MaPH], [TenPH], [SucChua], [MaLP], [MaKV], [MaPD], [TinhTrang]) VALUES (1, N'PH101', 10, 2, 1, NULL, NULL)
INSERT [dbo].[PHONG] ([MaPH], [TenPH], [SucChua], [MaLP], [MaKV], [MaPD], [TinhTrang]) VALUES (2, N'PH102', 20, 2, 1, NULL, NULL)
INSERT [dbo].[PHONG] ([MaPH], [TenPH], [SucChua], [MaLP], [MaKV], [MaPD], [TinhTrang]) VALUES (3, N'PH103', 40, 1, 1, NULL, NULL)
INSERT [dbo].[PHONG] ([MaPH], [TenPH], [SucChua], [MaLP], [MaKV], [MaPD], [TinhTrang]) VALUES (4, N'PH104', 50, 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PHONG] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [unique]    Script Date: 12/02/2019 1:54:08 PM ******/
ALTER TABLE [dbo].[NHANVIEN] ADD  CONSTRAINT [unique] UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BAN]  WITH CHECK ADD FOREIGN KEY([MaKV])
REFERENCES [dbo].[KHUVUC] ([MaKV])
GO
ALTER TABLE [dbo].[BAN]  WITH CHECK ADD FOREIGN KEY([MaPD])
REFERENCES [dbo].[PHIEUDATMON] ([MaPD])
GO
ALTER TABLE [dbo].[CONGTHUCMA]  WITH CHECK ADD FOREIGN KEY([MaMA])
REFERENCES [dbo].[MONAN] ([MaMA])
GO
ALTER TABLE [dbo].[CT_CONGTHUC]  WITH CHECK ADD FOREIGN KEY([MaCT])
REFERENCES [dbo].[CONGTHUCMA] ([MaCT])
GO
ALTER TABLE [dbo].[CT_CONGTHUC]  WITH CHECK ADD FOREIGN KEY([MaNL])
REFERENCES [dbo].[NGUYENLIEU] ([MaNL])
GO
ALTER TABLE [dbo].[CT_DICHVU]  WITH CHECK ADD FOREIGN KEY([MaDV])
REFERENCES [dbo].[DICHVU] ([MaDV])
GO
ALTER TABLE [dbo].[CT_DICHVU]  WITH CHECK ADD FOREIGN KEY([MaPH])
REFERENCES [dbo].[PHONG] ([MaPH])
GO
ALTER TABLE [dbo].[CT_MONAN]  WITH CHECK ADD FOREIGN KEY([MaMA])
REFERENCES [dbo].[MONAN] ([MaMA])
GO
ALTER TABLE [dbo].[CT_MONAN]  WITH CHECK ADD FOREIGN KEY([MaPD])
REFERENCES [dbo].[PHIEUDATMON] ([MaPD])
GO
ALTER TABLE [dbo].[CT_PHIEUGIAOHANG]  WITH CHECK ADD FOREIGN KEY([MaPGH])
REFERENCES [dbo].[PHIEUGIAOHANG] ([MaPGH])
GO
ALTER TABLE [dbo].[CT_PHIEUGIAOHANG]  WITH CHECK ADD FOREIGN KEY([MaMA])
REFERENCES [dbo].[MONAN] ([MaMA])
GO
ALTER TABLE [dbo].[CT_PHIEUNHAP]  WITH CHECK ADD FOREIGN KEY([MaNL])
REFERENCES [dbo].[NGUYENLIEU] ([MaNL])
GO
ALTER TABLE [dbo].[CT_PHIEUNHAP]  WITH CHECK ADD FOREIGN KEY([MaPN])
REFERENCES [dbo].[PHIEUNHAP] ([MaPN])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MaPD])
REFERENCES [dbo].[PHIEUDATMON] ([MaPD])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NHANVIEN]
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD FOREIGN KEY([MaLKH])
REFERENCES [dbo].[LOAIKH] ([MaLKH])
GO
ALTER TABLE [dbo].[MONAN]  WITH CHECK ADD FOREIGN KEY([MaNMA])
REFERENCES [dbo].[NHOMMA] ([MaNMA])
GO
ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_NHANVIEN] FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[NHANVIEN] ([TenDangNhap])
GO
ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK_NGUOIDUNG_NHANVIEN]
GO
ALTER TABLE [dbo].[NGUOIDUNGNHOMNGUOIDUNG]  WITH CHECK ADD FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[NHOMNGUOIDUNG] ([MaNhomNguoiDung])
GO
ALTER TABLE [dbo].[NGUOIDUNGNHOMNGUOIDUNG]  WITH CHECK ADD FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[NGUOIDUNG] ([TenDangNhap])
GO
ALTER TABLE [dbo].[NGUYENLIEU]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NCC] ([MaNCC])
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD FOREIGN KEY([MaManHinh])
REFERENCES [dbo].[MANHINH] ([MaManHinh])
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[NHOMNGUOIDUNG] ([MaNhomNguoiDung])
GO
ALTER TABLE [dbo].[PHIEUDATMON]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[PHIEUDATVE]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[PHIEUGIAOHANG]  WITH CHECK ADD FOREIGN KEY([MaPDV])
REFERENCES [dbo].[PHIEUDATVE] ([MaPDV])
GO
ALTER TABLE [dbo].[PHIEUGIAOHANG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUGIAOHANG_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[PHIEUGIAOHANG] CHECK CONSTRAINT [FK_PHIEUGIAOHANG_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NCC] ([MaNCC])
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD FOREIGN KEY([MaKV])
REFERENCES [dbo].[KHUVUC] ([MaKV])
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD FOREIGN KEY([MaLP])
REFERENCES [dbo].[LOAIPHONG] ([MaLP])
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD FOREIGN KEY([MaPD])
REFERENCES [dbo].[PHIEUDATMON] ([MaPD])
GO

select * from nguoidung

set dateformat dmy
select * from hoadon where NgayLap between '12/01/2019' and '07/02/2019'