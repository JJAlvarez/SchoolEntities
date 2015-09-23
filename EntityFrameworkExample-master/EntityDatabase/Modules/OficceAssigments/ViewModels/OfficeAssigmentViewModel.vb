Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OfficeAssigments.ViewModels
    Public Class OfficeAssigmentViewModel
        Inherits ViewModelBase

        Private _officeAssigments As ObservableCollection(Of OfficeAssignment)
        Private dataAccess As IOfficeAssigment

        Public Property OfficeAssignments As ObservableCollection(Of OfficeAssignment)
            Get
                Return Me._officeAssigments
            End Get
            Set(value As ObservableCollection(Of OfficeAssignment))
                Me._officeAssigments = value
                OnPropertyChanged("OfficeAssignments")
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
    End Class
End Namespace
