Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers

Namespace BusinessLogic.Services.Implementations
    Public Class StudentGradeService
        Implements IStudentGradeService

        Public Function GetAllStudentGrades() As IQueryable(Of StudentGrade) Implements IStudentGradeService.GetAllStudentGrades
            Return DataContext.DBEntities.StudentGrades
        End Function

        Public Sub CreateStudentGrade(sGrade As StudentGrade) Implements IStudentGradeService.CreateStudentGrade
            DataContext.DBEntities.StudentGrades.Add(sGrade)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub DeleteStudentGrade(sGrade As StudentGrade) Implements IStudentGradeService.DeleteStudentGrade
            DataContext.DBEntities.StudentGrades.Remove(sGrade)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub EditStudentGrade(sGrade As StudentGrade) Implements IStudentGradeService.EditStudentGrade
            Dim sGradeE = (From sg In DataContext.DBEntities.StudentGrades Where sg.EnrollmentID = sGrade.EnrollmentID).FirstOrDefault
            sGradeE.Grade = sGrade.Grade
            DataContext.DBEntities.SaveChanges()
        End Sub
    End Class
End Namespace

