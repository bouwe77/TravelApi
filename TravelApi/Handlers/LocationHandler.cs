using System.Collections.Generic;
using System.Linq;
using Dolores;
using Dolores.Http;
using Dolores.Responses;
using TravelApi.Models;
using TravelApi.Resources;
using TravelApi.Sqlite;

namespace TravelApi.Handlers
{
   public class LocationHandler : DoloresHandler
   {
      // GET /locations
      public Response GetAll()
      {
         IEnumerable<Location> locations;
         using (var repository = new SqliteRepository<Location>())
         {
            locations = repository.GetAll();
         }

         var locationResources = locations.Select(LocationResourceFactory.Create);
         var locationsResource = new LocationCollectionResource(locationResources);

         var response = new Response(HttpStatusCode.Ok);
         response.Json(locationsResource);

         return response;
      }

      // GET /locations/{locationId}
      public Response GetOne(string locationId)
      {
         Location location;
         using (var repository = new SqliteRepository<Location>())
         {
            location = repository.GetById(locationId);
         }

         var response = new Response(HttpStatusCode.NotFound);
         if (location != null)
         {
            var locationResource = LocationResourceFactory.Create(location, true);
            response = new Response(HttpStatusCode.Ok);
            response.Json(locationResource);
         }

         return response;
      }
   }
}