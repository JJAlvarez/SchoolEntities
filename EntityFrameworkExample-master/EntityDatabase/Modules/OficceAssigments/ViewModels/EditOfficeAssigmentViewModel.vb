Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel
Imports BusinessObjects.Helpers

Namespace Modules.OficceAssigment.ViewModels
    Public Class EditOfficeAssigmentViewModel
        Inherits ViewModelBase

        Private _dataAccess As IOfficeAssigment
        Private _agregar As ICommand
        Private _ventana As EditOfficeAssigment
        Private _personas As ObservableCollection(Of Person)
        Private _persona As Person
        Private _location As String
        Private opcion As String
        Private officeAssigment As OfficeAssignment

        Public Sub New(ventana As EditOfficeAssigment, opcion As String, officeAssigment As OfficeAssignment)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOfficeAssigment)(New OfficeAssigmentService)
            ' Initialize dataAccess from service
            Me._dataAccess = GetService(Of IOfficeAssigment)()
            _personas = New ObservableCollection(Of Person)
            Dim listaPersonas As IQueryable(Of Person) = DataContext.DBEntities.Person
            For Each element In listaPersonas
                _personas.Add(element)
            Next
            Me.opcion = opcion
            Me.officeAssigment = officeAssigment
            If opcion = "Editar" Then
                Location = officeAssigment.Location
                Persona = officeAssigment.Person
                Personas.Clear()
                Personas.Add(Persona)
            End If
            ' Populate departments property variable 
            _ventana = ventana
        End Sub

        Public Property Location As String
            Get
                Return _location
            End Get
            Set(value As String)
                _location = value
                OnPropertyChanged("Location")
            End Set
        End Property

        Public Property Persona As Person
            Get
                Return _persona
            End Get
            Set(value As Person)
                _persona = value
                OnPropertyChanged("Persona")
            End Set
        End Property

        Public Property Personas As ObservableCollection(Of Person)
            Get
                Return _personas
            End Get
            Set(value As ObservableCollection(Of Person))
                _personas = value
                OnPropertyChanged("Personas")
            End Set
        End Property

        Public ReadOnly Property ButtonAgregar
            Get
                If _agregar Is Nothing Then
                    If opcion = "Editar" Then
                        _agregar = New RelayCommand(AddressOf Editar)
                    Else
                        _agregar = New RelayCommand(AddressOf Agregar)
                    End If

                End If
                Return _agregar
            End Get
        End Property

        Public Sub Agregar()
            If Location <> Nothing And Persona IsNot Nothing Then
                Dim officeAssigment As New OfficeAssignment
                officeAssigment.Location = Location
                officeAssigment.InstructorID = Persona.PersonID
                _dataAccess.CreateOfficeAssigment(officeAssigment)
                MsgBox("Office Assigment succesful created.", MsgBoxStyle.Information, "School")
                _ventana.Close()
            Else
                MsgBox("Ingrese todos los datos", MsgBoxStyle.Information, "School")
            End If

        End Sub

        Public Sub Editar()
            If Location <> Nothing And Persona IsNot Nothing Then
                Dim officeAssigment As New OfficeAssignment
                officeAssigment.Location = Location
                officeAssigment.InstructorID = Persona.PersonID
                _dataAccess.EditOfficeAssigment(Me.officeAssigment, officeAssigment)
                MsgBox("Office Assigment succesful edited.", MsgBoxStyle.Information, "School")
                _ventana.Close()
            Else
                MsgBox("Ingrese todos los datos", MsgBoxStyle.Information, "School")
            End If

        End Sub
    End Class
End Namespace

