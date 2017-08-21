
Create Procedure [dbo].[uspGetTechnicalDetails]
@EmployeeID Integer

AS
BEGIN
Select * From Technical_Details WHERE EmployeeID=@EmployeeID
END
GO


