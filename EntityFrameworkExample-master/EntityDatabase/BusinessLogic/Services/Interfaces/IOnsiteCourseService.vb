Namespace BusinessLogic.Services.Interfaces
    Public Interface IOnsiteCourseService

        Function GetAllOnsiteCourses() As IQueryable(Of OnsiteCourse)

        Sub CreateOnsiteCourse(oCourse As OnsiteCourse)

        Sub DeleteOnsiteCourse(oCourse As OnsiteCourse)

        Sub EditOnsiteCourse(oCourse As OnsiteCourse)

    End Interface
End Namespace

