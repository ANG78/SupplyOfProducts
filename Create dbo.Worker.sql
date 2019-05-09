USE [SupplyOfProducts]
GO

/****** Objeto: Table [dbo].[Worker] Fecha del script: 27/04/2019 13:49:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE conf.[Worker] (
    [Id]   INT           NOT NULL,
    [Code] NVARCHAR (10) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL
);


