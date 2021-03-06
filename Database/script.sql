USE [master]
GO
/****** Object:  Database [HotelManagement]    Script Date: 03-05-2020 22:32:37 ******/
CREATE DATABASE [HotelManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HotelManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HotelManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HotelManagement] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelManagement] SET  MULTI_USER 
GO
ALTER DATABASE [HotelManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelManagement] SET QUERY_STORE = OFF
GO
USE [HotelManagement]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 03-05-2020 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NOT NULL,
	[Booking Date] [date] NOT NULL,
	[Status] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 03-05-2020 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Details] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 03-05-2020 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Pin Code] [varchar](12) NOT NULL,
	[Contact Number] [varchar](13) NOT NULL,
	[Contact Person] [varchar](50) NOT NULL,
	[Website] [varchar](max) NOT NULL,
	[Facebook] [varchar](max) NOT NULL,
	[Twitter] [varchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Created Date] [date] NOT NULL,
	[Created By] [varchar](50) NOT NULL,
	[Updated Date] [date] NULL,
	[Updated By] [varchar](50) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 03-05-2020 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HotelID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Category] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Created Date] [date] NOT NULL,
	[Created By] [varchar](50) NOT NULL,
	[Updated Date] [date] NULL,
	[Updated By] [varchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Details]) VALUES (1, N'Categories 1', N'size <35 m2')
INSERT [dbo].[Category] ([ID], [Name], [Details]) VALUES (2, N'Categories 2', N'size 36-50 m2')
INSERT [dbo].[Category] ([ID], [Name], [Details]) VALUES (3, N'Categories 3', N'size 51-100 m2')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Hotel] ON 

INSERT [dbo].[Hotel] ([ID], [Name], [Address], [City], [Pin Code], [Contact Number], [Contact Person], [Website], [Facebook], [Twitter], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (1, N'Dev', N'NH 8', N'Vadodara', N'123456', N'9874563210', N'Hardik', N'https://www.Dev.com', N'https://www.facebook.com/Dev', N'https://www.twitter.com/Dev', 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Hotel] ([ID], [Name], [Address], [City], [Pin Code], [Contact Number], [Contact Person], [Website], [Facebook], [Twitter], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (2, N'Taj', N'NH 8', N'Mumbai', N'321456', N'9874563210', N'Hardik', N'https://www.Dev.com', N'https://www.facebook.com/Dev', N'https://www.twitter.com/Dev', 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Hotel] ([ID], [Name], [Address], [City], [Pin Code], [Contact Number], [Contact Person], [Website], [Facebook], [Twitter], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (3, N'Dev', N'NH 8', N'Mumbai', N'321456', N'9874563210', N'Hardik', N'https://www.Dev.com', N'https://www.facebook.com/Dev', N'https://www.twitter.com/Dev', 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Hotel] ([ID], [Name], [Address], [City], [Pin Code], [Contact Number], [Contact Person], [Website], [Facebook], [Twitter], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (4, N'Dev', N'NH 8', N'Vadodara', N'321456', N'9874563210', N'Hardik', N'https://www.Dev.com', N'https://www.facebook.com/Dev', N'https://www.twitter.com/Dev', 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Hotel] ([ID], [Name], [Address], [City], [Pin Code], [Contact Number], [Contact Person], [Website], [Facebook], [Twitter], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (5, N'Paradise', N'NH 8', N'Goa', N'365412', N'9874563210', N'Hardik', N'https://www.Dev.com', N'https://www.facebook.com/Dev', N'https://www.twitter.com/Dev', 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Hotel] ([ID], [Name], [Address], [City], [Pin Code], [Contact Number], [Contact Person], [Website], [Facebook], [Twitter], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (6, N'Blue', N'NH 8', N'Delhi', N'300855', N'9874563210', N'Hardik', N'https://www.Dev.com', N'https://www.facebook.com/Dev', N'https://www.twitter.com/Dev', 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Hotel] ([ID], [Name], [Address], [City], [Pin Code], [Contact Number], [Contact Person], [Website], [Facebook], [Twitter], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (7, N'Greenland', N'NH 8', N'Delhi', N'300855', N'9874563210', N'Hardik', N'https://www.Dev.com', N'https://www.facebook.com/Dev', N'https://www.twitter.com/Dev', 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Hotel] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (5, 1, N'Delux', 1, 1500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (6, 1, N'Super Delux', 2, 2500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (7, 1, N'Prime Delux', 3, 3500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (8, 2, N'Prime Delux', 3, 3500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (9, 2, N'Super Delux', 2, 2500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (10, 2, N'Delux', 1, 1500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (11, 3, N'Delux', 1, 1500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (12, 3, N'Super Delux', 2, 2500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (13, 3, N'Super Delux', 3, 3500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (14, 4, N'Super Delux', 3, 3500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (15, 4, N'Super Delux', 2, 2500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (16, 4, N'Super Delux', 1, 1500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (17, 5, N'Delux', 1, 1500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
INSERT [dbo].[Room] ([ID], [HotelID], [Name], [Category], [Price], [IsActive], [Created Date], [Created By], [Updated Date], [Updated By]) VALUES (18, 5, N'Delux', 2, 2500, 1, CAST(N'2020-05-03' AS Date), N'Hardik', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Room] OFF
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Room]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Category]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
USE [master]
GO
ALTER DATABASE [HotelManagement] SET  READ_WRITE 
GO
