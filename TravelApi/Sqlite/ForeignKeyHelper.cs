using TravelApi.Models;

namespace TravelApi.Sqlite
{
   /// <summary>
   /// TODO comment this
   /// </summary>
   internal class ForeignKeyHelper
   {
      public void Resolve(Entity entity)
      {
         if (entity is Person)
         {
            ResolvePerson((Person)entity);
         }
         else if (entity is Location)
         {
            ResolveLocation((Location)entity);
         }
         else if (entity is Destination)
         {
            ResolveDestination((Destination)entity);
         }
         else if (entity is Trip)
         {
            ResolveTrip((Trip)entity);
         }
      }

      private void ResolveTrip(Trip trip)
      {
         trip.Person = GetPerson(trip.PersonId);
         trip.FromLocation = GetLocation(trip.FromLocationId);
         trip.ToLocation = GetLocation(trip.ToLocationId);
      }

      private void ResolveDestination(Destination destination)
      {
         destination.Location = GetLocation(destination.LocationId);
         //TODO destination.Transportation
      }

      private void ResolveLocation(Location location)
      {
         //TODO location.Destinations
      }

      private void ResolvePerson(Person person)
      {
         person.Location = GetLocation(person.LocationId);
      }

      private Location GetLocation(string locationId)
      {
         using (var repository = new SqliteRepository<Location>())
         {
            return repository.GetById(locationId);
         }
      }

      private Person GetPerson(string personId)
      {
         using (var repository = new SqliteRepository<Person>())
         {
            return repository.GetById(personId);
         }
      }
   }
}