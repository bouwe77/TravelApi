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
         else if (entity is Route)
         {
            ResolveRoute((Route)entity);
         }
         else if (entity is Trip)
         {
            ResolveTrip((Trip)entity);
         }
      }

      private void ResolveTrip(Trip trip)
      {
         trip.Person = GetPerson(trip.PersonId);
         trip.Route = GetRoute(trip.RouteId);
      }

      private void ResolveRoute(Route route)
      {
         route.FromLocation = GetLocation(route.FromLocationId);
         route.ToLocation = GetLocation(route.ToLocationId);
      }

      private void ResolvePerson(Person person)
      {
         person.Location = GetLocation(person.LocationId);
      }

      private Location GetLocation(string locationId)
      {
         using (var repository = new SqliteRepository<Location>())
         {
            return repository.GetById(locationId, false);
         }
      }

      private Person GetPerson(string personId)
      {
         using (var repository = new SqliteRepository<Person>())
         {
            return repository.GetById(personId, false);
         }
      }

      private Route GetRoute(string routeId)
      {
         using (var repository = new SqliteRepository<Route>())
         {
            return repository.GetById(routeId, false);
         }
      }
   }
}
