USE [master]
GO
/****** Object:  Database [AssetManagementDB]    Script Date: 1/3/2021 11:30:27 AM ******/
CREATE DATABASE [AssetManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AssetManagementDB', FILENAME = N'C:\Users\SABIC\AssetManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AssetManagementDB_log', FILENAME = N'C:\Users\SABIC\AssetManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AssetManagementDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AssetManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AssetManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AssetManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AssetManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AssetManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AssetManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AssetManagementDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AssetManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AssetManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AssetManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AssetManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AssetManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AssetManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AssetManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AssetManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AssetManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AssetManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AssetManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AssetManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AssetManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AssetManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AssetManagementDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AssetManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AssetManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AssetManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [AssetManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AssetManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AssetManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AssetManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AssetManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AssetManagementDB] SET QUERY_STORE = OFF
GO
USE [AssetManagementDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [AssetManagementDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/3/2021 11:30:28 AM ******/
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
/****** Object:  Table [dbo].[Asset]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset](
	[TelephoneId] [int] NOT NULL,
	[ExtensionId] [int] NOT NULL,
	[InstalledDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Asset] PRIMARY KEY CLUSTERED 
(
	[TelephoneId] ASC,
	[ExtensionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BadgeNo] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Extension]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extension](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Usage] [int] NOT NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_Extension] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtherAsset]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtherAsset](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SerialNo] [nvarchar](max) NULL,
	[DN] [nvarchar](max) NULL,
	[Model] [nvarchar](max) NULL,
	[EmployeeId] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_OtherAsset] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pager]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pager](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Capcode] [nvarchar](max) NULL,
	[EmployeeId] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[Cust] [nvarchar](max) NULL,
	[RateCode] [nvarchar](max) NULL,
	[SerialNo] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[MailCode] [nvarchar](max) NULL,
	[Facility] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pager] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telephone]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telephone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MAC] [nvarchar](max) NULL,
	[SerialNo] [nvarchar](max) NULL,
	[Tag] [nvarchar](max) NULL,
	[Remark] [nvarchar](max) NULL,
	[SubCategoryId] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Telephone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Asset_ExtensionId]    Script Date: 1/3/2021 11:30:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Asset_ExtensionId] ON [dbo].[Asset]
(
	[ExtensionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_DepartmentId]    Script Date: 1/3/2021 11:30:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Employee_DepartmentId] ON [dbo].[Employee]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Extension_EmployeeId]    Script Date: 1/3/2021 11:30:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Extension_EmployeeId] ON [dbo].[Extension]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OtherAsset_EmployeeId]    Script Date: 1/3/2021 11:30:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_OtherAsset_EmployeeId] ON [dbo].[OtherAsset]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pager_EmployeeId]    Script Date: 1/3/2021 11:30:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Pager_EmployeeId] ON [dbo].[Pager]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubCategory_CategoryId]    Script Date: 1/3/2021 11:30:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_SubCategory_CategoryId] ON [dbo].[SubCategory]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Telephone_SubCategoryId]    Script Date: 1/3/2021 11:30:28 AM ******/
CREATE NONCLUSTERED INDEX [IX_Telephone_SubCategoryId] ON [dbo].[Telephone]
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asset] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [InstalledDate]
GO
ALTER TABLE [dbo].[OtherAsset] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Telephone] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_Extension_ExtensionId] FOREIGN KEY([ExtensionId])
REFERENCES [dbo].[Extension] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_Extension_ExtensionId]
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_Telephone_TelephoneId] FOREIGN KEY([TelephoneId])
REFERENCES [dbo].[Telephone] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_Telephone_TelephoneId]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department_DepartmentId]
GO
ALTER TABLE [dbo].[Extension]  WITH CHECK ADD  CONSTRAINT [FK_Extension_Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Extension] CHECK CONSTRAINT [FK_Extension_Employee_EmployeeId]
GO
ALTER TABLE [dbo].[OtherAsset]  WITH CHECK ADD  CONSTRAINT [FK_OtherAsset_Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[OtherAsset] CHECK CONSTRAINT [FK_OtherAsset_Employee_EmployeeId]
GO
ALTER TABLE [dbo].[Pager]  WITH CHECK ADD  CONSTRAINT [FK_Pager_Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Pager] CHECK CONSTRAINT [FK_Pager_Employee_EmployeeId]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category_CategoryId]
GO
ALTER TABLE [dbo].[Telephone]  WITH CHECK ADD  CONSTRAINT [FK_Telephone_SubCategory_SubCategoryId] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Telephone] CHECK CONSTRAINT [FK_Telephone_SubCategory_SubCategoryId]
GO
/****** Object:  StoredProcedure [dbo].[sp_SubCategoryGetById]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_SubCategoryGetById]
@Id int
as
set nocount on;
select * from SubCategory where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_TelephoneDelete]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TelephoneDelete]
@Id int
as
set nocount on;
delete from Telephone where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_TelephoneGetAll]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TelephoneGetAll]
as
set nocount on;
select * from Telephone
GO
/****** Object:  StoredProcedure [dbo].[sp_TelephoneGetById]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TelephoneGetById]
@Id int
as
set nocount on;
select * from Telephone where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_TelephoneGetRelatedData]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TelephoneGetRelatedData]
@Id int
as
set nocount on
begin
select Telephone.Id,
	   Telephone.MAC,
	   Telephone.SerialNo,
	   Telephone.Tag,
	   Telephone.IsDefective,
	   Telephone.Remark,
	   SubCategory.[Name] as 'Type',
	   Category.[Name] as 'Brand',
	   Employee.[Name] as 'User',
	   Employee.BadgeNo,
	   Department.[Name] as 'Department',
	   TelephoneExtension.InstalledDate,
	   Extension.[Number] as 'Extension',
	   Extension.Usage as 'ExtType'

from Telephone inner join SubCategory on Telephone.SubCategoryId = SubCategory.Id
			   inner join Category on SubCategory.CategoryId = Category.Id
			   inner join TelephoneEmployee on Telephone.Id =  TelephoneEmployee.TelephoneId
			   inner join Employee on TelephoneEmployee.EmployeeId = Employee.Id
			   inner join Department on Employee.DepartmentId = Department.Id
			   inner join TelephoneExtension on Telephone.Id = TelephoneExtension.TelephoneId
			   inner join Extension on TelephoneExtension.ExtensionId = Extension.Id
where Telephone.Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TelephoneInsert]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TelephoneInsert]
@Id int output,
@MAC nvarchar(50),
@SerialNo nvarchar(50),
@Tag nvarchar(50),
@IsDefective bit,
@Remark nvarchar(50),
@SubCategoryId int
as
set nocount on;
insert into Telephone (MAC, SerialNo, Tag, IsDefective, Remark, SubCategoryId)
values (@MAC, @SerialNo, @Tag, @IsDefective, @Remark, @SubCategoryId)
select @Id = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[sp_TelephoneUpdate]    Script Date: 1/3/2021 11:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TelephoneUpdate]
@Id int,
@MAC nvarchar(50),
@SerialNo nvarchar(50),
@Tag nvarchar (50),
@IsDefective bit,
@Remark nvarchar(50)
as
set nocount on;
update Telephone 
	set MAC = @MAC,
		SerialNo = @SerialNo,
		Tag = @Tag,
		IsDefective = @IsDefective,
		Remark = @Remark
	where Id = @Id
GO
USE [master]
GO
ALTER DATABASE [AssetManagementDB] SET  READ_WRITE 
GO
