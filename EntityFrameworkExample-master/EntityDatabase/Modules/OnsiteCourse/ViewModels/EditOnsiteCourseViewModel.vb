Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel
Imports BusinessObjects.Helpers
Imports Modules.OnsiteCourse.Views

Namespace Modules.OnsiteCourse.ViewModels
    Public Class EditOnsiteCourseViewModel
        Inherits ViewModelBase

        Private _dataAccess As IOnsiteCourseService
        Private _agregar As ICommand
        Private _ventana As EditOnsiteCourse
        Private _curso As Course
        Private _location As String
        Private _days As String
        Private _time As Date = Date.Today
        Private opcion As String
        Private onsiteCourse As Global.OnsiteCourse

        Private _cursos As ObservableCollection(Of Course)

        Public Sub New(ventana As EditOnsiteCourse, opcion As String, onsiteCourse As Global.OnsiteCourse)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOnsiteCourseService)(New OnsiteCourseService)
            ' Initialize dataAccess from service
            Me._dataAccess = GetService(Of IOnsiteCourseService)()
            ' Populate departments property variable 
            _cursos = New ObservableCollection(Of Course)
            Dim lisa As IQueryable(Of Course) = DataContext.DBEntities.Courses
            For Each element In lisa
                _cursos.Add(element)
            Next
            _ventana = ventana
            Me.opcion = opcion
            Me.onsiteCourse = onsiteCourse
            If opcion = "Editar" Then
                Curso = onsiteCourse.Course
                Location = onsiteCourse.Location
                Days = onsiteCourse.Days
                Time = onsiteCourse.Time
                Cursos.Clear()
                Cursos.Add(Curso)
            End If
        End Sub

        Public Property Curso As Course
            Get
                Return _curso
            End Get
            Set(value As Course)
                _curso = value
                OnPropertyChanged("Curso")
            End Set
        End Property

        Public Property Location As String
            Get
                Return _location
            End Get
            Set(value As String)
                _location = value
                OnPropertyChanged("Location")
            End Set
        End Property


        Public Property Days As String
            Get
                Return _days
            End Get
            Set(value As String)
                _days = value
                OnPropertyChanged("Days")
            End Set
        End Property

        Public Property Time As Date
            Get
                Return _time
            End Get
            Set(value As Date)
                _time = value
                OnPropertyChanged("Time")
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
            If Curso IsNot Nothing And Location <> Nothing And Days <> Nothing And Time <> Nothing Then
                Dim sePuede As Boolean = True
                For Each element In _cursos
                    If element.OnsiteCourse IsNot Nothing Then
                        If element.OnsiteCourse.CourseID = Curso.CourseID Then
                            sePuede = False
                        End If
                    End If
                Next
                If sePuede Then
                    Dim onsitecourse As New Global.OnsiteCourse
                    onsitecourse.CourseID = Curso.CourseID
                    onsitecourse.Location = Location
                    onsitecourse.Days = Days
                    onsitecourse.Time = Time
                    _dataAccess.CreateOnsiteCourse(onsitecourse)
                    _ventana.Close()
                    MsgBox("Onsite Course succesful created.", MsgBoxStyle.Information, "School")
                Else
                    MsgBox("This course already has an Onsite Course.", MsgBoxStyle.Exclamation, "School")
                End If
            Else
                MsgBox("Please insert all the information.", MsgBoxStyle.Exclamation, "School")
            End If
        End Sub

        Public Sub Editar()
            If Curso IsNot Nothing And Location <> Nothing And Days <> Nothing And Time <> Nothing Then
                Dim onsitecourse As New Global.OnsiteCourse
                onsitecourse.CourseID = Curso.CourseID
                onsitecourse.Location = Location
                onsitecourse.Days = Days
                onsitecourse.Time = Time
                _dataAccess.EditOnsiteCourse(onsitecourse)
                _ventana.Close()
                MsgBox("Onsite Course succesful edited.", MsgBoxStyle.Information, "School")
            Else
                MsgBox("Please insert all the information.", MsgBoxStyle.Exclamation, "School")
            End If
        End Sub

    End Class
End Namespace
