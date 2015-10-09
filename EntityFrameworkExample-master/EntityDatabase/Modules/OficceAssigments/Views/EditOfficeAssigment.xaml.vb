Imports Modules.OficceAssigment.ViewModels

Public Class EditOfficeAssigment
    Public Sub New(opcion As String, officeAssigment As OfficeAssignment)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New EditOfficeAssigmentViewModel(Me, opcion, officeAssigment)
    End Sub
End Class
