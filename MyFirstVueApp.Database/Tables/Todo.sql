
CREATE TABLE [dbo].[Todo]
(
    [TodoId]         INT IDENTITY (1, 1)                NOT NULL,
    [Text]          VARCHAR(200)                        NOT NULL,
    [Enabled]                 BIT            DEFAULT ((1))       NOT NULL,
    [CreatedAt]            DATETIME2(7)   DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]            DATETIME2(7)                       NULL,
    [Hide]                 BIT            DEFAULT ((0))       NOT NULL,

    PRIMARY KEY CLUSTERED ([TodoId] ASC)
    );
GO
