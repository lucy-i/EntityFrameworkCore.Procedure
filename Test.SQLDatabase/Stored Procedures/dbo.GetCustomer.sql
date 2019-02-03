CREATE PROCEDURE [dbo].[GetCustomer]
AS
BEGIN
	SELECT C.[Id]
		  ,C.[FirstName]
		  ,C.[LastName]
		  ,C.[City]
		  ,C.[Country]
		  ,C.[Phone]
	  FROM [dbo].[Customer] C (NOLOCK)
END