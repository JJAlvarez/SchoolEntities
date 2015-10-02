Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel
Imports Modules.Courses.Views

Namespace Modules.Courses.ViewModels
    Public Class CoursesViewModel
        Inherits ViewModelBase

        Private _courses As ObservableCollection(Of Course)
        Private _dataAccess As ICourseService
        Private _course As Course
        Private _agregar As ICommand
        Private _eliminar As ICommand
        Private _editar As ICommand

        Public Property Courses
            Get
                Return Me._courses
            End Get
            Set(value)
                Me._courses = value
                OnPropertyChanged("Courses")
            End Set
        End Property

        Public Property Course As Course
            Get
                Return _course
            End Get
            Set(value As Course)
                _course = value
                OnPropertyChanged("Course")
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

        Public ReadOnly Property ButtonAgregar
            Get
                If _agregar Is Nothing Then
                    _agregar = New RelayCommand(AddressOf Agregar)
                End If
                Return _agregar
            End Get
        End Property

        Public ReadOnly Property ButtonEliminar
            Get
                If _eliminar Is Nothing Then
                    _eliminar = New RelayCommand(AddressOf Eliminar)
                End If
                Return _eliminar
            End Get
        End Property

        Public ReadOnly Property ButtonEditar
            Get
                If _editar Is Nothing Then
                    _editar = New RelayCommand(AddressOf Editar)
                End If
                Return _editar
            End Get
        End Property

        Public Sub Agregar()
            Dim editar As New Modules.Courses.Views.EditCourse
            editar.ShowDialog()
            _courses.Clear()
            For Each element In Me.GetAllCourses
                Me._courses.Add(element)
            Next
        End Sub

        Public Sub Eliminar()
            If Course IsNot Nothing Then
                _dataAccess.DeleteCourse(Course)
                _courses.Remove(Course)
                MsgBox("Course succesful deleted.", MsgBoxStyle.Critical, "School System")
            Else
                MsgBox("Please select a Course.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub

        Public Sub Editar()

        End Sub
    End Class
End Namespace

