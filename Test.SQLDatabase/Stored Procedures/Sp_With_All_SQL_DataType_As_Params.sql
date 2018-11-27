
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_With_All_SQL_DataType_As_Params]
		(
		@big_int BiGINT,
		@int	int,
		@small_int smallint,
		@tiny_int tinyint,
		@bit bit,
		@decimal decimal(18,2),
		@numeric numeric,
		@money money,
		@small_money smallmoney,
		@float float(4),
		@real real,
		@date_time datetime,
		@small_date_time smalldatetime,
		@char char,
		@varchar varchar(100),
		@text text,
		@nchar nchar(4),
		@nvarchar nvarchar(4),
		@ntext ntext,
		@binary binary(5000),
		@varbinary varbinary(4000),
		@image image,
		@timestamp timestamp,
		@uniqueidentifier uniqueidentifier
		)		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			
END



