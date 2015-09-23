Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnsiteCourse.ViewModels
    Public Class OnsiteCourseViewModel
        Inherits ViewModelBase

        Private _onsiteCourses As ObservableCollection(Of Global.OnsiteCourse)
        Private _dataAccess As IOnsiteCourseService

        Public Property OnsiteCourses As ObservableCollection(Of Global.OnsiteCourse)
            Get
                Return Me._onsiteCourses
            End Get
            Set(value As ObservableCollection(Of Global.OnsiteCourse))
                Me._onsiteCourses = value
                OnPropertyChanged("OnsiteCourses")
            End Set
        End Property

        Private Function GetAllOnsiteCourses() As IQueryable(Of Global.OnsiteCourse)
            Return _dataAccess.GetAllOnsiteCourses
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._onsiteCourses = New ObservableCollection(Of Global.OnsiteCourse)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOnsiteCourseService)(New OnsiteCourseService)
            ' Initialize dataAccess from service
            Me._dataAccess = GetService(Of IOnsiteCourseService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllOnsiteCourses
                Me._onsiteCourses.Add(element)
            Next
        End Sub
    End Class
End Namespace
