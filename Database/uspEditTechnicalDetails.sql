
Create Procedure [dbo].[uspEditTechnicalDetails]
@UI varchar(50),
@Programming_Languages varchar(50),
@ORM_Technologies varchar(50),
@Databases varchar(50),
@EmployeeID Integer

AS
BEGIN
UPDATE Technical_Details
SET UI=@UI,Programming_Languages=@Programming_Languages,ORM_Technologies=@ORM_Technologies,Databases=@Databases
WHERE EmployeeID=@EmployeeID
END
GO


