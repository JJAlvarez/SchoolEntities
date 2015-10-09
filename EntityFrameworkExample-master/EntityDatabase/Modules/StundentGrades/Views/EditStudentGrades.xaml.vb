Namespace Modules.StudentGrades.Views
    Public Class EditStudentGrades
        Public Sub New(opcion As String, studentGrade As StudentGrade)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DataContext = New ViewModels.EditStudentGradeViewModel(Me, opcion, studentGrade)
        End Sub
    End Class
End Namespace
