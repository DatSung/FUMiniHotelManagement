USE [master]
GO
/****** Object:  Database [FUMiniHotelManagement]    Script Date: 10/29/2024 10:41:41 PM ******/
CREATE DATABASE [FUMiniHotelManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FUMiniHotelManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FUMiniHotelManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FUMiniHotelManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FUMiniHotelManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FUMiniHotelManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FUMiniHotelManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FUMiniHotelManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FUMiniHotelManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FUMiniHotelManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FUMiniHotelManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FUMiniHotelManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FUMiniHotelManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FUMiniHotelManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FUMiniHotelManagement] SET  MULTI_USER 
GO
ALTER DATABASE [FUMiniHotelManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FUMiniHotelManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FUMiniHotelManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FUMiniHotelManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FUMiniHotelManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FUMiniHotelManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FUMiniHotelManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [FUMiniHotelManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FUMiniHotelManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/29/2024 10:41:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingDetail]    Script Date: 10/29/2024 10:41:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetail](
	[BookingReservationID] [uniqueidentifier] NOT NULL,
	[RoomID] [uniqueidentifier] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[ActualPrice] [money] NULL,
 CONSTRAINT [PK_BookingDetail] PRIMARY KEY CLUSTERED 
(
	[BookingReservationID] ASC,
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingReservation]    Script Date: 10/29/2024 10:41:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingReservation](
	[BookingReservationID] [uniqueidentifier] NOT NULL,
	[BookingDate] [date] NULL,
	[TotalPrice] [money] NULL,
	[CustomerID] [uniqueidentifier] NOT NULL,
	[BookingStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_BookingReservation] PRIMARY KEY CLUSTERED 
(
	[BookingReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomInformation]    Script Date: 10/29/2024 10:41:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomInformation](
	[RoomID] [uniqueidentifier] NOT NULL,
	[RoomNumber] [nvarchar](50) NOT NULL,
	[RoomDetailDescription] [nvarchar](220) NULL,
	[RoomMaxCapacity] [int] NULL,
	[RoomTypeID] [uniqueidentifier] NOT NULL,
	[RoomStatus] [nvarchar](max) NULL,
	[RoomPricePerDay] [money] NULL,
 CONSTRAINT [PK_RoomInformation] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 10/29/2024 10:41:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeID] [uniqueidentifier] NOT NULL,
	[RoomTypeName] [nvarchar](50) NOT NULL,
	[TypeDescription] [nvarchar](250) NULL,
	[TypeNote] [nvarchar](250) NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[RoomTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/29/2024 10:41:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Telephone] [nvarchar](12) NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[Birthday] [date] NULL,
	[Status] [nvarchar](max) NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [nchar](10) NULL,
	[AvatarUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014164251_Init_Migration', N'6.0.35')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014164755_Change_DataType_UserStatus', N'6.0.35')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241015073726_Change_Status_All', N'6.0.35')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241025102603_AddAvatarUrlForUser', N'6.0.35')
GO
INSERT [dbo].[RoomType] ([RoomTypeID], [RoomTypeName], [TypeDescription], [TypeNote]) VALUES (N'c275be28-075e-46f9-9cc7-ebe586092792', N'Economy', N'For Alone', N'2 Rooms')
INSERT [dbo].[RoomType] ([RoomTypeID], [RoomTypeName], [TypeDescription], [TypeNote]) VALUES (N'c275be28-075e-46f9-9cc7-ebe58609279d', N'Master', N'For Expanded', N'4 Rooms')
GO
INSERT [dbo].[User] ([UserId], [FullName], [Telephone], [EmailAddress], [Birthday], [Status], [Password], [Role], [AvatarUrl]) VALUES (N'40096247-6837-4416-9a66-1b9a93764e0e', N'Nguyen Thanh Dat', N'0339315466', N'admin', CAST(N'2024-03-01' AS Date), N'Activated', N'admin', N'Admin     ', NULL)
GO
/****** Object:  Index [IX_BookingDetail_RoomID]    Script Date: 10/29/2024 10:41:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookingDetail_RoomID] ON [dbo].[BookingDetail]
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookingReservation_CustomerID]    Script Date: 10/29/2024 10:41:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookingReservation_CustomerID] ON [dbo].[BookingReservation]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoomInformation_RoomTypeID]    Script Date: 10/29/2024 10:41:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoomInformation_RoomTypeID] ON [dbo].[RoomInformation]
(
	[RoomTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Customer__49A14740FDE69030]    Script Date: 10/29/2024 10:41:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Customer__49A14740FDE69030] ON [dbo].[User]
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetail_BookingReservation] FOREIGN KEY([BookingReservationID])
REFERENCES [dbo].[BookingReservation] ([BookingReservationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookingDetail] CHECK CONSTRAINT [FK_BookingDetail_BookingReservation]
GO
ALTER TABLE [dbo].[BookingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetail_RoomInformation] FOREIGN KEY([RoomID])
REFERENCES [dbo].[RoomInformation] ([RoomID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookingDetail] CHECK CONSTRAINT [FK_BookingDetail_RoomInformation]
GO
ALTER TABLE [dbo].[BookingReservation]  WITH CHECK ADD  CONSTRAINT [FK_BookingReservation_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookingReservation] CHECK CONSTRAINT [FK_BookingReservation_Customer]
GO
ALTER TABLE [dbo].[RoomInformation]  WITH CHECK ADD  CONSTRAINT [FK_RoomInformation_RoomType] FOREIGN KEY([RoomTypeID])
REFERENCES [dbo].[RoomType] ([RoomTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomInformation] CHECK CONSTRAINT [FK_RoomInformation_RoomType]
GO
USE [master]
GO
ALTER DATABASE [FUMiniHotelManagement] SET  READ_WRITE 
GO
