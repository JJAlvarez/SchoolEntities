Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.Courses.ViewModels
    Public Class CoursesViewModel
        Inherits ViewModelBase

        Private _courses As ObservableCollection(Of Course)
        Private _dataAccess As ICourseService

        Public Property Courses
            Get
                Return Me._courses
            End Get
            Set(value)
                Me._courses = value
                OnPropertyChanged("Courses")
            End Set
        End Property

        Private Function GetAllCourses() As IQueryable(Of Course)
            Return _dataAccess.GetAllCourses
        End Function

        Public Sub New()
            Me._courses = New ObservableCollection(Of Course)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of ICourseService)(New CourseService)
            ' Initialize dataAccess from service
            Me._dataAccess = GetService(Of ICourseService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllCourses
                Me._courses.Add(element)
            Next
        End Sub

    End Class
End Namespace

