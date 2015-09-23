﻿Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers

Namespace BusinessLogic.Services.Implementations
    Public Class OfficeAssigmentService
        Implements IOfficeAssigment

        Public Function GetAllOfficeAssigments() As IQueryable(Of OfficeAssignment) Implements IOfficeAssigment.GetAllOfficeAssigments
            Return DataContext.DBEntities.OfficeAssignments
        End Function

    End Class
End Namespace

