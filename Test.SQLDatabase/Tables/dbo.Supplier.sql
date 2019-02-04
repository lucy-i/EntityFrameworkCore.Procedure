CREATE TABLE [dbo].[Supplier] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName]  NVARCHAR (40) NOT NULL,
    [ContactName]  NVARCHAR (50) NULL,
    [ContactTitle] NVARCHAR (40) NULL,
    [City]         NVARCHAR (40) NULL,
    [Country]      NVARCHAR (40) NULL,
    [Phone]        NVARCHAR (30) NULL,
    [Fax]          NVARCHAR (30) NULL,
    CONSTRAINT [PK_SUPPLIER] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IndexSupplierCountry]
    ON [dbo].[Supplier]([Country] ASC);


GO
CREATE NONCLUSTERED INDEX [IndexSupplierName]
    ON [dbo].[Supplier]([CompanyName] ASC);

