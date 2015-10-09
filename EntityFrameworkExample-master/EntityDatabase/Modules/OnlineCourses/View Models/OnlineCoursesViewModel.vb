Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnlineCourses.ViewModels
    Public Class OnlineCoursesViewModel
        Inherits ViewModelBase

        Private _onlineCourses As ObservableCollection(Of OnlineCourse)
        Private dataAccess As IOnlineCourseService
        Private _onlineCourse As OnlineCourse
        Private _agregar As ICommand
        Private _eliminar As ICommand
        Private _editar As ICommand

        Public Property OnlineCourses As ObservableCollection(Of OnlineCourse)
            Get
                Return Me._onlineCourses
            End Get
            Set(value As ObservableCollection(Of OnlineCourse))
                Me._onlineCourses = value
                OnPropertyChanged("OnlineCourses")
            End Set
        End Property

        Public Property OnlineCourse As OnlineCourse
            Get
                Return Me._onlineCourse
            End Get
            Set(value As OnlineCourse)
                Me._onlineCourse = value
                OnPropertyChanged("OnlineCourse")
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
            Dim editar As New EditOnlineCourse("Agregar", OnlineCourse)
            editar.ShowDialog()

            _onlineCourses.Clear()
            For Each element In Me.GetAllOnlineCourses
                Me._onlineCourses.Add(element)
            Next
        End Sub

        Public Sub Eliminar()
            If OnlineCourse IsNot Nothing Then
                dataAccess.DeleteOnlineCourse(OnlineCourse)
                _onlineCourses.Remove(OnlineCourse)
                MsgBox("Online Course succesful deleted.", MsgBoxStyle.Information, "School System")
            Else
                MsgBox("Please selct an Online Course.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub

        Public Sub Editar()
            If OnlineCourse IsNot Nothing Then
                Dim editar As New EditOnlineCourse("Editar", OnlineCourse)
                editar.ShowDialog()

                _onlineCourses.Clear()
                For Each element In Me.GetAllOnlineCourses
                    Me._onlineCourses.Add(element)
                Next
            Else
                MsgBox("Please selct an Online Course.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub
    End Class
End Namespace
