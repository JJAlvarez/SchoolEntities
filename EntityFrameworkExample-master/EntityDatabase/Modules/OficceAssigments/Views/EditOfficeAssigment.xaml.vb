Imports Modules.OficceAssigment.ViewModels

Public Class EditOfficeAssigment
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New EditOfficeAssigmentViewModel(Me)
    End Sub
End Class
