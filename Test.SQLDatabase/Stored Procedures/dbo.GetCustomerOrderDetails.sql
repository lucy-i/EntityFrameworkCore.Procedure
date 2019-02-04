/****** Object:  StoredProcedure [dbo].[GetCustomerOrderDetails]    Script Date: 02-02-2019 AM 11:21:19 ******/
--GO;
--IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetCustomerOrderDetails')
--BEGIN
--DROP PROCEDURE [dbo].[GetCustomerOrderDetails]
--END
--GO
CREATE PROCEDURE [dbo].[GetCustomerOrderDetails]
AS 
BEGIN
	SELECT 
		C.Id,
		C.FirstName,
		C.LastName,
		COUNT(1) [No of Orders] 
	FROM Customer C 
	JOIN [Order] O ON O.CustomerId=C.Id 
	GROUP BY C.Id,C.FirstName,c.LastName
END
GO


