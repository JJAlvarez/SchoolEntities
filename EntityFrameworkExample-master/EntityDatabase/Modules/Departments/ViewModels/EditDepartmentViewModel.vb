Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel
Imports BusinessObjects.Helpers
Imports Modules.Departments.Views

Namespace Modules.Departments.ViewModels
    Public Class EditDepartmentViewModel
        Inherits ViewModelBase

        Private _dataAccess As IDepartmentService
        Private _agregar As ICommand
        Private _ventana As EditDepartment
        Private _name As String
        Private _budget As String
        Private _startDate As Date

        Public Sub New(ventana As EditDepartment)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IDepartmentService)(New DepartmentService)
            ' Initialize dataAccess from service
            Me._dataAccess = GetService(Of IDepartmentService)()
            ' Populate departments property variable 
            _ventana = ventana
        End Sub

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
                OnPropertyChanged("Name")
            End Set
        End Property

        Public Property Budget As String
            Get
                Return _budget
            End Get
            Set(value As String)
                _budget = value
                OnPropertyChanged("Budget")
            End Set
        End Property

        Public Property StartDate As Date
            Get
                Return _startDate
            End Get
            Set(value As Date)
                _startDate = value
                OnPropertyChanged("StartDate")
            End Set
        End Property

        Public ReadOnly Property ButtonAgregar
            Get
                If _agregar Is Nothing Then
                    _agregar = New RelayCommand(AddressOf Agregar)
                End If
                Return _agregar
            End Get
        End Property

        Public Sub Agregar()
            If Name <> Nothing And Budget <> Nothing Then
                Dim department As New Department
                Dim departments As IQueryable(Of Department) = DataContext.DBEntities.Departments
                department.Name = Name
                department.DepartmentID = departments.ToArray.Length * 2
                department.Administrator = departments.ToArray.Length * 5
                department.Budget = Budget
                department.StartDate = DateTime.Today
                _dataAccess.CreateDepartment(department)
                MsgBox("Departement succesful created.", MsgBoxStyle.Information, "School")
                _ventana.Close()
            Else
                MsgBox("Ingrese todos los datos", MsgBoxStyle.Information, "School")
            End If

        End Sub

    End Class
End Namespace

