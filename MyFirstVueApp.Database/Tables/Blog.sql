CREATE TABLE [dbo].[Blog]
(
    [BlogId]                INT IDENTITY (1, 1)                NOT NULL,
    [Description]          VARCHAR(500)                       NOT NULL,
    [Url]          VARCHAR(500)                       NOT NULL,
    [CreatedAt]            DATETIME2(7)   DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]            DATETIME2(7)                       NULL,
    [Hide]                 BIT            DEFAULT ((0))       NOT NULL,

    PRIMARY KEY CLUSTERED ([BlogId] ASC),
);
GO