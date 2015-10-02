Namespace BusinessLogic.Services.Interfaces
    Public Interface IOnlineCourseService

        Function GetAllOnlineCourses() As IQueryable(Of OnlineCourse)

        Sub CreateOnlineCourse(oCurse As OnlineCourse)

        Sub DeleteOnlineCourse(oCurse As OnlineCourse)

        Sub EditOnlineCourse(oCurse As OnlineCourse)

    End Interface
End Namespace

