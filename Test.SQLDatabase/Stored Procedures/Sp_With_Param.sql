
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_With_Param]
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

	IF EXISTS(SELECT TOP 1 1 FROM dbo.[SimpleModel] Where Id=@Id)
	BEGIN
		UPDATE SM 
		SET SM.[Name]=@Name,
			SM.[UpdatedDate]=@UpdatedDate ,
			SM.[Key]=NEWID()
		FROM dbo.[SimpleModel] SM
		WHERE SM.Id=@Id
	END
	ELSE
	BEGIN 
		INSERT INTO [dbo].[SimpleModel] ([Name],[Key],[SimpleModelCode],[UpdatedDate],[RefreshTime])
		   VALUES(@Name,NEWID(),@Name,@UpdatedDate,3000000000)
	END
END



