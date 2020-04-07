CREATE TABLE [dbo].[Product] (
    [ProductID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [Color]     NVARCHAR (15) NULL,
    [Size]      NVARCHAR (5)  NULL,
    [Price]     MONEY         NOT NULL,
    [Quantity]  INT           NULL,
    [ValidFrom] DATETIME2 (0) NOT NULL,
    [ValidTo]   DATETIME2 (0) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

