USE [master]
GO
/****** Object:  Database [ASM_C5]    Script Date: 22/06/2021 1:40:26 SA ******/
CREATE DATABASE [ASM_C5]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ASM_C5', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER1\MSSQL\DATA\ASM_C5.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ASM_C5_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER1\MSSQL\DATA\ASM_C5_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ASM_C5] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ASM_C5].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ASM_C5] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ASM_C5] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ASM_C5] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ASM_C5] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ASM_C5] SET ARITHABORT OFF 
GO
ALTER DATABASE [ASM_C5] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ASM_C5] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ASM_C5] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ASM_C5] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ASM_C5] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ASM_C5] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ASM_C5] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ASM_C5] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ASM_C5] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ASM_C5] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ASM_C5] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ASM_C5] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ASM_C5] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ASM_C5] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ASM_C5] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ASM_C5] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ASM_C5] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ASM_C5] SET RECOVERY FULL 
GO
ALTER DATABASE [ASM_C5] SET  MULTI_USER 
GO
ALTER DATABASE [ASM_C5] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ASM_C5] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ASM_C5] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ASM_C5] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ASM_C5] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ASM_C5', N'ON'
GO
USE [ASM_C5]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/06/2021 1:40:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonhangChitiets]    Script Date: 22/06/2021 1:40:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonhangChitiets](
	[ChitietID] [int] IDENTITY(1,1) NOT NULL,
	[DonhangID] [int] NOT NULL,
	[MonAnID] [int] NOT NULL,
	[Soluong] [float] NOT NULL,
	[Thanhtien] [float] NOT NULL,
	[Ghichu] [nvarchar](250) NULL,
 CONSTRAINT [PK_DonhangChitiets] PRIMARY KEY CLUSTERED 
(
	[ChitietID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Donhangs]    Script Date: 22/06/2021 1:40:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donhangs](
	[DonhangID] [int] IDENTITY(1,1) NOT NULL,
	[KhachhangID] [int] NOT NULL,
	[Ngaydat] [datetime2](7) NOT NULL,
	[Tongtien] [float] NOT NULL,
	[trangThaiDonHang] [int] NOT NULL,
	[Ghichu] [nvarchar](250) NULL,
 CONSTRAINT [PK_Donhangs] PRIMARY KEY CLUSTERED 
(
	[DonhangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khachhangs]    Script Date: 22/06/2021 1:40:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Khachhangs](
	[KhachhangID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[NgaySinh] [datetime2](7) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ConfirmPassword] [varchar](50) NOT NULL,
	[Mota] [nvarchar](250) NULL,
	[EmailAddress] [varchar](50) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Khachhangs] PRIMARY KEY CLUSTERED 
(
	[KhachhangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MonAns]    Script Date: 22/06/2021 1:40:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAns](
	[MonAnID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Gia] [float] NOT NULL,
	[Phanloai] [int] NOT NULL,
	[Hinh] [nvarchar](100) NULL,
	[Mota] [nvarchar](250) NULL,
	[Trangthai] [bit] NOT NULL,
 CONSTRAINT [PK_MonAns] PRIMARY KEY CLUSTERED 
(
	[MonAnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nguoidungs]    Script Date: 22/06/2021 1:40:26 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nguoidungs](
	[NguoiDungID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Admin] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ConfirmPassword] [varchar](50) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Nguoidungs] PRIMARY KEY CLUSTERED 
(
	[NguoiDungID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210605082337_MonAn', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210605170021_NguoiDung', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210605171338_NguoiDung1', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210606061623_Donhang_Donhang_', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210616031939_DBC5', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210616032353_DBC5', N'3.1.10')
SET IDENTITY_INSERT [dbo].[DonhangChitiets] ON 

INSERT [dbo].[DonhangChitiets] ([ChitietID], [DonhangID], [MonAnID], [Soluong], [Thanhtien], [Ghichu]) VALUES (1, 1, 1, 1, 119000, N'')
INSERT [dbo].[DonhangChitiets] ([ChitietID], [DonhangID], [MonAnID], [Soluong], [Thanhtien], [Ghichu]) VALUES (2, 1, 3, 2, 238000, N'')
SET IDENTITY_INSERT [dbo].[DonhangChitiets] OFF
SET IDENTITY_INSERT [dbo].[Donhangs] ON 

INSERT [dbo].[Donhangs] ([DonhangID], [KhachhangID], [Ngaydat], [Tongtien], [trangThaiDonHang], [Ghichu]) VALUES (1, 3, CAST(N'2021-06-16 15:19:29.9074816' AS DateTime2), 357000, 1, N'')
SET IDENTITY_INSERT [dbo].[Donhangs] OFF
SET IDENTITY_INSERT [dbo].[Khachhangs] ON 

INSERT [dbo].[Khachhangs] ([KhachhangID], [FullName], [NgaySinh], [PhoneNumber], [Password], [ConfirmPassword], [Mota], [EmailAddress]) VALUES (3, N'Lâm Phương Dung', CAST(N'2021-06-11 15:18:00.0000000' AS DateTime2), N'0842687922', N'C4CA4238A0B923820DCC509A6F75849B', N'C4CA4238A0B923820DCC509A6F75849B', N'dep trai', N'chinhchu@gmail.com')
SET IDENTITY_INSERT [dbo].[Khachhangs] OFF
SET IDENTITY_INSERT [dbo].[MonAns] ON 

INSERT [dbo].[MonAns] ([MonAnID], [Name], [Gia], [Phanloai], [Hinh], [Mota], [Trangthai]) VALUES (1, N'GÀ NỬA CON TRUYỀN THỐNG', 119000, 1, N'ga-nua-connho.jpg', N'Với da gà giòn tan, thịt gà thơm ngọt', 1)
INSERT [dbo].[MonAns] ([MonAnID], [Name], [Gia], [Phanloai], [Hinh], [Mota], [Trangthai]) VALUES (3, N'CÁNH GÀ SỐT NGŨ VỊ (10 MIẾNG)', 119000, 1, N'canh-ga-10pcsngu-vinho-6046.jpg', N' Với da gà giòn tan, thịt gà thơm ngọt, mềm nhưng không bở kèm với sốt ngũ vị đậm đà, cay cay nồng nồng của ớt khô và tỏi, ... có thể chinh phục được hầu hết các thực khách khó tính, đặc biệt là những thực khách thích vị đậm đà Việt Nam.', 1)
INSERT [dbo].[MonAns] ([MonAnID], [Name], [Gia], [Phanloai], [Hinh], [Mota], [Trangthai]) VALUES (4, N'ĐÙI GÀ SỐT CREAMY ONION (5 MIẾNG)', 149000, 1, N'dui-ga-5pcskem-hanhnho-8488.jpg', N'Gà chiên sốt cremay onion là sự kết hợp hoàn hảo vị giòn của hành tây, mềm béo gậy của kem.', 1)
INSERT [dbo].[MonAns] ([MonAnID], [Name], [Gia], [Phanloai], [Hinh], [Mota], [Trangthai]) VALUES (5, N'COCA-COLA, SPRITE, FANTA, DASANI', 15000, 3, N'nuoc-nho-4773.jpg', N'Nước giải khát', 1)
INSERT [dbo].[MonAns] ([MonAnID], [Name], [Gia], [Phanloai], [Hinh], [Mota], [Trangthai]) VALUES (6, N'GÀ KHÔNG XƯƠNG SỐT PHÔ MAI CAY (20 MIẾNG)', 159000, 1, N'ga-khong-xuong-20pcsphomai-caynho-8208.jpg', N'Gà chiên sốt phô mai là sự kết hợp hoàn hảo vị giòn của hành tây, mềm béo gậy của kem.', 1)
INSERT [dbo].[MonAns] ([MonAnID], [Name], [Gia], [Phanloai], [Hinh], [Mota], [Trangthai]) VALUES (7, N'LẨU TOKBOKKI 7 PHÚT', 119000, 1, N'lau-tok-nho-6722.jpg', N'Lẩu cay', 1)
SET IDENTITY_INSERT [dbo].[MonAns] OFF
SET IDENTITY_INSERT [dbo].[Nguoidungs] ON 

INSERT [dbo].[Nguoidungs] ([NguoiDungID], [UserName], [FullName], [Email], [Title], [DOB], [Admin], [Locked], [Password], [ConfirmPassword]) VALUES (1, N'phongdung', N'Lâm Phương Dung', N'phuongdung@gmail.com', N'Quản lý', CAST(N'2021-06-02 00:24:00.0000000' AS DateTime2), 1, 1, N'C4CA4238A0B923820DCC509A6F75849B', N'1')
SET IDENTITY_INSERT [dbo].[Nguoidungs] OFF
/****** Object:  Index [IX_DonhangChitiets_DonhangID]    Script Date: 22/06/2021 1:40:26 SA ******/
CREATE NONCLUSTERED INDEX [IX_DonhangChitiets_DonhangID] ON [dbo].[DonhangChitiets]
(
	[DonhangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DonhangChitiets_MonAnID]    Script Date: 22/06/2021 1:40:26 SA ******/
CREATE NONCLUSTERED INDEX [IX_DonhangChitiets_MonAnID] ON [dbo].[DonhangChitiets]
(
	[MonAnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Donhangs_KhachhangID]    Script Date: 22/06/2021 1:40:26 SA ******/
CREATE NONCLUSTERED INDEX [IX_Donhangs_KhachhangID] ON [dbo].[Donhangs]
(
	[KhachhangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DonhangChitiets]  WITH CHECK ADD  CONSTRAINT [FK_DonhangChitiets_Donhangs_DonhangID] FOREIGN KEY([DonhangID])
REFERENCES [dbo].[Donhangs] ([DonhangID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DonhangChitiets] CHECK CONSTRAINT [FK_DonhangChitiets_Donhangs_DonhangID]
GO
ALTER TABLE [dbo].[DonhangChitiets]  WITH CHECK ADD  CONSTRAINT [FK_DonhangChitiets_MonAns_MonAnID] FOREIGN KEY([MonAnID])
REFERENCES [dbo].[MonAns] ([MonAnID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DonhangChitiets] CHECK CONSTRAINT [FK_DonhangChitiets_MonAns_MonAnID]
GO
ALTER TABLE [dbo].[Donhangs]  WITH CHECK ADD  CONSTRAINT [FK_Donhangs_Khachhangs_KhachhangID] FOREIGN KEY([KhachhangID])
REFERENCES [dbo].[Khachhangs] ([KhachhangID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Donhangs] CHECK CONSTRAINT [FK_Donhangs_Khachhangs_KhachhangID]
GO
USE [master]
GO
ALTER DATABASE [ASM_C5] SET  READ_WRITE 
GO
