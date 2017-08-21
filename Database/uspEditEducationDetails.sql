
CREATE PROCEDURE [dbo].[uspEditEducationDetails]
@CourseType varchar(50),
@YearOfPass INTEGER,
@CourseSpecialisation varchar(50),
@EmployeeID INTEGER

AS
BEGIN
UPDATE Education_Details
SET CourseType=@CourseType,YearOfPass=@YearOfPass,CourseSpecialisation=@CourseSpecialisation
WHERE EmployeeID=@EmployeeID
END
GO


