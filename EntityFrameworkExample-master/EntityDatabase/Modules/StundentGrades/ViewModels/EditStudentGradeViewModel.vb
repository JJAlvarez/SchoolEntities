Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Interfaces
Imports BusinessLogic.Services.Implementations
Imports BusinessObjects.Helpers
Imports Modules.StudentGrades.Views
Imports System.Collections.ObjectModel

Namespace Modules.StudentGrades.ViewModels
    Public Class EditStudentGradeViewModel
        Inherits ViewModelBase

        Private _curso As Course
        Private _person As Person
        Private _grade As String
        Private _persons As ObservableCollection(Of Person)
        Private _cursos As ObservableCollection(Of Course)
        Private _aceptar As ICommand
        Private _dataAcces As IStudentGradeService
        Private _ventana As EditStudentGrades
        Private opcion As String
        Private studentGrade As StudentGrade

        Public Property Curso As Course
            Get
                Return _curso
            End Get
            Set(value As Course)
                _curso = value
                OnPropertyChanged("Curso")
            End Set
        End Property

        Public Property Person As Person
            Get
                Return _person
            End Get
            Set(value As Person)
                _person = value
                OnPropertyChanged("Person")
            End Set
        End Property

        Public Property Grade As String
            Get
                Return _grade
            End Get
            Set(value As String)
                _grade = value
                OnPropertyChanged("Grade")
            End Set
        End Property


        Public Property Persons As ObservableCollection(Of Person)
            Get
                Return _persons
            End Get
            Set(value As ObservableCollection(Of Person))
                _persons = value
                OnPropertyChanged("Persons")
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

        Public ReadOnly Property Aceptar
            Get
                If _aceptar Is Nothing Then
                    If opcion = "Agregar" Then
                        _aceptar = New RelayCommand(AddressOf AceptarButton)
                    Else
                        _aceptar = New RelayCommand(AddressOf EditarButton)
                    End If
                End If
                Return _aceptar
            End Get
        End Property

        Public Sub AceptarButton()
            If Curso IsNot Nothing And Grade IsNot Nothing And Person IsNot Nothing Then
                Dim studentGrade As New StudentGrade
                studentGrade.StudentID = Person.PersonID
                studentGrade.CourseID = Curso.CourseID
                studentGrade.Grade = Grade
                studentGrade.EnrollmentID = (From s In DataContext.DBEntities.StudentGrades).ToArray.Length + 1
                _dataAcces.CreateStudentGrade(studentGrade)
                _ventana.Close()
                MsgBox("Student Grade Succesful created.", MsgBoxStyle.Information, "School")
            Else
                MsgBox("Please insert all the information.", MsgBoxStyle.Information, "School")
            End If
        End Sub

        Public Sub EditarButton()
            If Curso IsNot Nothing And Grade IsNot Nothing And Person IsNot Nothing Then
                Dim studentGrade As New StudentGrade
                studentGrade.StudentID = Person.PersonID
                studentGrade.CourseID = Curso.CourseID
                studentGrade.Grade = Grade
                studentGrade.EnrollmentID = Me.studentGrade.EnrollmentID
                _dataAcces.EditStudentGrade(studentGrade)
                MsgBox("Student Grade Succesful edited.", MsgBoxStyle.Information, "School")
                _ventana.Close()
            Else
                MsgBox("Please insert all the information.", MsgBoxStyle.Information, "School")
            End If
        End Sub

        Public Sub New(ventana As EditStudentGrades, opcion As String, studentGrade As StudentGrade)
            ServiceLocator.RegisterService(Of IStudentGradeService)(New StudentGradeService)
            ' Initialize dataAccess from service
            _dataAcces = GetService(Of IStudentGradeService)()
            _ventana = ventana
            _persons = New ObservableCollection(Of Person)
            _cursos = New ObservableCollection(Of Course)

            For Each element In DataContext.DBEntities.Person
                _persons.Add(element)
            Next

            For Each element In DataContext.DBEntities.Courses
                _cursos.Add(element)
            Next
            Me.opcion = opcion
            Me.studentGrade = studentGrade
            If opcion = "Editar" Then
                Grade = studentGrade.Grade
                Person = studentGrade.Person
                Curso = studentGrade.Course
                Cursos.Clear()
                Cursos.Add(Curso)
                Persons.Clear()
                Persons.Add(Person)
            End If
        End Sub
    End Class
End Namespace
