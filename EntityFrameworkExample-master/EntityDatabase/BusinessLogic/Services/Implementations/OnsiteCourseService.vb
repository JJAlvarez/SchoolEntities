Imports BusinessObjects.Helpers
Imports BusinessLogic.Services.Interfaces
Namespace BusinessLogic.Services.Implementations
    Public Class OnsiteCourseService
        Implements IOnsiteCourseService

        Public Function GetAllOnsiteCourses() As IQueryable(Of OnsiteCourse) Implements IOnsiteCourseService.GetAllOnsiteCourses
            Return DataContext.DBEntities.OnsiteCourse
        End Function

        Public Sub CreateOnsiteCourse(oCourse As OnsiteCourse) Implements IOnsiteCourseService.CreateOnsiteCourse
            DataContext.DBEntities.OnsiteCourse.Add(oCourse)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub DeleteOnsiteCourse(oCourse As OnsiteCourse) Implements IOnsiteCourseService.DeleteOnsiteCourse
            Dim eliminar = (From oc In DataContext.DBEntities.OnsiteCourse Where oc.CourseID = oCourse.CourseID).FirstOrDefault
            DataContext.DBEntities.OnsiteCourse.Remove(eliminar)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub EditOnsiteCourse(oCourse As OnsiteCourse) Implements IOnsiteCourseService.EditOnsiteCourse
            Dim oCourseE = (From oc In DataContext.DBEntities.OnsiteCourse Where oc.CourseID = oCourse.CourseID).FirstOrDefault
            oCourseE.Location = oCourse.Location
            oCourseE.Days = oCourse.Days
            oCourseE.Time = oCourse.Time
            DataContext.DBEntities.SaveChanges()
        End Sub
    End Class
End Namespace

