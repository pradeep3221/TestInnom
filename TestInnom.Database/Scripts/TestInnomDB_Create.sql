USE [master]
GO

CREATE DATABASE [TestInnomDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestInnomDB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TestInnomDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestInnomDB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TestInnomDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestInnomDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestInnomDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestInnomDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestInnomDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestInnomDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestInnomDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestInnomDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestInnomDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TestInnomDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestInnomDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestInnomDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestInnomDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestInnomDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestInnomDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestInnomDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestInnomDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestInnomDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestInnomDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestInnomDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestInnomDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestInnomDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestInnomDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestInnomDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestInnomDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestInnomDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestInnomDB] SET  MULTI_USER 
GO
ALTER DATABASE [TestInnomDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestInnomDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestInnomDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestInnomDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [TestInnomDB]
GO
/****** Object:  Schema [AppId]    Script Date: 08-04-2020 12.47.44 AM ******/
CREATE SCHEMA [AppId]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 08-04-2020 12.47.44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](15) NULL,
	[Size] [nvarchar](5) NULL,
	[Price] [money] NOT NULL,
	[Quantity] [int] NULL,
	[ValidFrom] [datetime2](0) NOT NULL,
	[ValidTo] [datetime2](0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Product] ON 

GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (15, N'Adjustable Race', N'Magenta', N'62', 100.0000, 75, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (16, N'Bearing Ball', N'Magenta', N'62', 15.9900, 90, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (17, N'BB Ball Bearing', N'Magenta', N'62', 28.9900, 80, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (18, N'Blade', N'Magenta', N'62', 18.0000, 45, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (19, N'Sport-100 Helmet, Red', N'Red', N'72', 41.9900, 38, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (20, N'Sport-100 Helmet, Black', N'Black', N'72', 31.4900, 60, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (21, N'Mountain Bike Socks, M', N'White', N'M', 560.9900, 30, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (22, N'Mountain Bike Socks, L', N'White', N'L', 120.9900, 20, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (23, N'Long-Sleeve Logo Jersey, XL', N'Multi', N'XL', 44.9900, 60, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (24, N'Road-650 Black, 52', N'Black', N'52', 704.6900, 70, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (25, N'Mountain-100 Silver, 38', N'Silver', N'38', 359.9900, 45, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (26, N'Road-250 Black, 48', N'Black', N'48', 299.0200, 25, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (27, N'ML Bottom Bracket', NULL, NULL, 101.2400, 50, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [Color], [Size], [Price], [Quantity], [ValidFrom], [ValidTo]) VALUES (28, N'HL Bottom Bracket', NULL, NULL, 121.4900, 65, CAST(0x00A1CD00EF400B0000 AS DateTime2), CAST(0x007F5101DAB9370000 AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
USE [master]
GO
ALTER DATABASE [TestInnomDB] SET  READ_WRITE 
GO
