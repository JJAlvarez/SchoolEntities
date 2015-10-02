Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class DepartmentService
        Implements IDepartmentService

        Public Function GetAllDepartments() As IQueryable(Of Department) Implements IDepartmentService.GetAllDepartments
            Return DataContext.DBEntities.Departments
        End Function

        Public Sub CreateDepartment(department As Department) Implements IDepartmentService.CreateDepartment
            DataContext.DBEntities.Departments.Add(department)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub DeleteDepartment(department As Department) Implements IDepartmentService.DeleteDepartment
            Dim courses As IQueryable(Of Course) = (From c In DataContext.DBEntities.Courses Where c.DepartmentID = department.DepartmentID)
            For Each element In courses
                DataContext.DBEntities.Courses.Remove(element)
            Next
            DataContext.DBEntities.SaveChanges()
            DataContext.DBEntities.Departments.Remove(department)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub EditDepartment(department As Department) Implements IDepartmentService.EditDepartment
            Dim departmentE = (From d In DataContext.DBEntities.Departments Where d.DepartmentID = department.DepartmentID).FirstOrDefault
            departmentE.Name = department.Name
            departmentE.Budget = department.Budget
            departmentE.StartDate = department.StartDate
            departmentE.Administrator = department.Administrator
            DataContext.DBEntities.SaveChanges()
        End Sub
    End Class
End Namespace

