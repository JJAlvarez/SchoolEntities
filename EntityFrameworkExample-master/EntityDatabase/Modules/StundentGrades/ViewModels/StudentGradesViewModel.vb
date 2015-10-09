Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel
Imports Modules.StudentGrades.Views

Namespace Modules.StudentGrades.ViewModels
    Public Class StudentGradesViewModel
        Inherits ViewModelBase

        Private _StudentGrades As ObservableCollection(Of StudentGrade)
        Private dataAccess As IStudentGradeService
        Private _studentGrade As StudentGrade
        Private _agregar As ICommand
        Private _eliminar As ICommand
        Private _editar As ICommand

        Public Property StudentGrades As ObservableCollection(Of StudentGrade)
            Get
                Return Me._StudentGrades
            End Get
            Set(value As ObservableCollection(Of StudentGrade))
                Me._StudentGrades = value
                OnPropertyChanged("StudentGrades")
            End Set
        End Property

        Public Property StudentGrade As StudentGrade
            Get
                Return Me._studentGrade
            End Get
            Set(value As StudentGrade)
                Me._studentGrade = value
                OnPropertyChanged("StudentGrade")
            End Set
        End Property

        ' Function to get all departments from service
        Private Function GetAllStudentGrades() As IQueryable(Of StudentGrade)
            Return Me.dataAccess.GetAllStudentGrades
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._StudentGrades = New ObservableCollection(Of StudentGrade)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IStudentGradeService)(New StudentGradeService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IStudentGradeService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllStudentGrades
                Me._StudentGrades.Add(element)
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
            Dim editar As New EditStudentGrades("Agregar", StudentGrade)
            editar.ShowDialog()
            _StudentGrades.Clear()
            For Each element In Me.GetAllStudentGrades
                _StudentGrades.Add(element)
            Next
        End Sub

        Public Sub Eliminar()
            If StudentGrade IsNot Nothing Then
                dataAccess.DeleteStudentGrade(StudentGrade)
                _StudentGrades.Remove(StudentGrade)
                MsgBox("Student Grade succesful deleted.", MsgBoxStyle.Information, "School System")
            Else
                MsgBox("Please select an Student Grade.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub

        Public Sub Editar()
            If StudentGrade IsNot Nothing Then
                Dim editar As New EditStudentGrades("Editar", StudentGrade)
                editar.ShowDialog()
                _StudentGrades.Clear()
                For Each element In Me.GetAllStudentGrades
                    _StudentGrades.Add(element)
                Next
            Else
                MsgBox("Please select an Student Grade.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub
    End Class
End Namespace

