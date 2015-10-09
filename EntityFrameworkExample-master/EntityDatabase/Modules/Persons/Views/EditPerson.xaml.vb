Imports Modules.Persons.ViewModels

Namespace Modules.Persons.Views
    Public Class EditPerson
        Public Sub New(opcion As String, persona As Person)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DataContext = New EditPersonViewModel(Me, opcion, persona)
        End Sub
    End Class
End Namespace
