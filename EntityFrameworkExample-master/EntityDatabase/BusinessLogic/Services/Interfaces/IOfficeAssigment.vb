Namespace BusinessLogic.Services.Interfaces
    Public Interface IOfficeAssigment

        Function GetAllOfficeAssigments() As IQueryable(Of OfficeAssignment)

        Sub CreateOfficeAssigment(oAssigment As OfficeAssignment)

        Sub DeleteOfficeAssigment(oAssigment As OfficeAssignment)

        Sub EditOfficeAssigment(oAssigment As OfficeAssignment, oAssigmentE As OfficeAssignment)

    End Interface
End Namespace

