CREATE TABLE [dbo].[Customer] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (40) NOT NULL,
    [LastName]  NVARCHAR (40) NOT NULL,
    [City]      NVARCHAR (40) NULL,
    [Country]   NVARCHAR (40) NULL,
    [Phone]     NVARCHAR (20) NULL,
    CONSTRAINT [PK_CUSTOMER] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IndexCustomerName]
    ON [dbo].[Customer]([LastName] ASC, [FirstName] ASC);

