USE [SupplyOfProducts]

GO

/****** Object:  Table [dbo].[ConfigSupply]    Script Date: 01/05/2019 1:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigSupply](
	[Id] [int] NOT NULL Identity(1, 1),
	[Date] [datetime] NOT NULL,
	[PeriodDate] [datetime] NOT NULL,
	[IdWorkerInWorkPlace] [int] NOT NULL,
	[IdProduct] [int] NOT NULL,
	[Amount] [tinyint] NOT NULL,
	[IdSupplyScheduled] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 01/05/2019 1:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL Identity(1, 1),
	[Type] [nvarchar](10) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[IdParentProduct] [int] NULL,
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
/****** Object:  Table [dbo].[SupplyScheduled]    Script Date: 01/05/2019 1:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplyScheduled](
	[Id] [int] NOT NULL Identity(1, 1),
	[Date] [datetime] NOT NULL ,
	[PeriodDate] [datetime] NOT NULL,
	[IdWorkerInWorkPlace] [int] NOT NULL,
	[IdProduct] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_SupplyScheduled] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Worker]    Script Date: 01/05/2019 1:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[Id] [int] NOT NULL Identity(1, 1),
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
/****** Object:  Table [dbo].[WorkerInWorkPlace]    Script Date: 01/05/2019 1:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerInWorkPlace](
	[Id] [int] NOT NULL Identity(1, 1),
	[IdWorker] [int] NOT NULL,
	[IdWorkPlace] [int] NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[NumYearsByPeriod] [tinyint] NOT NULL,
	[DateEnd] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkPlace]    Script Date: 01/05/2019 1:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkPlace](
	[Id] [int] NOT NULL Identity(1, 1),
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
/****** Object:  Table [dbo].[ProductSupplied]    Script Date: 01/05/2019 1:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSupplied](
	[Id] [int] NOT NULL Identity(1, 1),
	[IdProductSupply] [int] NOT NULL,
	[IdProductStock] [int] NOT NULL,
	[IdParentProductSupplied] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSupply]    Script Date: 01/05/2019 1:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSupply](
	[Id] [int] NOT NULL Identity(1, 1),
	[IdWorkerInWorkPlace] [int] NOT NULL,
	[IdProduct] [int] NOT NULL,
	[IdProductSupplied] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[PerioDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductStock]    Script Date: 01/05/2019 1:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStock](
	[Id] [int] NOT NULL Identity(1, 1),
	[IdProduct] [int] NOT NULL,
	[PartNumber] [nvarchar](50) NOT NULL,
	[IdBooking] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [CK_WorkPlace_Column] UNIQUE NONCLUSTERED 
(
	[PartNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ConfigSupply]  WITH CHECK ADD  CONSTRAINT [FK_ConfigSupply_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ConfigSupply] CHECK CONSTRAINT [FK_ConfigSupply_Product]
GO
ALTER TABLE [dbo].[ConfigSupply]  WITH CHECK ADD  CONSTRAINT [FK_ConfigSupply_SupplyScheduled] FOREIGN KEY([IdSupplyScheduled])
REFERENCES [dbo].[SupplyScheduled] ([Id])
GO
ALTER TABLE [dbo].[ConfigSupply] CHECK CONSTRAINT [FK_ConfigSupply_SupplyScheduled]
GO
ALTER TABLE [dbo].[ConfigSupply]  WITH CHECK ADD  CONSTRAINT [FK_ConfigSupply_WorkerInWorkPlace] FOREIGN KEY([IdWorkerInWorkPlace])
REFERENCES [dbo].[WorkerInWorkPlace] ([Id])
GO
ALTER TABLE [dbo].[ConfigSupply] CHECK CONSTRAINT [FK_ConfigSupply_WorkerInWorkPlace]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Product] FOREIGN KEY([IdParentProduct])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Product]
GO
ALTER TABLE [dbo].[SupplyScheduled]  WITH CHECK ADD  CONSTRAINT [FK_SupplyScheduled_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SupplyScheduled] CHECK CONSTRAINT [FK_SupplyScheduled_Product]
GO
ALTER TABLE [dbo].[SupplyScheduled]  WITH CHECK ADD  CONSTRAINT [FK_SupplyScheduled_WorkerInWorkPlace] FOREIGN KEY([IdWorkerInWorkPlace])
REFERENCES [dbo].[WorkerInWorkPlace] ([Id])
GO
ALTER TABLE [dbo].[SupplyScheduled] CHECK CONSTRAINT [FK_SupplyScheduled_WorkerInWorkPlace]
GO
ALTER TABLE [dbo].[WorkerInWorkPlace]  WITH CHECK ADD  CONSTRAINT [FK_WorkerInWorkPlace_Worker] FOREIGN KEY([IdWorker])
REFERENCES [dbo].[Worker] ([Id])
GO
ALTER TABLE [dbo].[WorkerInWorkPlace] CHECK CONSTRAINT [FK_WorkerInWorkPlace_Worker]
GO
ALTER TABLE [dbo].[WorkerInWorkPlace]  WITH CHECK ADD  CONSTRAINT [FK_WorkerInWorkPlace_WorkPlace] FOREIGN KEY([IdWorkPlace])
REFERENCES [dbo].[WorkPlace] ([Id])
GO
ALTER TABLE [dbo].[WorkerInWorkPlace] CHECK CONSTRAINT [FK_WorkerInWorkPlace_WorkPlace]
GO
ALTER TABLE [dbo].[ProductSupplied]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupplied_ProductStock] FOREIGN KEY([IdProductStock])
REFERENCES [dbo].[ProductStock] ([Id])
GO
ALTER TABLE [dbo].[ProductSupplied] CHECK CONSTRAINT [FK_ProductSupplied_ProductStock]
GO
ALTER TABLE [dbo].[ProductSupplied]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupplied_ProductSupplied] FOREIGN KEY([IdParentProductSupplied])
REFERENCES [dbo].[ProductSupplied] ([Id])
GO
ALTER TABLE [dbo].[ProductSupplied] CHECK CONSTRAINT [FK_ProductSupplied_ProductSupplied]
GO
ALTER TABLE [dbo].[ProductSupplied]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupplied_ProductSupply] FOREIGN KEY([IdProductSupply])
REFERENCES [dbo].[ProductSupply] ([Id])
GO
ALTER TABLE [dbo].[ProductSupplied] CHECK CONSTRAINT [FK_ProductSupplied_ProductSupply]
GO
ALTER TABLE [dbo].[ProductSupply]  WITH CHECK ADD  CONSTRAINT [FK_ProductSupply_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductSupply] CHECK CONSTRAINT [FK_ProductSupply_Product]
GO
ALTER TABLE [dbo].[ProductStock]  WITH CHECK ADD  CONSTRAINT [FK_ProductStock_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductStock] CHECK CONSTRAINT [FK_ProductStock_Product]
GO
