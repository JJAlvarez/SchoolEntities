Namespace BusinessLogic.Services.Interfaces
    Public Interface IDepartmentService

        Function GetAllDepartments() As IQueryable(Of Department)

        Sub CreateDepartment(department As Department)

        Sub DeleteDepartment(department As Department)

        Sub EditDepartment(department As Department)
    End Interface
End Namespace

