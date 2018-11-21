
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_SimpleResult_Without_Param]
				
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		SELECT [Id]
			  ,[Name]
			  ,[Key]
			  ,[SimpleModelCode]
			  ,[UpdatedDate]
			  ,[RefreshTime]
		  FROM [dbo].[SimpleModel]
			
END



