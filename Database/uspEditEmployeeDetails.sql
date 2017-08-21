

CREATE Procedure [dbo].[uspEditEmployeeDetails]
@First_Name varchar(50),
@Last_Name varchar(50),
@Mobile_Number varchar(50),
@AlternateMobileNumber varchar(50),
@Address1 varchar(50),
@Address2 varchar(50),
@Current_Country varchar(50),
@Home_Country varchar(50),
@ZipCode varchar(50),
@EmployeeID Integer

As
Begin
UPDATE Employee_Details
SET First_Name=@First_Name,Last_Name=@Last_Name,Mobile_Number=@Mobile_Number,AlternateMobileNumber=@AlternateMobileNumber,Address1=@Address1,Address2=@Address2,Current_Country=@Current_Country,Home_Country=@Home_Country,ZipCode=@ZipCode
WHERE EmployeeID=@EmployeeID
End
GO


