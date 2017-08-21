
Create Procedure [dbo].[uspGetProjectDetails]
@EmployeeID Integer

AS
BEGIN
SELECT * FROM Project_Details
WHERE EmployeeID=@EmployeeID
END
GO


