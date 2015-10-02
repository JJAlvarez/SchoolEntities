Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers

Namespace BusinessLogic.Services.Implementations
    Public Class CourseService
        Implements ICourseService

        Public Function GetAllCourses() As IQueryable(Of Course) Implements ICourseService.GetAllCourses
            Return DataContext.DBEntities.Courses
        End Function

        Public Sub CreateCourse(couse As Course) Implements ICourseService.CreateCourse
            DataContext.DBEntities.Courses.Add(couse)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub DeleteCourse(couse As Course) Implements ICourseService.DeleteCourse
            If couse.OnlineCourse IsNot Nothing Then
                DataContext.DBEntities.OnlineCourses.Remove(couse.OnlineCourse)
            End If
            If couse.OnsiteCourse IsNot Nothing Then
                DataContext.DBEntities.OnsiteCourse.Remove(couse.OnsiteCourse)
            End If
            If couse.StudentGrades IsNot Nothing Then
                Dim lista As IQueryable(Of StudentGrade) = (From sg In DataContext.DBEntities.StudentGrades Where sg.CourseID = couse.CourseID)
                For Each element In lista
                    DataContext.DBEntities.StudentGrades.Remove(element)
                Next
            End If
            Dim eliminar = (From c In DataContext.DBEntities.Courses Where c.CourseID = couse.CourseID).FirstOrDefault
            DataContext.DBEntities.Courses.Remove(eliminar)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub EditCourse(couse As Course) Implements ICourseService.EditCourse
            Dim courseE = (From c In DataContext.DBEntities.Courses Where c.CourseID = couse.CourseID).FirstOrDefault
            courseE.Title = couse.Title
            courseE.Credits = couse.Credits
            courseE.DepartmentID = couse.DepartmentID
            DataContext.DBEntities.SaveChanges()
        End Sub
    End Class
End Namespace
