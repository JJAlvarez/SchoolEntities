Imports Modules.Departments.ViewModels

Public Class EditDepartment
    Public Sub New(opcion As String, departamento As Department)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New EditDepartmentViewModel(Me, opcion, departamento)
    End Sub
End Class
