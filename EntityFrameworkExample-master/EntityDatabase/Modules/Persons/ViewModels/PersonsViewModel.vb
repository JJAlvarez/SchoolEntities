Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel
Imports Modules.Persons.Views

Namespace Modules.Persons.ViewModels
    Public Class PersonsViewModel
        Inherits ViewModelBase

        Private _Persons As ObservableCollection(Of Person)
        Private dataAccess As IPersonService
        Private _person As Person
        Private _agregar As ICommand
        Private _eliminar As ICommand
        Private _editar As ICommand

        Public Property Persons As ObservableCollection(Of Person)
            Get
                Return Me._Persons
            End Get
            Set(value As ObservableCollection(Of Person))
                Me._Persons = value
                OnPropertyChanged("Persons")
            End Set
        End Property

        Public Property Person As Person
            Get
                Return Me._person
            End Get
            Set(value As Person)
                Me._person = value
                OnPropertyChanged("Person")
            End Set
        End Property

        ' Function to get all departments from service
        Private Function GetAllPersons() As IQueryable(Of Person)
            Return Me.dataAccess.GetAllPersons
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._Persons = New ObservableCollection(Of Person)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IPersonService)(New PersonService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IPersonService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllPersons
                Me._Persons.Add(element)
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
            Dim editar As New EditPerson("Agregar", Person)
            editar.ShowDialog()
            _Persons.Clear()

            For Each element In Me.GetAllPersons
                _Persons.Add(element)
            Next
        End Sub

        Public Sub Eliminar()
            If Person IsNot Nothing Then
                dataAccess.DeletePerson(Person)
            Else
                MsgBox("Please select a Person.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub

        Public Sub Editar()
            If Person IsNot Nothing Then
                Dim editar As New EditPerson("Editar", Person)
                editar.ShowDialog()
                _Persons.Clear()

                For Each element In Me.GetAllPersons
                    _Persons.Add(element)
                Next
            Else
                MsgBox("Please select a Person.", MsgBoxStyle.Critical, "School System")
            End If
        End Sub
    End Class
End Namespace
