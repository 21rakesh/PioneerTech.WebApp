
CREATE PROCEDURE [dbo].[uspSaveEducationDetails]
@CourseType varchar(50),
@YearOfPass Integer,
@CourseSpecialisation varchar(50)

AS
BEGIN
INSERT INTO Education_Details(CourseType,YearOfPass,CourseSpecialisation)values(@CourseType,@YearOfPass,@CourseSpecialisation)
End
GO


