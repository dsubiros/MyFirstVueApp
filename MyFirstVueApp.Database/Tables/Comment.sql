CREATE TABLE [dbo].[Comment]
(
    [CommentId]                INT IDENTITY (1, 1)                NOT NULL,
    [Title]          VARCHAR(100)                       NOT NULL,
    [Text]          VARCHAR(500)                       NOT NULL,
    [CreatedAt]            DATETIME2(7)   DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]            DATETIME2(7)                       NULL,
    [Hide]                 BIT            DEFAULT ((0))       NOT NULL,

    [PostId]    INT                                NOT NULL,

    PRIMARY KEY CLUSTERED ([CommentId] ASC),
    CONSTRAINT [FK_Comment_To_Post] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Post] ([PostId]),
);
GO
