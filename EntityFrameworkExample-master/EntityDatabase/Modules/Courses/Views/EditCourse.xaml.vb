Imports Modules.Courses.ViewModels

Namespace Modules.Courses.Views
    Public Class EditCourse
        Public Sub New(opcion As String, curso As Course)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DataContext = New EditCourseViewModel(Me, opcion, curso)
        End Sub

    End Class
End Namespace
