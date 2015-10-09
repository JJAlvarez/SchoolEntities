Imports Modules.OnlineCourses.ViewModels

Public Class EditOnlineCourse
    Public Sub New(opcion As String, onlineCourse As OnlineCourse)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New EditOnlineCourseViewModel(Me, opcion, onlineCourse)
    End Sub
End Class
