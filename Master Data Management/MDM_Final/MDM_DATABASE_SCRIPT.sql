USE [master]
GO

/****** Object:  Database [MasterDataManagement]    Script Date: 03/05/2014 16:02:01 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'MasterDataManagement')
DROP DATABASE [MasterDataManagement]
GO

USE [master]
GO

/****** Object:  Database [MasterDataManagement]    Script Date: 03/05/2014 16:02:01 ******/
CREATE DATABASE [MasterDataManagement] ON  PRIMARY 
( NAME = N'MasterDataManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\MasterDataManagement.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MasterDataManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\MasterDataManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [MasterDataManagement] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MasterDataManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MasterDataManagement] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MasterDataManagement] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MasterDataManagement] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MasterDataManagement] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MasterDataManagement] SET ARITHABORT OFF 
GO

ALTER DATABASE [MasterDataManagement] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MasterDataManagement] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [MasterDataManagement] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MasterDataManagement] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MasterDataManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MasterDataManagement] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MasterDataManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MasterDataManagement] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MasterDataManagement] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MasterDataManagement] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MasterDataManagement] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MasterDataManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MasterDataManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MasterDataManagement] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MasterDataManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MasterDataManagement] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MasterDataManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MasterDataManagement] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MasterDataManagement] SET  READ_WRITE 
GO

ALTER DATABASE [MasterDataManagement] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [MasterDataManagement] SET  MULTI_USER 
GO

ALTER DATABASE [MasterDataManagement] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MasterDataManagement] SET DB_CHAINING OFF 
GO
USE [MasterDataManagement]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/05/2014 12:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[LoginId] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[DateOfJoining] [datetime] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[IsDeleted] [nvarchar](10) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([UserId], [LoginId], [Password], [Name], [DateOfBirth], [DateOfJoining], [Role], [IsDeleted]) VALUES (1, N'Admin2', N'admin', N'Administrator', CAST(0x0000828E00000000 AS DateTime), CAST(0x0000884300000000 AS DateTime), N'AdminUser', N'false')
INSERT [dbo].[User] ([UserId], [LoginId], [Password], [Name], [DateOfBirth], [DateOfJoining], [Role], [IsDeleted]) VALUES (2, N'User22', N'123', N'BusinessUser', CAST(0x0000A2AB00000000 AS DateTime), CAST(0x0000A2FA00000000 AS DateTime), N'BusinessUser', N'false')
INSERT [dbo].[User] ([UserId], [LoginId], [Password], [Name], [DateOfBirth], [DateOfJoining], [Role], [IsDeleted]) VALUES (3, N'BusinessUser', N'user', N'User', CAST(0x0000A26C00000000 AS DateTime), CAST(0x0000A2ED00000000 AS DateTime), N'BusinessUser', N'false')
INSERT [dbo].[User] ([UserId], [LoginId], [Password], [Name], [DateOfBirth], [DateOfJoining], [Role], [IsDeleted]) VALUES (4, N'User', N'123', N'Business', CAST(0x0000A25000000000 AS DateTime), CAST(0x0000A2E400000000 AS DateTime), N'BusinessUser', N'false')
INSERT [dbo].[User] ([UserId], [LoginId], [Password], [Name], [DateOfBirth], [DateOfJoining], [Role], [IsDeleted]) VALUES (5, N'Business', N'user', N'User', CAST(0x0000A2A700000000 AS DateTime), CAST(0x0000A2E300000000 AS DateTime), N'BusinessUser', N'false')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[SourceSystem]    Script Date: 03/05/2014 12:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceSystem](
	[SystemId] [int] IDENTITY(1,1) NOT NULL,
	[SystemName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_SourceSystem] PRIMARY KEY CLUSTERED 
(
	[SystemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SourceSystem] ON
INSERT [dbo].[SourceSystem] ([SystemId], [SystemName]) VALUES (1, N'Trading')
INSERT [dbo].[SourceSystem] ([SystemId], [SystemName]) VALUES (2, N'Reporting')
INSERT [dbo].[SourceSystem] ([SystemId], [SystemName]) VALUES (3, N'RM')
SET IDENTITY_INSERT [dbo].[SourceSystem] OFF
/****** Object:  Table [dbo].[Location]    Script Date: 03/05/2014 12:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[LastUpdatedBy] [int] NOT NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Location] ON
INSERT [dbo].[Location] ([LocationId], [LocationName], [Description], [LastUpdatedBy], [LastUpdatedDate]) VALUES (1, N'Australia', N'Australia', 1, CAST(0x0000A2E301013AE5 AS DateTime))
INSERT [dbo].[Location] ([LocationId], [LocationName], [Description], [LastUpdatedBy], [LastUpdatedDate]) VALUES (2, N'India', N'India', 1, CAST(0x0000A2E301015ABB AS DateTime))
INSERT [dbo].[Location] ([LocationId], [LocationName], [Description], [LastUpdatedBy], [LastUpdatedDate]) VALUES (3, N'New York', N'United States', 1, CAST(0x0000A2E3010F4DAF AS DateTime))
SET IDENTITY_INSERT [dbo].[Location] OFF
/****** Object:  Table [dbo].[Currency]    Script Date: 03/05/2014 12:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[CurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[LastUpdatedBy] [int] NOT NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Currency] ON
INSERT [dbo].[Currency] ([CurrencyId], [CurrencyName], [Description], [LastUpdatedBy], [LastUpdatedDate]) VALUES (1, N'Dollar', N'Dollar', 1, CAST(0x0000A2E3010149A7 AS DateTime))
INSERT [dbo].[Currency] ([CurrencyId], [CurrencyName], [Description], [LastUpdatedBy], [LastUpdatedDate]) VALUES (2, N'Rupee', N'Rupee', 1, CAST(0x0000A2E301015256 AS DateTime))
INSERT [dbo].[Currency] ([CurrencyId], [CurrencyName], [Description], [LastUpdatedBy], [LastUpdatedDate]) VALUES (3, N'Hong Kong Dollar', N'Hk Dollar', 1, CAST(0x0000A2E3010F6283 AS DateTime))
SET IDENTITY_INSERT [dbo].[Currency] OFF
/****** Object:  Table [dbo].[CommodityType]    Script Date: 03/05/2014 12:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommodityType](
	[CommodityTypeId] [int] IDENTITY(1,1) NOT NULL,
	[CommodityTypeName] [nvarchar](100) NOT NULL,
	[CommodityClass] [nvarchar](100) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Version] [int] NOT NULL,
	[LastUpdatedBy] [int] NOT NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsCurrentVersion] [bit] NOT NULL,
 CONSTRAINT [PK_CommodityType] PRIMARY KEY CLUSTERED 
(
	[CommodityTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CommodityType] ON
INSERT [dbo].[CommodityType] ([CommodityTypeId], [CommodityTypeName], [CommodityClass], [StartDate], [EndDate], [Version], [LastUpdatedBy], [LastUpdatedDate], [IsCurrentVersion]) VALUES (1, N'Gold', N'Metal', CAST(0x0000A2E301008002 AS DateTime), CAST(0x0000A2E700000000 AS DateTime), 1, 2, CAST(0x0000A2E301009558 AS DateTime), 1)
INSERT [dbo].[CommodityType] ([CommodityTypeId], [CommodityTypeName], [CommodityClass], [StartDate], [EndDate], [Version], [LastUpdatedBy], [LastUpdatedDate], [IsCurrentVersion]) VALUES (2, N'Silver', N'Metal', CAST(0x0000A2E301009A7C AS DateTime), CAST(0x0000A2E800000000 AS DateTime), 1, 2, CAST(0x0000A2E30100A5F7 AS DateTime), 1)
INSERT [dbo].[CommodityType] ([CommodityTypeId], [CommodityTypeName], [CommodityClass], [StartDate], [EndDate], [Version], [LastUpdatedBy], [LastUpdatedDate], [IsCurrentVersion]) VALUES (3, N'Gas', N'Fuel', CAST(0x0000A2E3010F86AA AS DateTime), CAST(0x0000A2E400000000 AS DateTime), 1, 5, CAST(0x0000A2E3010F9B39 AS DateTime), 1)
INSERT [dbo].[CommodityType] ([CommodityTypeId], [CommodityTypeName], [CommodityClass], [StartDate], [EndDate], [Version], [LastUpdatedBy], [LastUpdatedDate], [IsCurrentVersion]) VALUES (4, N'Oil', N'Fuel', CAST(0x0000A2E3010FA062 AS DateTime), CAST(0x0000A2E500000000 AS DateTime), 1, 5, CAST(0x0000A2E3010FA89D AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[CommodityType] OFF
/****** Object:  Table [dbo].[BusinessMapping]    Script Date: 03/05/2014 12:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BusinessMapping](
	[EntityType] [char](10) NOT NULL,
	[EntityId] [int] NOT NULL,
	[MappingID] [int] IDENTITY(1,1) NOT NULL,
	[MappingString] [nvarchar](100) NOT NULL,
	[MappingDescription] [nvarchar](max) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[SourceSystemID] [int] NOT NULL,
	[IsEnabledFlag] [bit] NOT NULL,
	[IsDefaultMapping] [bit] NULL,
	[LastUpdatedBy] [int] NOT NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Business_] PRIMARY KEY CLUSTERED 
(
	[MappingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BusinessMapping] ON
INSERT [dbo].[BusinessMapping] ([EntityType], [EntityId], [MappingID], [MappingString], [MappingDescription], [StartDate], [EndDate], [SourceSystemID], [IsEnabledFlag], [IsDefaultMapping], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'Market    ', 1, 1, N'NEWYORK', N'nyse', CAST(0x0000A2E3010656FC AS DateTime), CAST(0x0000A2F300000000 AS DateTime), 2, 0, 0, 3, NULL)
INSERT [dbo].[BusinessMapping] ([EntityType], [EntityId], [MappingID], [MappingString], [MappingDescription], [StartDate], [EndDate], [SourceSystemID], [IsEnabledFlag], [IsDefaultMapping], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'Market    ', 1, 2, N'NEWYORKSTOCKEXCHANGE', N'New York', CAST(0x0000A2E301106214 AS DateTime), CAST(0x0000A2E500000000 AS DateTime), 1, 0, 0, 5, NULL)
INSERT [dbo].[BusinessMapping] ([EntityType], [EntityId], [MappingID], [MappingString], [MappingDescription], [StartDate], [EndDate], [SourceSystemID], [IsEnabledFlag], [IsDefaultMapping], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'Market    ', 1, 3, N'NYState', NULL, CAST(0x0000A2E30110D168 AS DateTime), CAST(0x0000A2EC00000000 AS DateTime), 2, 0, 0, 5, NULL)
INSERT [dbo].[BusinessMapping] ([EntityType], [EntityId], [MappingID], [MappingString], [MappingDescription], [StartDate], [EndDate], [SourceSystemID], [IsEnabledFlag], [IsDefaultMapping], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'Market    ', 1, 4, N'NewYorkSE', NULL, CAST(0x0000A2E30110F364 AS DateTime), CAST(0x0000A2E400000000 AS DateTime), 3, 0, 1, 5, NULL)
SET IDENTITY_INSERT [dbo].[BusinessMapping] OFF
/****** Object:  Table [dbo].[Market]    Script Date: 03/05/2014 12:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Market](
	[MarketId] [int] IDENTITY(1,1) NOT NULL,
	[MarketName] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Version] [int] NOT NULL,
	[LastUpdatedBy] [int] NOT NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsCurrentVersion] [bit] NOT NULL,
	[LocationId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
 CONSTRAINT [PK_Market] PRIMARY KEY CLUSTERED 
(
	[MarketId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Market] ON
INSERT [dbo].[Market] ([MarketId], [MarketName], [StartDate], [EndDate], [Version], [LastUpdatedBy], [LastUpdatedDate], [IsCurrentVersion], [LocationId], [CurrencyId]) VALUES (1, N'NYSE', CAST(0x0000A2E301115CF8 AS DateTime), CAST(0x0000A2F200000000 AS DateTime), 2, 5, CAST(0x0000A2E301116804 AS DateTime), 1, 1, 2)
INSERT [dbo].[Market] ([MarketId], [MarketName], [StartDate], [EndDate], [Version], [LastUpdatedBy], [LastUpdatedDate], [IsCurrentVersion], [LocationId], [CurrencyId]) VALUES (2, N'FTSE', CAST(0x0000A2E301070B73 AS DateTime), CAST(0x0000A2E400000000 AS DateTime), 0, 4, CAST(0x0000A2E301072419 AS DateTime), 1, 1, 1)
INSERT [dbo].[Market] ([MarketId], [MarketName], [StartDate], [EndDate], [Version], [LastUpdatedBy], [LastUpdatedDate], [IsCurrentVersion], [LocationId], [CurrencyId]) VALUES (3, N'CME', CAST(0x0000A2E3010FAEF6 AS DateTime), CAST(0x0000A2E700000000 AS DateTime), 0, 5, CAST(0x0000A2E3010FD040 AS DateTime), 1, 3, 1)
SET IDENTITY_INSERT [dbo].[Market] OFF
/****** Object:  Table [dbo].[MarketCommodityMap]    Script Date: 03/05/2014 12:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarketCommodityMap](
	[MarketCommodityMapId] [int] IDENTITY(1,1) NOT NULL,
	[MarketId] [int] NOT NULL,
	[CommodityTypeId] [int] NOT NULL,
 CONSTRAINT [PK_MarketCommodityRelationship] PRIMARY KEY CLUSTERED 
(
	[MarketCommodityMapId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MarketCommodityMap] ON
INSERT [dbo].[MarketCommodityMap] ([MarketCommodityMapId], [MarketId], [CommodityTypeId]) VALUES (7, 2, 1)
INSERT [dbo].[MarketCommodityMap] ([MarketCommodityMapId], [MarketId], [CommodityTypeId]) VALUES (8, 3, 3)
INSERT [dbo].[MarketCommodityMap] ([MarketCommodityMapId], [MarketId], [CommodityTypeId]) VALUES (9, 3, 2)
INSERT [dbo].[MarketCommodityMap] ([MarketCommodityMapId], [MarketId], [CommodityTypeId]) VALUES (10, 1, 1)
INSERT [dbo].[MarketCommodityMap] ([MarketCommodityMapId], [MarketId], [CommodityTypeId]) VALUES (11, 1, 2)
SET IDENTITY_INSERT [dbo].[MarketCommodityMap] OFF
/****** Object:  Default [DF_BusinessMapping_LastUpdatedDate]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[BusinessMapping] ADD  CONSTRAINT [DF_BusinessMapping_LastUpdatedDate]  DEFAULT (getdate()) FOR [LastUpdatedDate]
GO
/****** Object:  Default [DF_CommodityType_StartDate]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[CommodityType] ADD  CONSTRAINT [DF_CommodityType_StartDate]  DEFAULT (((1)-(1))-(2004)) FOR [StartDate]
GO
/****** Object:  Default [DF_CommodityType_LastUpdatedDate]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[CommodityType] ADD  CONSTRAINT [DF_CommodityType_LastUpdatedDate]  DEFAULT (getdate()) FOR [LastUpdatedDate]
GO
/****** Object:  Default [DF_Currency_LastUpdatedDate]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[Currency] ADD  CONSTRAINT [DF_Currency_LastUpdatedDate]  DEFAULT (getdate()) FOR [LastUpdatedDate]
GO
/****** Object:  Default [DF_Location_LastUpdatedDate]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_LastUpdatedDate]  DEFAULT (getdate()) FOR [LastUpdatedDate]
GO
/****** Object:  Default [DF_Market_StartDate]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[Market] ADD  CONSTRAINT [DF_Market_StartDate]  DEFAULT (((1)-(1))-(2004)) FOR [StartDate]
GO
/****** Object:  Default [DF_Market_LastUpdatedDate]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[Market] ADD  CONSTRAINT [DF_Market_LastUpdatedDate]  DEFAULT (getdate()) FOR [LastUpdatedDate]
GO
/****** Object:  ForeignKey [FK_Business_SourceSystem]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[BusinessMapping]  WITH CHECK ADD  CONSTRAINT [FK_Business_SourceSystem] FOREIGN KEY([SourceSystemID])
REFERENCES [dbo].[SourceSystem] ([SystemId])
GO
ALTER TABLE [dbo].[BusinessMapping] CHECK CONSTRAINT [FK_Business_SourceSystem]
GO
/****** Object:  ForeignKey [FK_Business_User]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[BusinessMapping]  WITH CHECK ADD  CONSTRAINT [FK_Business_User] FOREIGN KEY([LastUpdatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[BusinessMapping] CHECK CONSTRAINT [FK_Business_User]
GO
/****** Object:  ForeignKey [FK_CommodityType_User]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[CommodityType]  WITH CHECK ADD  CONSTRAINT [FK_CommodityType_User] FOREIGN KEY([LastUpdatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[CommodityType] CHECK CONSTRAINT [FK_CommodityType_User]
GO
/****** Object:  ForeignKey [FK_Currency_User]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[Currency]  WITH CHECK ADD  CONSTRAINT [FK_Currency_User] FOREIGN KEY([LastUpdatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Currency] CHECK CONSTRAINT [FK_Currency_User]
GO
/****** Object:  ForeignKey [FK_Location_User]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_User] FOREIGN KEY([LastUpdatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_User]
GO
/****** Object:  ForeignKey [FK_Market_Currency]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[Market]  WITH CHECK ADD  CONSTRAINT [FK_Market_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
GO
ALTER TABLE [dbo].[Market] CHECK CONSTRAINT [FK_Market_Currency]
GO
/****** Object:  ForeignKey [FK_Market_Location]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[Market]  WITH CHECK ADD  CONSTRAINT [FK_Market_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO
ALTER TABLE [dbo].[Market] CHECK CONSTRAINT [FK_Market_Location]
GO
/****** Object:  ForeignKey [FK_Market_User]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[Market]  WITH CHECK ADD  CONSTRAINT [FK_Market_User] FOREIGN KEY([LastUpdatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Market] CHECK CONSTRAINT [FK_Market_User]
GO
/****** Object:  ForeignKey [FK_MarketCommodityMap_CommodityType]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[MarketCommodityMap]  WITH CHECK ADD  CONSTRAINT [FK_MarketCommodityMap_CommodityType] FOREIGN KEY([CommodityTypeId])
REFERENCES [dbo].[CommodityType] ([CommodityTypeId])
GO
ALTER TABLE [dbo].[MarketCommodityMap] CHECK CONSTRAINT [FK_MarketCommodityMap_CommodityType]
GO
/****** Object:  ForeignKey [FK_MarketCommodityMap_Market]    Script Date: 03/05/2014 12:43:49 ******/
ALTER TABLE [dbo].[MarketCommodityMap]  WITH CHECK ADD  CONSTRAINT [FK_MarketCommodityMap_Market] FOREIGN KEY([MarketId])
REFERENCES [dbo].[Market] ([MarketId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MarketCommodityMap] CHECK CONSTRAINT [FK_MarketCommodityMap_Market]
GO


