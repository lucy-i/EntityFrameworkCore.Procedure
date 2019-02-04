CREATE TABLE [dbo].[OrderItem] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT             NOT NULL,
    [ProductId] INT             NOT NULL,
    [UnitPrice] DECIMAL (12, 2) DEFAULT ((0)) NOT NULL,
    [Quantity]  INT             DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ORDERITEM] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ORDERITE_REFERENCE_ORDER] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_ORDERITE_REFERENCE_PRODUCT] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IndexOrderItemProductId]
    ON [dbo].[OrderItem]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IndexOrderItemOrderId]
    ON [dbo].[OrderItem]([OrderId] ASC);

