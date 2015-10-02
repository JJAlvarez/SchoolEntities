Namespace BusinessLogic.Services.Interfaces
    Public Interface IStudentGradeService

        Function GetAllStudentGrades() As IQueryable(Of StudentGrade)

        Sub CreateStudentGrade(sGrade As StudentGrade)

        Sub DeleteStudentGrade(sGrade As StudentGrade)

        Sub EditStudentGrade(sGrade As StudentGrade)

    End Interface
End Namespace

