CREATE TABLE [dbo].[Post]
(
    [PostId]                INT IDENTITY (1, 1)                NOT NULL,
    [Description]          VARCHAR(500)                       NOT NULL,
    [CreatedAt]            DATETIME2(7)   DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]            DATETIME2(7)                       NULL,
    [Hide]                 BIT            DEFAULT ((0))       NOT NULL,

    [BlogId]    INT                                NOT NULL,

    PRIMARY KEY CLUSTERED ([PostId] ASC),
    CONSTRAINT [FK_Post_To_Blog] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([BlogId]),
);
GO
