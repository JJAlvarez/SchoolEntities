Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel
Imports Modules.OnsiteCourse.Views

Namespace Modules.OnsiteCourse.ViewModels
    Public Class OnsiteCourseViewModel
        Inherits ViewModelBase

        Private _onsiteCourses As ObservableCollection(Of Global.OnsiteCourse)
        Private _dataAccess As IOnsiteCourseService
        Private _onsiteCourse As Global.OnsiteCourse
        Private _agregar As ICommand
        Private _eliminar As ICommand
        Private _editar As ICommand

        Public Property OnsiteCourses As ObservableCollection(Of Global.OnsiteCourse)
            Get
                Return Me._onsiteCourses
            End Get
            Set(value As ObservableCollection(Of Global.OnsiteCourse))
                Me._onsiteCourses = value
                OnPropertyChanged("OnsiteCourses")
            End Set
        End Property

        Public Property OnsiteCourse As Global.OnsiteCourse
            Get
                Return Me._onsiteCourse
            End Get
            Set(value As Global.OnsiteCourse)
                Me._onsiteCourse = value
                OnPropertyChanged("OnsiteCourse")
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
            Dim editar As New EditOnsiteCourse("Agregar", OnsiteCourse)
            editar.ShowDialog()
            _onsiteCourses.Clear()
            For Each element In Me.GetAllOnsiteCourses
                _onsiteCourses.Add(element)
            Next
        End Sub

        Public Sub Eliminar()
            If OnsiteCourse IsNot Nothing Then
                _dataAccess.DeleteOnsiteCourse(OnsiteCourse)
                _onsiteCourses.Remove(OnsiteCourse)
                MsgBox("Onsite Course succesful deleted.", MsgBoxStyle.Information, "School System")
            Else
                MsgBox("Please select a Onsite Course.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub

        Public Sub Editar()
            If OnsiteCourse IsNot Nothing Then
                Dim editar As New EditOnsiteCourse("Editar", OnsiteCourse)
                editar.ShowDialog()
                _onsiteCourses.Clear()
                For Each element In Me.GetAllOnsiteCourses
                    _onsiteCourses.Add(element)
                Next
            Else
                MsgBox("Please select a Onsite Course.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub
    End Class
End Namespace
