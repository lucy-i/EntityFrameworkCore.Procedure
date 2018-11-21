CREATE TABLE [dbo].[SimpleModel] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (70)   NOT NULL,
    [Key]             NVARCHAR (255) NULL,
    [SimpleModelCode] VARCHAR (50)   NOT NULL,
    [UpdatedDate]     DATETIME       NOT NULL,
    [RefreshTime]     BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

