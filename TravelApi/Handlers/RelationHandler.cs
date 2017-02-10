using System.Linq;
using Hal;
using Dolores;
using Dolores.Exceptions;
using Dolores.Http;
using Dolores.Responses;
using TravelApi.Hypermedia;
using TravelApi.Models;
using TravelApi.Resources;
using TravelApi.Sqlite;

namespace TravelApi.Handlers
{
   public class RelationHandler : DoloresHandler
   {
      public Response Get(string relationName)
      {
         HalForm halForm;
         bool found = TryFindHalForm(relationName, out halForm);
         if (!found)
         {
            throw new HttpNotFoundException($"Relation name '{relationName}' not found");
         }

         var response = new Response(HttpStatusCode.Ok);
         response.Json(halForm);
         response.SetContentTypeHeader("application/prs.hal-forms+json");

         return response;
      }

      private bool TryFindHalForm(string relationName, out HalForm halForm)
      {
         halForm = null;
         bool found = false;

         switch (relationName)
         {
            case RelationNames.CreatePerson:
               found = true;
               using (var locationRepository = new SqliteRepository<Location>())
               {
                  var locations = locationRepository.GetAll(false);
                  var locationResources = locations.Select(GetLocationResource);
                  halForm = new CreatePersonForm(locationResources);
               }
               break;
         }

         return found;
      }

      private LocationResource GetLocationResource(Location location)
      {
         return LocationResourceFactory.Create(location, false, true);
      }
   }
}