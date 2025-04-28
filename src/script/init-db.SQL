USE [master]
GO
/****** Object:  Database [promos]    Script Date: 2025-04-20 11:58:18 AM ******/
CREATE DATABASE [promos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'promos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\promos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'promos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\promos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [promos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [promos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [promos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [promos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [promos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [promos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [promos] SET ARITHABORT OFF 
GO
ALTER DATABASE [promos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [promos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [promos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [promos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [promos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [promos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [promos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [promos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [promos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [promos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [promos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [promos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [promos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [promos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [promos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [promos] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [promos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [promos] SET RECOVERY FULL 
GO
ALTER DATABASE [promos] SET  MULTI_USER 
GO
ALTER DATABASE [promos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [promos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [promos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [promos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [promos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [promos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'promos', N'ON'
GO
ALTER DATABASE [promos] SET QUERY_STORE = OFF
GO
USE [promos]
GO
/****** Object:  User [alloprom]    Script Date: 2025-04-20 11:58:18 AM ******/
CREATE USER [alloprom] FOR LOGIN [alloprom] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2025-04-20 11:58:18 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2025-04-20 11:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2025-04-20 11:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[ApplicationUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2025-04-20 11:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2025-04-20 11:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2025-04-20 11:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2025-04-20 11:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Type] [int] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[firstName] [nvarchar](max) NULL,
	[isAdmin] [bit] NOT NULL,
	[isMerchant] [bit] NOT NULL,
	[lastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2025-04-20 11:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2025-04-20 11:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[cityId] [int] IDENTITY(1,1) NOT NULL,
	[cityName] [nvarchar](max) NULL,
	[cityGpsLongitude] [nvarchar](max) NULL,
	[cityGpsLatitude] [nvarchar](max) NULL,
	[cityCountrycountryId] [int] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[cityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 2025-04-20 11:58:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[countryId] [int] IDENTITY(1,1) NOT NULL,
	[countryName] [nvarchar](max) NULL,
	[regionId] [int] NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[countryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 2025-04-20 11:58:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[departmentId] [nvarchar](450) NOT NULL,
	[departmentName] [nvarchar](max) NULL,
	[departmentThumbnail] [nvarchar](max) NULL,
	[createdDate] [datetime2](7) NOT NULL,
	[updatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[departmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2025-04-20 11:58:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[orderNumber] [int] NOT NULL,
	[orderDate] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 2025-04-20 11:58:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[productCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[productCategoryName] [nvarchar](max) NULL,
	[Created] [datetime2](7) NOT NULL,
	[createdDate] [datetime2](7) NOT NULL,
	[updatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[productCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2025-04-20 11:58:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[productId] [nvarchar](450) NOT NULL,
	[productName] [nvarchar](max) NULL,
	[productDescription] [nvarchar](max) NULL,
	[productStatus] [int] NOT NULL,
	[productCategoryId] [int] NULL,
	[storeId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 2025-04-20 11:58:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[regionId] [int] IDENTITY(1,1) NOT NULL,
	[regionName] [nvarchar](max) NULL,
	[createdDate] [datetime2](7) NOT NULL,
	[updatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[regionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreCategories]    Script Date: 2025-04-20 11:58:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreCategories](
	[categoryId] [uniqueidentifier] NOT NULL,
	[storeCategoryName] [nvarchar](max) NULL,
	[storeCreated] [datetime2](7) NOT NULL,
	[storeExpires] [datetime2](7) NULL,
	[active] [bit] NOT NULL,
	[departmentId] [nvarchar](450) NULL,
 CONSTRAINT [PK_StoreCategories] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stores]    Script Date: 2025-04-20 11:58:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[storeId] [uniqueidentifier] NOT NULL,
	[storeName] [nvarchar](max) NULL,
	[storeDescription] [nvarchar](max) NULL,
	[storeCreatedOn] [datetime2](7) NOT NULL,
	[storeExpires] [datetime2](7) NOT NULL,
	[CategorystoreCategoryId] [uniqueidentifier] NULL,
	[cityId] [int] NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED 
(
	[storeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230907115243_v0', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240928094547_AddedCustom', N'5.0.7')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [ApplicationUserId]) VALUES (N'50ceaa91-8fa9-435b-b559-0d582463d4c3', N'Su', N'SU', N'eee72ad5-c100-4c37-80da-7db4a5eac5ba', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [ApplicationUserId]) VALUES (N'586dd2e6-31d8-4da9-9255-dbcabf7eab12', N'Clients', N'CLIENTS', N'5be62fc3-7ed4-4d7d-b060-b296c11364c2', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [ApplicationUserId]) VALUES (N'bb0b71f6-bd66-44c1-871b-ccbb6b667543', N'Users', N'USERS', N'61afdcd5-e85e-41db-8665-32ee686631d8', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [ApplicationUserId]) VALUES (N'e17ca1b1-967e-4afd-aa04-fd2791f25b57', N'Merchants', N'MERCHANTS', N'32fc4a17-ae4a-4a60-a395-1491bea59fef', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1b16874a-7f1c-40c9-89cc-270dacd6303d', N'e17ca1b1-967e-4afd-aa04-fd2791f25b57')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a426a1c7-7b47-4f9d-8fe3-c72466629533', N'e17ca1b1-967e-4afd-aa04-fd2791f25b57')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Type], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [firstName], [isAdmin], [isMerchant], [lastName]) VALUES (N'1b16874a-7f1c-40c9-89cc-270dacd6303d', 1, N'joe@allo.cc', N'JOE@ALLO.CC', N'joe@allo.cc', N'JOE@ALLO.CC', 0, N'AQAAAAEAACcQAAAAEI0pU5OVsPYgMD4UOA4QYgXwiLmz7+d5LWKJCa2Kl9QMkZSG+W+LAni0oXkJOKYPBg==', N'T7F53AL2L7HTSKUX7M7E6CPBI7ATSYJY', N'00c48a80-48a9-48d3-a8a5-1a93b12a782b', N'7575757', 0, 0, NULL, 1, 0, N'Joe', 0, 0, N'Allo')
INSERT [dbo].[AspNetUsers] ([Id], [Type], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [firstName], [isAdmin], [isMerchant], [lastName]) VALUES (N'43302754-9ff5-4e5d-9342-ba5dab6f30e4', 1, N'joe@allopay.ez', N'JOE@ALLOPAY.EZ', N'joe@allopay.ez', N'JOE@ALLOPAY.EZ', 0, N'AQAAAAEAACcQAAAAEM2mI1BOd32YSg4YMElxswGVGjx2Wxb2dRjpAqPTTJFS7ALpWZ9TyEFleThAgq33Ig==', N'G2RI3RJBLHO7YVH4GHZ4SZ3ML45LMNTS', N'9f62cdb8-7ad8-47c0-9363-6f8436a9989a', N'908978', 0, 0, NULL, 1, 0, N'allo', 0, 0, N'joe')
INSERT [dbo].[AspNetUsers] ([Id], [Type], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [firstName], [isAdmin], [isMerchant], [lastName]) VALUES (N'a426a1c7-7b47-4f9d-8fe3-c72466629533', 1, N'joe@allopay.cc', N'JOE@ALLOPAY.CC', N'joe@allopay.cc', N'JOE@ALLOPAY.CC', 0, N'AQAAAAEAACcQAAAAEAHkszTbA5RuWB+PQLiZJWGnRF5Vv/a+ejlGrb0Oq02A3RH16D55ieO5hoizP5VSGw==', N'EB2NH7JYABKH6YPAV5ZCPAKPVNB75KZM', N'3491f013-d4de-46dd-9a9a-133596b593b1', N'70565011', 0, 0, NULL, 1, 0, N'Joe', 0, 0, N'Mama')
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([cityId], [cityName], [cityGpsLongitude], [cityGpsLatitude], [cityCountrycountryId]) VALUES (1, N'Dapaong', N'', N'', NULL)
INSERT [dbo].[Cities] ([cityId], [cityName], [cityGpsLongitude], [cityGpsLatitude], [cityCountrycountryId]) VALUES (2, N'Mango', N'', N'', NULL)
INSERT [dbo].[Cities] ([cityId], [cityName], [cityGpsLongitude], [cityGpsLatitude], [cityCountrycountryId]) VALUES (3, N'Nimatougou', NULL, NULL, NULL)
INSERT [dbo].[Cities] ([cityId], [cityName], [cityGpsLongitude], [cityGpsLatitude], [cityCountrycountryId]) VALUES (4, N'Bassar', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
INSERT [dbo].[Departments] ([departmentId], [departmentName], [departmentThumbnail], [createdDate], [updatedDate]) VALUES (N'd736a281-ac2e-4be2-a807-d5e000db1983', N'Hello Department', NULL, CAST(N'2023-09-07T12:07:08.8935150' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[ProductCategories] ON 

INSERT [dbo].[ProductCategories] ([productCategoryId], [productCategoryName], [Created], [createdDate], [updatedDate]) VALUES (5, N'Mode et Vetements', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductCategories] ([productCategoryId], [productCategoryName], [Created], [createdDate], [updatedDate]) VALUES (6, N'Alimentation& Boissons', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductCategories] ([productCategoryId], [productCategoryName], [Created], [createdDate], [updatedDate]) VALUES (8, N'Liqueurs', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
GO
INSERT [dbo].[Products] ([productId], [productName], [productDescription], [productStatus], [productCategoryId], [storeId]) VALUES (N'50919d08-7161-4289-a9a1-6057a8461bbc', N'kejfkdjf', N'dkfkdjfk', 0, 8, N'50919d08-7161-4289-a9a1-6057a8461bbc')
INSERT [dbo].[Products] ([productId], [productName], [productDescription], [productStatus], [productCategoryId], [storeId]) VALUES (N'5575d7db-cdd8-44c8-92dc-be5ecfb5cd29', N'dkjgksjgkfkj', N'fkjgkjfgj', 0, 8, N'50919d08-7161-4289-a9a1-6057a8461bbc')
INSERT [dbo].[Products] ([productId], [productName], [productDescription], [productStatus], [productCategoryId], [storeId]) VALUES (N'60e7af6e-2acf-494a-91d2-9335eb3ecaaf', N'qkjkerj', N'erere', 0, 5, N'50919d08-7161-4289-a9a1-6057a8461bbc')
INSERT [dbo].[Products] ([productId], [productName], [productDescription], [productStatus], [productCategoryId], [storeId]) VALUES (N'8da3150c-763f-45a5-b648-e25b02ea553d', N'igc produit', N'produit produit produit', 0, 8, N'50919d08-7161-4289-a9a1-6057a8461bbc')
GO
INSERT [dbo].[StoreCategories] ([categoryId], [storeCategoryName], [storeCreated], [storeExpires], [active], [departmentId]) VALUES (N'49ea4f6c-e698-44a1-a489-df2b72c0cd68', N'Boucherie', CAST(N'2024-09-22T13:17:21.0000000' AS DateTime2), CAST(N'2124-09-22T13:34:21.0000000' AS DateTime2), 1, NULL)
GO
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'57d6fca7-0409-4d2f-932d-05213589442f', N'hello Magazin', N'hhn', CAST(N'2025-04-01T09:53:56.3174306' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'43302754-9ff5-4e5d-9342-ba5dab6f30e4')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'19b861e8-4686-4a1b-ab5c-206da7979ea9', N'nnnn', N'bbbb', CAST(N'2025-03-26T19:58:46.4648220' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'43302754-9ff5-4e5d-9342-ba5dab6f30e4')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'8d6ecefa-fdbe-4ed2-9e90-40525fb82733', N'hello Magazin', N'hhn', CAST(N'2025-04-01T09:38:57.7218971' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'43302754-9ff5-4e5d-9342-ba5dab6f30e4')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'c22c23b8-f353-460c-83f8-5cfefbce6ac5', N'hello Magazin', N'hhn', CAST(N'2025-04-01T09:53:56.3183802' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'43302754-9ff5-4e5d-9342-ba5dab6f30e4')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'50919d08-7161-4289-a9a1-6057a8461bbc', N'babalola Store', N'babalola store', CAST(N'2025-03-17T19:52:13.4512648' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'49ea4f6c-e698-44a1-a489-df2b72c0cd68', 1, N'1b16874a-7f1c-40c9-89cc-270dacd6303d')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'c4b0e701-c350-4860-bc66-74c5bb92feb3', N'hello poutik', N'hhhhhjjjjj', CAST(N'2025-04-01T09:07:43.0291224' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'43302754-9ff5-4e5d-9342-ba5dab6f30e4')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'4924b3ba-040e-4470-bfb2-922659bd4393', N'jhh', N'bhgg', CAST(N'2025-03-26T19:40:28.1808560' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'1b16874a-7f1c-40c9-89cc-270dacd6303d')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'9c5b3cec-dfe8-4e72-bd02-9712f864ff68', N'Joe Boutik', N'description of store', CAST(N'2025-03-14T16:30:21.7144292' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'49ea4f6c-e698-44a1-a489-df2b72c0cd68', 1, N'1b16874a-7f1c-40c9-89cc-270dacd6303d')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'34eef389-eb4d-4a83-b24c-98c8ee756685', N'hello Magazin', N'hhn h', CAST(N'2025-04-01T11:42:20.3885227' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'a426a1c7-7b47-4f9d-8fe3-c72466629533')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'44aee02f-7343-4ef7-83b7-9dbbdf4070ad', N'hello poutik', N'hhhhhjjjjj', CAST(N'2025-04-01T09:07:43.0291126' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'43302754-9ff5-4e5d-9342-ba5dab6f30e4')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'6cf38af8-a19d-4902-acb6-9f599cc52a97', N'allooPayez', N'allopaYEZ', CAST(N'2025-03-17T19:55:12.8086988' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'49ea4f6c-e698-44a1-a489-df2b72c0cd68', 2, N'1b16874a-7f1c-40c9-89cc-270dacd6303d')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'8994ed7c-83d2-4520-961c-b1609a669eb5', N'hello Proprete', N'hello', CAST(N'2025-04-01T09:19:10.6182068' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'43302754-9ff5-4e5d-9342-ba5dab6f30e4')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'c6af0897-4441-4fb4-b7f1-beed9449b542', N'hello Magazin', N'hhn', CAST(N'2025-04-01T11:03:35.9854622' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'1b16874a-7f1c-40c9-89cc-270dacd6303d')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'267e62f9-b0ed-4552-bf82-dd561d05fdd7', N'hello Proprete', N'hello', CAST(N'2025-04-01T09:16:15.1493376' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'43302754-9ff5-4e5d-9342-ba5dab6f30e4')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'8cb9c1de-d8d4-40ec-a8b2-f0f842169e1e', N'ghghj', N'description of store', CAST(N'2025-03-17T19:16:35.3049560' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'49ea4f6c-e698-44a1-a489-df2b72c0cd68', 1, N'1b16874a-7f1c-40c9-89cc-270dacd6303d')
INSERT [dbo].[Stores] ([storeId], [storeName], [storeDescription], [storeCreatedOn], [storeExpires], [CategorystoreCategoryId], [cityId], [UserId]) VALUES (N'85790238-5ba9-482c-891a-fa118c6e1f07', N'bbbabalola boui', N'description of store', CAST(N'2025-03-17T19:34:36.7342659' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'49ea4f6c-e698-44a1-a489-df2b72c0cd68', 1, N'1b16874a-7f1c-40c9-89cc-270dacd6303d')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoles_ApplicationUserId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoles_ApplicationUserId] ON [dbo].[AspNetRoles]
(
	[ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cities_cityCountrycountryId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_Cities_cityCountrycountryId] ON [dbo].[Cities]
(
	[cityCountrycountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Countries_regionId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_Countries_regionId] ON [dbo].[Countries]
(
	[regionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_productCategoryId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_productCategoryId] ON [dbo].[Products]
(
	[productCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_storeId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_storeId] ON [dbo].[Products]
(
	[storeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_StoreCategories_departmentId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_StoreCategories_departmentId] ON [dbo].[StoreCategories]
(
	[departmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Stores_CategorystoreCategoryId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_Stores_CategorystoreCategoryId] ON [dbo].[Stores]
(
	[CategorystoreCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Stores_cityId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_Stores_cityId] ON [dbo].[Stores]
(
	[cityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Stores_UserId]    Script Date: 2025-04-20 11:58:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_Stores_UserId] ON [dbo].[Stores]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isAdmin]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isMerchant]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoles_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetRoles] CHECK CONSTRAINT [FK_AspNetRoles_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries_cityCountrycountryId] FOREIGN KEY([cityCountrycountryId])
REFERENCES [dbo].[Countries] ([countryId])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries_cityCountrycountryId]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Regions_regionId] FOREIGN KEY([regionId])
REFERENCES [dbo].[Regions] ([regionId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Regions_regionId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategories_productCategoryId] FOREIGN KEY([productCategoryId])
REFERENCES [dbo].[ProductCategories] ([productCategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategories_productCategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Stores_storeId] FOREIGN KEY([storeId])
REFERENCES [dbo].[Stores] ([storeId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Stores_storeId]
GO
ALTER TABLE [dbo].[StoreCategories]  WITH CHECK ADD  CONSTRAINT [FK_StoreCategories_Departments_departmentId] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Departments] ([departmentId])
GO
ALTER TABLE [dbo].[StoreCategories] CHECK CONSTRAINT [FK_StoreCategories_Departments_departmentId]
GO
ALTER TABLE [dbo].[Stores]  WITH CHECK ADD  CONSTRAINT [FK_Stores_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Stores] CHECK CONSTRAINT [FK_Stores_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Stores]  WITH CHECK ADD  CONSTRAINT [FK_Stores_Cities_cityId] FOREIGN KEY([cityId])
REFERENCES [dbo].[Cities] ([cityId])
GO
ALTER TABLE [dbo].[Stores] CHECK CONSTRAINT [FK_Stores_Cities_cityId]
GO
ALTER TABLE [dbo].[Stores]  WITH CHECK ADD  CONSTRAINT [FK_Stores_StoreCategories_CategorystoreCategoryId] FOREIGN KEY([CategorystoreCategoryId])
REFERENCES [dbo].[StoreCategories] ([categoryId])
GO
ALTER TABLE [dbo].[Stores] CHECK CONSTRAINT [FK_Stores_StoreCategories_CategorystoreCategoryId]
GO
USE [master]
GO
ALTER DATABASE [promos] SET  READ_WRITE 
GO
