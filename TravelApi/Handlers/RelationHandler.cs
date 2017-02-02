using Bouwe.Hal;
using Dolores;
using Dolores.Exceptions;
using Dolores.Http;
using Dolores.Responses;
using TravelApi.Hypermedia;

namespace TravelApi.Handlers
{
   public class RelationHandler : DoloresHandler
   {
      public Response Get(string relationName)
      {
         HalForm halForm;
         bool found = HalFormProvider.TryFindHalForm(relationName, out halForm);
         if (!found)
         {
            throw new HttpNotFoundException($"Relation name '{relationName}' not found");
         }

         var response = new Response(HttpStatusCode.Ok);
         response.Json(halForm);
         response.SetContentTypeHeader("application/prs.hal-forms+json");

         return response;
      }
   }
}