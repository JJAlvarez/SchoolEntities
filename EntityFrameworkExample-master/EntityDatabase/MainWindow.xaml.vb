Imports Modules.Departments.ViewModels
Imports Modules.Courses.ViewModels
Imports Modules.Persons.ViewModels
Imports Modules.OfficeAssigments.ViewModels
Imports Modules.OnlineCourses.ViewModels
Imports Modules.OnsiteCourse.ViewModels
Imports Modules.StudentGrades.ViewModels
Class MainWindow
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DepartmenstUserControl.MainGrid.DataContext = New DepartmentsViewModel()
        Me.CoursesControl.CursosGrid.DataContext = New CoursesViewModel
        Me.PersonsControl.PersonsGrid.DataContext = New PersonsViewModel
        Me.OfficeAssigmentControl.OfficeAssigmentGrid.DataContext = New OfficeAssigmentViewModel
        Me.OnlineCoursesControl.OCursosGrid.DataContext = New OnlineCoursesViewModel
        Me.OnsiteCoursesControl.OnCursosGrid.DataContext = New OnsiteCourseViewModel
        Me.StudentGradesControl.StudentGradesGrid.DataContext = New StudentGradesViewModel
    End Sub
End Class
