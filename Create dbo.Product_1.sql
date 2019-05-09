USE [SupplyOfProducts]
GO

/****** Objeto: Table [dbo].[SupplyScheduled] Fecha del script: 27/04/2019 13:47:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE conf.[SupplyScheduled] (
    [Id]                  INT      NOT NULL,
    [Date]                DATETIME NOT NULL,
    [PeriodDate]          DATETIME NOT NULL,
    [IdWorkerInWorkPlace] INT      NOT NULL,
    [IdProduct]           INT      NOT NULL,
    [Amount]              INT      NOT NULL
);





