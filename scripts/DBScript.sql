USE [master]
GO
/****** Object:  Database [BlogsManagement]    Script Date: 7/10/2020 6:03:09 PM ******/
CREATE DATABASE [BlogsManagement]
GO
ALTER DATABASE [BlogsManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogsManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogsManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogsManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogsManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogsManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogsManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogsManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlogsManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogsManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogsManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogsManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogsManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogsManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogsManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogsManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogsManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlogsManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogsManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogsManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogsManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogsManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogsManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogsManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogsManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [BlogsManagement] SET  MULTI_USER 
GO
ALTER DATABASE [BlogsManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogsManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogsManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogsManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogsManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BlogsManagement', N'ON'
GO
ALTER DATABASE [BlogsManagement] SET QUERY_STORE = OFF
GO
USE [BlogsManagement]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 7/10/2020 6:03:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](250) NULL,
	[LastName] [varchar](250) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[BlogPost]    Script Date: 7/10/2020 6:03:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPost](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AuthorId] [bigint] NOT NULL,
	[Title] [varchar](250) NOT NULL,
 CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (1, N'Joydip', N'Kanjilal')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (2, N'Steve', N'Smith')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (3, N'Anand', N'Narayanaswamy')
SET IDENTITY_INSERT [dbo].[Author] OFF
GO

SET IDENTITY_INSERT [dbo].[BlogPost] ON 

INSERT [dbo].[BlogPost] ([Id], [Title], [AuthorId]) VALUES (1, N'Introducing C# 10.0', 1)
INSERT [dbo].[BlogPost] ([Id], [Title], [AuthorId]) VALUES (2, N'Introducing Entity Framework Core', 2)
INSERT [dbo].[BlogPost] ([Id], [Title], [AuthorId]) VALUES (3, N'Introducing Kubernetes', 1)
INSERT [dbo].[BlogPost] ([Id], [Title], [AuthorId]) VALUES (4, N'Introducing Machine Learning', 2)
INSERT [dbo].[BlogPost] ([Id], [Title], [AuthorId]) VALUES (5, N'Introducing DevSecOps', 3)
SET IDENTITY_INSERT [dbo].[BlogPost] OFF
GO

SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[BlogPost]  WITH CHECK ADD  CONSTRAINT [FK_BlogPost_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
GO
USE [master]
GO
ALTER DATABASE [BlogsManagement] SET  READ_WRITE 
GO

USE [BlogsManagement]
