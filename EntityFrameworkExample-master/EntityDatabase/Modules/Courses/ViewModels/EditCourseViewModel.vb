Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel
Imports BusinessObjects.Helpers
Imports Modules.Courses.Views

Namespace Modules.Courses.ViewModels
    Public Class EditCourseViewModel
        Inherits ViewModelBase

        Private _title As String
        Private _credits As String
        Private _departement As Department
        Private _departments As ObservableCollection(Of Department)
        Private _dataAccess As ICourseService
        Private _agregar As ICommand
        Private _ventana As EditCourse
        Private opcion As String
        Private curso As Course

        Public Property Titel As String
            Get
                Return _title
            End Get
            Set(value As String)
                _title = value
                OnPropertyChanged("Title")
            End Set
        End Property

        Public Property Credits As String
            Get
                Return _credits
            End Get
            Set(value As String)
                _credits = value
                OnPropertyChanged("Credits")
            End Set
        End Property

        Public Property Department As Department
            Get
                Return _departement
            End Get
            Set(value As Department)
                _departement = value
                OnPropertyChanged("Department")
            End Set
        End Property

        Public Property Departments As ObservableCollection(Of Department)
            Get
                Return _departments
            End Get
            Set(value As ObservableCollection(Of Department))
                _departments = value
                OnPropertyChanged("Departments")
            End Set
        End Property

        Public Sub New(ventana As EditCourse, opcion As String, curso As Course)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of ICourseService)(New CourseService)
            ' Initialize dataAccess from service
            Me._dataAccess = GetService(Of ICourseService)()
            ' Populate departments property variable 
            _departments = New ObservableCollection(Of Department)
            Me.opcion = opcion
            Me.curso = curso
            If opcion = "Editar" Then
                Titel = curso.Title
                Credits = curso.Credits
                Department = curso.Department
            End If
            Dim departments As IQueryable(Of Department) = DataContext.DBEntities.Departments

            For Each elemet In departments
                _departments.Add(elemet)
            Next
            _ventana = ventana
        End Sub

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
            If Titel <> Nothing And Credits <> Nothing And Department IsNot Nothing Then
                Dim course As New Course
                Dim courses As IQueryable(Of Course) = DataContext.DBEntities.Courses
                course.Title = Titel
                course.CourseID = courses.ToArray.Length + 1
                course.Credits = Credits
                course.DepartmentID = Department.DepartmentID
                _dataAccess.CreateCourse(course)
                MsgBox("Course succesful created.", MsgBoxStyle.Information, "School")
                _ventana.Close()
            Else
                MsgBox("Ingrese todos los datos", MsgBoxStyle.Information, "School")
            End If

        End Sub

        Public Sub Editar()
            If Titel <> Nothing And Credits <> Nothing And Department IsNot Nothing Then
                Dim course As New Course
                Dim courses As IQueryable(Of Course) = DataContext.DBEntities.Courses
                course.Title = Titel
                course.CourseID = curso.CourseID
                course.Credits = Credits
                course.DepartmentID = Department.DepartmentID
                _dataAccess.EditCourse(course)
                MsgBox("Course succesful edited.", MsgBoxStyle.Information, "School")
                _ventana.Close()
            Else
                MsgBox("Ingrese todos los datos", MsgBoxStyle.Information, "School")
            End If
        End Sub
    End Class
End Namespace

