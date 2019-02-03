CREATE TABLE [dbo].[Order] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [OrderDate]   DATETIME        DEFAULT (getdate()) NOT NULL,
    [OrderNumber] NVARCHAR (10)   NULL,
    [CustomerId]  INT             NOT NULL,
    [TotalAmount] DECIMAL (12, 2) DEFAULT ((0)) NULL,
    CONSTRAINT [PK_ORDER] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ORDER_REFERENCE_CUSTOMER] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IndexOrderOrderDate]
    ON [dbo].[Order]([OrderDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IndexOrderCustomerId]
    ON [dbo].[Order]([CustomerId] ASC);

