Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Interfaces
Imports BusinessLogic.Services.Implementations
Imports BusinessObjects.Helpers
Imports Modules.Persons.Views

Namespace Modules.Persons.ViewModels
    Public Class EditPersonViewModel
        Inherits ViewModelBase

        Private _firstName As String
        Private _lastName As String
        Private _enrollmentDate As Date
        Private _hireDate As Date
        Private _dataAcces As IPersonService
        Private _aceptar As ICommand
        Private _ventana As EditPerson
        Private opcion As String
        Private persona As Person

        Public Property FirstName As String
            Get
                Return _firstName
            End Get
            Set(value As String)
                _firstName = value
                OnPropertyChanged("FirstName")
            End Set
        End Property

        Public Property LastName As String
            Get
                Return _lastName
            End Get
            Set(value As String)
                _lastName = value
                OnPropertyChanged("LastName")
            End Set
        End Property

        Public Property EnrollmentDate As Date
            Get
                Return _enrollmentDate
            End Get
            Set(value As Date)
                _enrollmentDate = value
                OnPropertyChanged("EnrollmentDate")
            End Set
        End Property

        Public Property HireDate As Date
            Get
                Return _hireDate
            End Get
            Set(value As Date)
                _hireDate = value
                OnPropertyChanged("HireDate")
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
            If FirstName <> Nothing And LastName <> Nothing Then
                Dim person As New Person
                person.PersonID = (From p In DataContext.DBEntities.Person).ToArray.Length + 1
                person.FirstName = FirstName
                person.LastName = LastName
                person.HireDate = HireDate
                person.EnrollmentDate = EnrollmentDate
                _dataAcces.CreatePerson(person)
                _ventana.Close()
                MsgBox("Person succesful created.", MsgBoxStyle.Information, "School")
            Else
                MsgBox("Please insert all the information.", MsgBoxStyle.Exclamation, "School")
            End If
        End Sub

        Public Sub EditarButton()
            If FirstName <> Nothing And LastName <> Nothing Then
                Dim person As New Person
                person.PersonID = persona.PersonID
                person.FirstName = FirstName
                person.LastName = LastName
                person.HireDate = HireDate
                person.EnrollmentDate = EnrollmentDate
                _dataAcces.EditPerson(person)
                _ventana.Close()
                MsgBox("Person succesful edited.", MsgBoxStyle.Information, "School")
            Else
                MsgBox("Please insert all the information.", MsgBoxStyle.Exclamation, "School")
            End If
        End Sub

        Public Sub New(ventana As EditPerson, opcion As String, persona As Person)
            ServiceLocator.RegisterService(Of IPersonService)(New PersonService)
            ' Initialize dataAccess from service
            _dataAcces = GetService(Of IPersonService)()
            _ventana = ventana
            Me.opcion = opcion
            Me.persona = persona
            If opcion = "Editar" Then
                FirstName = persona.FirstName
                LastName = persona.LastName
                If persona.HireDate IsNot Nothing Then
                    HireDate = persona.HireDate
                End If
                If persona.EnrollmentDate IsNot Nothing Then
                    EnrollmentDate = persona.EnrollmentDate
                End If
            Else
                EnrollmentDate = Date.Today
                HireDate = Date.Today
            End If
        End Sub
    End Class
End Namespace

