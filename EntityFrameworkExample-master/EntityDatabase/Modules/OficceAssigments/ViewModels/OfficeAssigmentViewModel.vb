Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OfficeAssigments.ViewModels
    Public Class OfficeAssigmentViewModel
        Inherits ViewModelBase

        Private _officeAssigments As ObservableCollection(Of OfficeAssignment)
        Private dataAccess As IOfficeAssigment
        Private _officeAssigment As OfficeAssignment
        Private _agregar As ICommand
        Private _eliminar As ICommand
        Private _editar As ICommand

        Public Property OfficeAssignments As ObservableCollection(Of OfficeAssignment)
            Get
                Return Me._officeAssigments
            End Get
            Set(value As ObservableCollection(Of OfficeAssignment))
                Me._officeAssigments = value
                OnPropertyChanged("OfficeAssignments")
            End Set
        End Property

        Public Property OfficeAssigment As OfficeAssignment
            Get
                Return _officeAssigment
            End Get
            Set(value As OfficeAssignment)
                _officeAssigment = value
                OnPropertyChanged("OfficeAssigment")
            End Set
        End Property

        ' Function to get all departments from service
        Private Function GetAllOfficeAssigments() As IQueryable(Of OfficeAssignment)
            Return Me.dataAccess.GetAllOfficeAssigments
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._officeAssigments = New ObservableCollection(Of OfficeAssignment)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOfficeAssigment)(New OfficeAssigmentService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IOfficeAssigment)()
            ' Populate departments property variable 
            For Each element In Me.GetAllOfficeAssigments
                Me._officeAssigments.Add(element)
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
            Dim editar As New EditOfficeAssigment("Agregar", OfficeAssigment)
            editar.ShowDialog()
            _officeAssigments.Clear()
            For Each element In Me.GetAllOfficeAssigments
                Me._officeAssigments.Add(element)
            Next
        End Sub

        Public Sub Eliminar()
            If OfficeAssigment IsNot Nothing Then
                dataAccess.DeleteOfficeAssigment(OfficeAssigment)
                _officeAssigments.Remove(OfficeAssigment)
                MsgBox("Office Assignment succesful deleted.", MsgBoxStyle.Information, "School System")
            Else
                MsgBox("Please select an Office Assignment.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub

        Public Sub Editar()
            If OfficeAssigment IsNot Nothing Then
                Dim editar As New EditOfficeAssigment("Editar", OfficeAssigment)
                editar.ShowDialog()
                _officeAssigments.Clear()
                For Each element In Me.GetAllOfficeAssigments
                    Me._officeAssigments.Add(element)
                Next
            Else
                MsgBox("Please select an Office Assignment.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub
    End Class
End Namespace
