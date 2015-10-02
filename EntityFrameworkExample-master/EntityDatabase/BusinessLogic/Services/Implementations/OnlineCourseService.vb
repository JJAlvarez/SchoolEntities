Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers

Namespace BusinessLogic.Services.Implementations
    Public Class OnlineCourseService
        Implements IOnlineCourseService

        Public Function GetAllOnlineCourses() As IQueryable(Of OnlineCourse) Implements IOnlineCourseService.GetAllOnlineCourses
            Return DataContext.DBEntities.OnlineCourses
        End Function

        Public Sub CreateOnlineCourse(oCurse As OnlineCourse) Implements IOnlineCourseService.CreateOnlineCourse
            DataContext.DBEntities.OnlineCourses.Add(oCurse)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub DeleteOnlineCourse(oCurse As OnlineCourse) Implements IOnlineCourseService.DeleteOnlineCourse
            Dim eliminar = (From oc In DataContext.DBEntities.OnlineCourses Where oc.CourseID = oCurse.CourseID).FirstOrDefault
            DataContext.DBEntities.OnlineCourses.Remove(eliminar)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub EditOnlineCourse(oCurse As OnlineCourse) Implements IOnlineCourseService.EditOnlineCourse
            Dim oCourseE = (From oc In DataContext.DBEntities.OnlineCourses Where oc.CourseID = oCurse.CourseID).FirstOrDefault
            oCourseE.URL = oCurse.URL
            DataContext.DBEntities.SaveChanges()
        End Sub
    End Class
End Namespace

