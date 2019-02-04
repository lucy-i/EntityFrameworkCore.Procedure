CREATE PROCEDURE [dbo].[GetProducts]	
AS
BEGIN
	SELECT [Id]
		  ,[ProductName]
		  ,[SupplierId]
		  ,[UnitPrice]
		  ,[Package]
		  ,[IsDiscontinued]
	  FROM [dbo].[Product]
END