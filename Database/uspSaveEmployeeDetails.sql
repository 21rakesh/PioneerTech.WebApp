
CREATE Procedure [dbo].[uspSaveEmployeeDetails]
@First_Name varchar(50),
@Last_Name varchar(50),
@Mobile_Number varchar(50),
@AlternateMobileNumber varchar(50),
@Address1 varchar(50),
@Address2 varchar(50),
@Current_Country varchar(50),
@Home_Country varchar(50),
@ZipCode varchar(50)

As
Begin
Insert INTO Employee_Details(First_Name,Last_Name,Mobile_Number,AlternateMobileNumber,Current_Country,Home_Country,ZipCode) Values(@First_Name,@Last_Name,@Mobile_Number,@AlternateMobileNumber,@Current_Country,@Home_Country,@ZipCode)
End
GO


