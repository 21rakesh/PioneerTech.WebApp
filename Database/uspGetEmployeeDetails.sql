
CREATE Procedure [dbo].[uspGetEmployeeDetails]
@EmployeeID Integer

As
Begin
Select * FROM Employee_Details WHERE EmployeeID=@EmployeeID
End
GO


