Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.Persons.ViewModels
    Public Class PersonsViewModel
        Inherits ViewModelBase

        Private _Persons As ObservableCollection(Of Person)
        Private dataAccess As IPersonService

        Public Property Persons As ObservableCollection(Of Person)
            Get
                Return Me._Persons
            End Get
            Set(value As ObservableCollection(Of Person))
                Me._Persons = value
                OnPropertyChanged("Persons")
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
    End Class
End Namespace
