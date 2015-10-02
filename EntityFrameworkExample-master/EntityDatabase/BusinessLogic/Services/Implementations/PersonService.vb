Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers

Namespace BusinessLogic.Services.Implementations
    Public Class PersonService
        Implements IPersonService

        Public Function GetAllPersons() As IQueryable(Of Person) Implements IPersonService.GetAllPersons
            Return (From p In DataContext.DBEntities.Person)
        End Function

        Public Sub CreatePerson(person As Person) Implements IPersonService.CreatePerson
            DataContext.DBEntities.Person.Add(person)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub DeletePerson(person As Person) Implements IPersonService.DeletePerson
            DataContext.DBEntities.Person.Remove(person)
            DataContext.DBEntities.SaveChanges()
        End Sub

        Public Sub EditPerson(person As Person) Implements IPersonService.EditPerson
            Dim personE = (From p In DataContext.DBEntities.Person Where p.PersonID = person.PersonID).FirstOrDefault
            personE.FirstName = person.FirstName
            personE.LastName = person.LastName
            personE.HireDate = person.HireDate
            personE.EnrollmentDate = person.EnrollmentDate
            DataContext.DBEntities.SaveChanges()
        End Sub
    End Class
End Namespace

