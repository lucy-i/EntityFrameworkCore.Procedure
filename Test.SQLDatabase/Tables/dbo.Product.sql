CREATE TABLE [dbo].[Product] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [ProductName]    NVARCHAR (50)   NOT NULL,
    [SupplierId]     INT             NOT NULL,
    [UnitPrice]      DECIMAL (12, 2) DEFAULT ((0)) NULL,
    [Package]        NVARCHAR (30)   NULL,
    [IsDiscontinued] BIT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PRODUCT_REFERENCE_SUPPLIER] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IndexProductName]
    ON [dbo].[Product]([ProductName] ASC);


GO
CREATE NONCLUSTERED INDEX [IndexProductSupplierId]
    ON [dbo].[Product]([SupplierId] ASC);

