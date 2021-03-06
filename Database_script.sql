USE [master]
GO
/****** Object:  Database [Notification_DB]    Script Date: 28/02/2019 09:00:13 م ******/
CREATE DATABASE [Notification_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Notification_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Notification_DB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Notification_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Notification_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Notification_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Notification_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Notification_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Notification_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Notification_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Notification_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Notification_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Notification_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Notification_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Notification_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Notification_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Notification_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Notification_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Notification_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Notification_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Notification_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Notification_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Notification_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Notification_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Notification_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Notification_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Notification_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Notification_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Notification_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Notification_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Notification_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [Notification_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Notification_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Notification_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Notification_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Notification_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Notification_DB', N'ON'
GO
USE [Notification_DB]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 28/02/2019 09:00:13 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL,
	[Recipents] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table2]    Script Date: 28/02/2019 09:00:13 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table2](
	[userid] [int] NOT NULL,
	[not_id] [int] NOT NULL,
 CONSTRAINT [PK_Table2] PRIMARY KEY CLUSTERED 
(
	[userid] ASC,
	[not_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_cust]    Script Date: 28/02/2019 09:00:13 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_cust](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [varchar](10) NULL,
 CONSTRAINT [PK__tbl_cust__3213E83FB1EC5105] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([Id], [Date], [Title], [Message], [Recipents], [Status]) VALUES (1, N'4/1/2019', N'Tornado Warning', N'Seek Shalter immediatly', N'All Recipents', N'In Progress')
INSERT [dbo].[Notification] ([Id], [Date], [Title], [Message], [Recipents], [Status]) VALUES (2, N'8/2/2019', N'Earth Quick', N'evacuate the building', N'2', N'Deliverd')
SET IDENTITY_INSERT [dbo].[Notification] OFF
INSERT [dbo].[Table2] ([userid], [not_id]) VALUES (1, 1)
INSERT [dbo].[Table2] ([userid], [not_id]) VALUES (1, 2)
INSERT [dbo].[Table2] ([userid], [not_id]) VALUES (2, 2)
SET IDENTITY_INSERT [dbo].[tbl_cust] ON 

INSERT [dbo].[tbl_cust] ([id], [UserName], [Email], [Password]) VALUES (1, N'taha', N'taha@yahoo.com', N'123')
INSERT [dbo].[tbl_cust] ([id], [UserName], [Email], [Password]) VALUES (2, N'user1', N'user1@g.com', N'123')
SET IDENTITY_INSERT [dbo].[tbl_cust] OFF
ALTER TABLE [dbo].[Table2]  WITH CHECK ADD  CONSTRAINT [FK_Table2_Notification] FOREIGN KEY([not_id])
REFERENCES [dbo].[Notification] ([Id])
GO
ALTER TABLE [dbo].[Table2] CHECK CONSTRAINT [FK_Table2_Notification]
GO
ALTER TABLE [dbo].[Table2]  WITH CHECK ADD  CONSTRAINT [FK_Table2_tbl_cust] FOREIGN KEY([userid])
REFERENCES [dbo].[tbl_cust] ([id])
GO
ALTER TABLE [dbo].[Table2] CHECK CONSTRAINT [FK_Table2_tbl_cust]
GO
USE [master]
GO
ALTER DATABASE [Notification_DB] SET  READ_WRITE 
GO
