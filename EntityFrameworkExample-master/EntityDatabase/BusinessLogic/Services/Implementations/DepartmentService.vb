
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
            For Each element In department.Courses
                element.People.Clear()
                element.StudentGrades.Clear()
                If element.OnlineCourse IsNot Nothing Then
                    DataContext.DBEntities.OnlineCourses.Remove(element.OnlineCourse)
                End If

                If element.OnsiteCourse IsNot Nothing Then
                    DataContext.DBEntities.OnsiteCourse.Remove(element.OnsiteCourse)
                End If
            Next
            DataContext.DBEntities.SaveChanges()
            If department.Courses.Count > 0 Then
                department.Courses.Clear()
            End If
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

