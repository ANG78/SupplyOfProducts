USE [master]
GO
/****** Object:  Database [SupplyOfProducts]    Script Date: 13/05/2019 0:35:50 ******/
CREATE DATABASE [SupplyOfProducts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SupplyOfProducts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SupplyOfProducts.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SupplyOfProducts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SupplyOfProducts_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SupplyOfProducts] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SupplyOfProducts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SupplyOfProducts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET ARITHABORT OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SupplyOfProducts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SupplyOfProducts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SupplyOfProducts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SupplyOfProducts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SupplyOfProducts] SET  MULTI_USER 
GO
ALTER DATABASE [SupplyOfProducts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SupplyOfProducts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SupplyOfProducts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SupplyOfProducts] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SupplyOfProducts] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SupplyOfProducts]
GO
/****** Object:  Table [dbo].[ConfigSupply]    Script Date: 13/05/2019 0:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigSupply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PeriodDate] [datetime] NOT NULL,
	[WorkerInWorkPlaceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Amount] [tinyint] NOT NULL,
	[SupplyScheduledId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 13/05/2019 0:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](10) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[ParentProductId] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [CK_Product_Column] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductStock]    Script Date: 13/05/2019 0:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[PartNumber] [nvarchar](20) NOT NULL,
	[BookingId] [int] NULL,
 CONSTRAINT [PK_ProductStock] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSupplied]    Script Date: 13/05/2019 0:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSupplied](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductSupplyId] [int] NOT NULL,
	[ProductStockId] [int] NOT NULL,
	[ParentProductSuppliedId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSupply]    Script Date: 13/05/2019 0:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSupply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkerInWorkPlaceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[PeriodDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupplyScheduled]    Script Date: 13/05/2019 0:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplyScheduled](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodDate] [datetime] NOT NULL,
	[WorkerInWorkPlaceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_SupplyScheduled] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Worker]    Script Date: 13/05/2019 0:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [CK_Worker_Column] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkerInWorkPlace]    Script Date: 13/05/2019 0:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerInWorkPlace](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkerId] [int] NOT NULL,
	[WorkPlaceId] [int] NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NULL,
	[NumYearsByPeriod] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkPlace]    Script Date: 13/05/2019 0:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkPlace](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [CK_WorkPlace_Column] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_ProductSupplied]    Script Date: 13/05/2019 0:35:51 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ProductSupplied] ON [dbo].[ProductSupplied]
(
	[ProductStockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ConfigSupply]  WITH CHECK ADD  CONSTRAINT [FK_ConfigSupply_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ConfigSupply] CHECK CONSTRAINT [FK_ConfigSupply_Product]
GO
ALTER TABLE [dbo].[ConfigSupply]  WITH CHECK ADD  CONSTRAINT [FK_ConfigSupply_SupplyScheduled] FOREIGN KEY([SupplyScheduledId])
REFERENCES [dbo].[SupplyScheduled] ([Id])
GO
ALTER TABLE [dbo].[ConfigSupply] CHECK CONSTRAINT [FK_ConfigSupply_SupplyScheduled]
GO
ALTER TABLE [dbo].[ConfigSupply]  WITH CHECK ADD  CONSTRAINT [FK_ConfigSupply_WorkerInWorkPlace] FOREIGN KEY([WorkerInWorkPlaceId])
REFERENCES [dbo].[WorkerInWorkPlace] ([Id])
GO
ALTER TABLE [dbo].[ConfigSupply] CHECK CONSTRAINT [FK_ConfigSupply_WorkerInWorkPlace]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Product] FOREIGN KEY([ParentProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Product]
GO
ALTER TABLE [dbo].[ProductStock]  WITH CHECK ADD  CONSTRAINT [FK_ProductStock_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductStock] CHECK CONSTRAINT [FK_ProductStock_Product]
GO
ALTER TABLE [dbo].[ProductSupplied]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupplied_ProductStock] FOREIGN KEY([ProductStockId])
REFERENCES [dbo].[ProductStock] ([id])
GO
ALTER TABLE [dbo].[ProductSupplied] CHECK CONSTRAINT [FK_ProductSupplied_ProductStock]
GO
ALTER TABLE [dbo].[ProductSupplied]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupplied_ProductSupplied] FOREIGN KEY([ParentProductSuppliedId])
REFERENCES [dbo].[ProductSupplied] ([Id])
GO
ALTER TABLE [dbo].[ProductSupplied] CHECK CONSTRAINT [FK_ProductSupplied_ProductSupplied]
GO
ALTER TABLE [dbo].[ProductSupplied]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupplied_ProductSupply] FOREIGN KEY([ProductSupplyId])
REFERENCES [dbo].[ProductSupply] ([Id])
GO
ALTER TABLE [dbo].[ProductSupplied] CHECK CONSTRAINT [FK_ProductSupplied_ProductSupply]
GO
ALTER TABLE [dbo].[ProductSupply]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupply_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductSupply] CHECK CONSTRAINT [FK_ProductSupply_Product]
GO
ALTER TABLE [dbo].[ProductSupply]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupply_WorkerInWorkPlace] FOREIGN KEY([WorkerInWorkPlaceId])
REFERENCES [dbo].[WorkerInWorkPlace] ([Id])
GO
ALTER TABLE [dbo].[ProductSupply] CHECK CONSTRAINT [FK_ProductSupply_WorkerInWorkPlace]
GO
ALTER TABLE [dbo].[SupplyScheduled]  WITH CHECK ADD  CONSTRAINT [FK_SupplyScheduled_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SupplyScheduled] CHECK CONSTRAINT [FK_SupplyScheduled_Product]
GO
ALTER TABLE [dbo].[SupplyScheduled]  WITH CHECK ADD  CONSTRAINT [FK_SupplyScheduled_WorkerInWorkPlace] FOREIGN KEY([WorkerInWorkPlaceId])
REFERENCES [dbo].[WorkerInWorkPlace] ([Id])
GO
ALTER TABLE [dbo].[SupplyScheduled] CHECK CONSTRAINT [FK_SupplyScheduled_WorkerInWorkPlace]
GO
ALTER TABLE [dbo].[WorkerInWorkPlace]  WITH CHECK ADD  CONSTRAINT [FK_WorkerInWorkPlace_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([Id])
GO
ALTER TABLE [dbo].[WorkerInWorkPlace] CHECK CONSTRAINT [FK_WorkerInWorkPlace_Worker]
GO
ALTER TABLE [dbo].[WorkerInWorkPlace]  WITH CHECK ADD  CONSTRAINT [FK_WorkerInWorkPlace_WorkPlace] FOREIGN KEY([WorkPlaceId])
REFERENCES [dbo].[WorkPlace] ([Id])
GO
ALTER TABLE [dbo].[WorkerInWorkPlace] CHECK CONSTRAINT [FK_WorkerInWorkPlace_WorkPlace]
GO
USE [master]
GO
ALTER DATABASE [SupplyOfProducts] SET  READ_WRITE 
GO
