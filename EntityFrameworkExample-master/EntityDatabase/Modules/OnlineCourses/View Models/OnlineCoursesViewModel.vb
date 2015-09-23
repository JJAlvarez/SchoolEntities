Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnlineCourses.ViewModels
    Public Class OnlineCoursesViewModel
        Inherits ViewModelBase

        Private _onlineCourses As ObservableCollection(Of OnlineCourse)
        Private dataAccess As IOnlineCourseService

        Public Property OnlineCourses As ObservableCollection(Of OnlineCourse)
            Get
                Return Me._onlineCourses
            End Get
            Set(value As ObservableCollection(Of OnlineCourse))
                Me._onlineCourses = value
                OnPropertyChanged("OnlineCourses")
            End Set
        End Property

        ' Function to get all departments from service
        Private Function GetAllOnlineCourses() As IQueryable(Of OnlineCourse)
            Return Me.dataAccess.GetAllOnlineCourses
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._onlineCourses = New ObservableCollection(Of OnlineCourse)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOnlineCourseService)(New OnlineCourseService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IOnlineCourseService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllOnlineCourses
                Me._onlineCourses.Add(element)
            Next
        End Sub
    End Class
End Namespace
