
Create Procedure [dbo].[uspGetCompanyDetails]
@EmployeeID INTEGER

AS
BEGIN
SELECT * FROM Company_Details WHERE EmployeeID=@EmployeeID
END
GO


