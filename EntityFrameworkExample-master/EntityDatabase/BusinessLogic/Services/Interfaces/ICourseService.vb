Namespace BusinessLogic.Services.Interfaces
    Public Interface ICourseService

        Function GetAllCourses() As IQueryable(Of Course)

        Sub CreateCourse(couse As Course)

        Sub DeleteCourse(couse As Course)

        Sub EditCourse(couse As Course)

    End Interface
End Namespace

