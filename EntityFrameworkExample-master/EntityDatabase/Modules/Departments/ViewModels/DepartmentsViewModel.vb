Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.Departments.ViewModels
    Public Class DepartmentsViewModel
        Inherits ViewModelBase

        Private _departments As ObservableCollection(Of Department)
        Private dataAccess As IDepartmentService
        Private _department As Department
        Private _agregar As ICommand
        Private _eliminar As ICommand
        Private _editar As ICommand

        Public Property Departments As ObservableCollection(Of Department)
            Get
                Return Me._departments
            End Get
            Set(value As ObservableCollection(Of Department))
                Me._departments = value
                OnPropertyChanged("Departments")
            End Set
        End Property

        Public Property Department As Department
            Get
                Return _department
            End Get
            Set(value As Department)
                _department = value
                OnPropertyChanged("Department")
            End Set
        End Property

        ' Function to get all departments from service
        Private Function GetAllDepartments() As IQueryable(Of Department)
            Return Me.dataAccess.GetAllDepartments
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._departments = New ObservableCollection(Of Department)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IDepartmentService)(New DepartmentService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IDepartmentService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllDepartments
                Me._departments.Add(element)
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
            Dim editar As New EditDepartment
            editar.ShowDialog()
            _departments.Clear()
            For Each element In Me.GetAllDepartments
                Me._departments.Add(element)
            Next
        End Sub

        Public Sub Eliminar()
            If Department IsNot Nothing Then
                dataAccess.DeleteDepartment(Department)
            Else
                MsgBox("Please select a department.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub

        Public Sub Editar()

        End Sub
    End Class
End Namespace

