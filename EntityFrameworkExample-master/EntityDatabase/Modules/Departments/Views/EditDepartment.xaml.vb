Imports Modules.Departments.ViewModels

Public Class EditDepartment
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New EditDepartmentViewModel(Me)
    End Sub
End Class
