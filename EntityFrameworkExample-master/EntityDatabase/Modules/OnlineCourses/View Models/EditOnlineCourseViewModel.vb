Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel
Imports BusinessObjects.Helpers

Namespace Modules.OnlineCourses.ViewModels
    Public Class EditOnlineCourseViewModel
        Inherits ViewModelBase

        Private _dataAccess As IOnlineCourseService
        Private _agregar As ICommand
        Private _ventana As EditOnlineCourse
        Private _curso As Course
        Private _cursos As ObservableCollection(Of Course)
        Private _url As String
        Private opcion As String
        Private onlineCourse As OnlineCourse

        Public Sub New(ventana As EditOnlineCourse, opcion As String, onlineCourse As OnlineCourse)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOnlineCourseService)(New OnlineCourseService)
            ' Initialize dataAccess from service
            Me._dataAccess = GetService(Of IOnlineCourseService)()
            ' Populate departments property variable 
            _cursos = New ObservableCollection(Of Course)
            Dim lisa As IQueryable(Of Course) = DataContext.DBEntities.Courses
            For Each element In lisa
                _cursos.Add(element)
            Next
            _ventana = ventana
            Me.opcion = opcion
            Me.onlineCourse = onlineCourse
            If opcion = "Editar" Then
                Curso = onlineCourse.Course
                URL = onlineCourse.URL
                Cursos.Clear()
                Cursos.Add(Curso)
            End If
        End Sub

        Public Property URL As String
            Get
                Return _url
            End Get
            Set(value As String)
                _url = value
                OnPropertyChanged("URL")
            End Set
        End Property

        Public Property Curso As Course
            Get
                Return _curso
            End Get
            Set(value As Course)
                _curso = value
                OnPropertyChanged("Curso")
            End Set
        End Property

        Public Property Cursos As ObservableCollection(Of Course)
            Get
                Return _cursos
            End Get
            Set(value As ObservableCollection(Of Course))
                _cursos = value
                OnPropertyChanged("Cursos")
            End Set
        End Property

        Public ReadOnly Property ButtonAgregar
            Get
                If _agregar Is Nothing Then
                    If opcion = "Agregar" Then
                        _agregar = New RelayCommand(AddressOf Agregar)
                    Else
                        _agregar = New RelayCommand(AddressOf Editar)
                    End If
                End If
                Return _agregar
            End Get
        End Property

        Public Sub Agregar()
            If URL <> Nothing And Curso IsNot Nothing Then
                Dim agregar As New OnlineCourse
                agregar.CourseID = Curso.CourseID
                agregar.URL = URL
                _dataAccess.CreateOnlineCourse(agregar)
                MsgBox("Online Course succesful created.", MsgBoxStyle.Information, "School")
                _ventana.Close()
            Else
                MsgBox("Ingrese todos los datos", MsgBoxStyle.Information, "School")
            End If

        End Sub

        Public Sub Editar()
            If URL <> Nothing And Curso IsNot Nothing Then
                Dim agregar As New OnlineCourse
                agregar.CourseID = Curso.CourseID
                agregar.URL = URL
                _dataAccess.EditOnlineCourse(agregar)
                MsgBox("Online Course succesful edited.", MsgBoxStyle.Information, "School")
                _ventana.Close()
            Else
                MsgBox("Ingrese todos los datos", MsgBoxStyle.Information, "School")
            End If

        End Sub
    End Class
End Namespace

