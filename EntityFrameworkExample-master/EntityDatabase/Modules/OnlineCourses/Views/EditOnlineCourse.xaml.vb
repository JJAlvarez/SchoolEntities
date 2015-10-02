Imports Modules.OnlineCourses.ViewModels

Public Class EditOnlineCourse
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New EditOnlineCourseViewModel(Me)
    End Sub
End Class
