USE [AssetManagementDB]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 1/4/2021 4:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset](
	[InstalledDate] [datetime2](7) NOT NULL,
	[TelephoneSerialNo] [nvarchar](450) NOT NULL,
	[ExtensionNumber] [int] NOT NULL,
 CONSTRAINT [PK_Asset] PRIMARY KEY CLUSTERED 
(
	[TelephoneSerialNo] ASC,
	[ExtensionNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/4/2021 4:22:11 PM ******/
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
/****** Object:  Table [dbo].[Department]    Script Date: 1/4/2021 4:22:11 PM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 1/4/2021 4:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[BadgeNo] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[BadgeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Extension]    Script Date: 1/4/2021 4:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extension](
	[Number] [int] NOT NULL,
	[Usage] [int] NOT NULL,
	[EmployeeBadgeNo] [int] NULL,
 CONSTRAINT [PK_Extension] PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtherAsset]    Script Date: 1/4/2021 4:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtherAsset](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SerialNo] [nvarchar](max) NULL,
	[DN] [nvarchar](max) NULL,
	[Model] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[EmployeeBadgeNo] [int] NULL,
 CONSTRAINT [PK_OtherAsset] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pager]    Script Date: 1/4/2021 4:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pager](
	[SerialNo] [nvarchar](450) NOT NULL,
	[Number] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Capcode] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[Cust] [nvarchar](max) NULL,
	[RateCode] [nvarchar](max) NULL,
	[MailCode] [nvarchar](max) NULL,
	[Facility] [nvarchar](max) NULL,
	[EmployeeBadgeNo] [int] NULL,
 CONSTRAINT [PK_Pager] PRIMARY KEY CLUSTERED 
(
	[SerialNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 1/4/2021 4:22:11 PM ******/
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
/****** Object:  Table [dbo].[Telephone]    Script Date: 1/4/2021 4:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telephone](
	[SerialNo] [nvarchar](450) NOT NULL,
	[MAC] [nvarchar](max) NULL,
	[Tag] [nvarchar](max) NULL,
	[Remark] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[SubCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Telephone] PRIMARY KEY CLUSTERED 
(
	[SerialNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asset] ADD  DEFAULT (N'') FOR [TelephoneSerialNo]
GO
ALTER TABLE [dbo].[Asset] ADD  DEFAULT ((0)) FOR [ExtensionNumber]
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_Extension_ExtensionNumber] FOREIGN KEY([ExtensionNumber])
REFERENCES [dbo].[Extension] ([Number])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_Extension_ExtensionNumber]
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_Telephone_TelephoneSerialNo] FOREIGN KEY([TelephoneSerialNo])
REFERENCES [dbo].[Telephone] ([SerialNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_Telephone_TelephoneSerialNo]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department_DepartmentId]
GO
ALTER TABLE [dbo].[Extension]  WITH CHECK ADD  CONSTRAINT [FK_Extension_Employee_EmployeeBadgeNo] FOREIGN KEY([EmployeeBadgeNo])
REFERENCES [dbo].[Employee] ([BadgeNo])
GO
ALTER TABLE [dbo].[Extension] CHECK CONSTRAINT [FK_Extension_Employee_EmployeeBadgeNo]
GO
ALTER TABLE [dbo].[OtherAsset]  WITH CHECK ADD  CONSTRAINT [FK_OtherAsset_Employee_EmployeeBadgeNo] FOREIGN KEY([EmployeeBadgeNo])
REFERENCES [dbo].[Employee] ([BadgeNo])
GO
ALTER TABLE [dbo].[OtherAsset] CHECK CONSTRAINT [FK_OtherAsset_Employee_EmployeeBadgeNo]
GO
ALTER TABLE [dbo].[Pager]  WITH CHECK ADD  CONSTRAINT [FK_Pager_Employee_EmployeeBadgeNo] FOREIGN KEY([EmployeeBadgeNo])
REFERENCES [dbo].[Employee] ([BadgeNo])
GO
ALTER TABLE [dbo].[Pager] CHECK CONSTRAINT [FK_Pager_Employee_EmployeeBadgeNo]
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
