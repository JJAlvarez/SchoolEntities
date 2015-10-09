Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers

Namespace BusinessLogic.Services.Implementations
    Public Class OfficeAssigmentService
        Implements IOfficeAssigment

        Public Function GetAllOfficeAssigments() As IQueryable(Of OfficeAssignment) Implements IOfficeAssigment.GetAllOfficeAssigments
            Return DataContext.DBEntities.OfficeAssignments
        End Function

        Public Sub CreateOfficeAssigment(oAssigment As OfficeAssignment) Implements IOfficeAssigment.CreateOfficeAssigment
            DataContext.DBEntities.OfficeAssignments.Add(oAssigment)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub DeleteOfficeAssigment(oAssigment As OfficeAssignment) Implements IOfficeAssigment.DeleteOfficeAssigment
            DataContext.DBEntities.OfficeAssignments.Remove(oAssigment)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub EditOfficeAssigment(oAssigment As OfficeAssignment, oAssigmentE As OfficeAssignment) Implements IOfficeAssigment.EditOfficeAssigment
            oAssigment = (From oa In DataContext.DBEntities.OfficeAssignments
                          Where oa.InstructorID = oAssigment.InstructorID And oa.Location = oAssigment.Location).FirstOrDefault
            oAssigment.InstructorID = oAssigmentE.InstructorID
            oAssigment.Location = oAssigmentE.Location
            DataContext.DBEntities.SaveChanges()
        End Sub
    End Class
End Namespace

