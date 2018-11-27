
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_With_Param_AnReturnList]
	(
	@Id INT,
	@Name Varchar(70),
	@UpdatedDate DateTime
	)			
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select @Id Id, @Name [Name],@UpdatedDate [Date]
END



