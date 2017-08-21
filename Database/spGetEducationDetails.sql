
CREATE PROCEDURE [dbo].[uspGetEducationDetails]
@EmployeeID INTEGER

AS
BEGIN
Select * FROM Education_Details WHERE EmployeeID=@EmployeeID
End
GO


