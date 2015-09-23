Imports BusinessObjects.Helpers
Imports BusinessLogic.Services.Interfaces
Namespace BusinessLogic.Services.Implementations
    Public Class OnsiteCourseService
        Implements IOnsiteCourseService

        Public Function GetAllOnsiteCourses() As IQueryable(Of OnsiteCourse) Implements IOnsiteCourseService.GetAllOnsiteCourses
            Return DataContext.DBEntities.OnsiteCourse
        End Function

    End Class
End Namespace

