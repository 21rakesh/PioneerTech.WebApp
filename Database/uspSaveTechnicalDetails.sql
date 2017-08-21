
Create Procedure [dbo].[uspSaveTechnicalDetails]
@UI varchar(50),
@Programming_Languages varchar(50),
@ORM_Technologies varchar(50),
@Databases varchar(50)

AS
BEGIN
INSERT INTO Technical_Details(UI,Programming_Languages,ORM_Technologies,Databases)Values(@UI,@Programming_Languages,@ORM_Technologies,@Databases)
END
GO


