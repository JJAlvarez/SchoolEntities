Imports Modules.OnsiteCourse.ViewModels

Namespace Modules.OnsiteCourse.Views
    Public Class EditOnsiteCourse
        Public Sub New(opcion As String, onsiteCourse As Global.OnsiteCourse)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DataContext = New EditOnsiteCourseViewModel(Me, opcion, onsiteCourse)
        End Sub
    End Class
End Namespace
