using Dolores;
using Dolores.Http;
using Dolores.Responses;

namespace TravelApi.Handlers
{
   public class RootHandler : DoloresHandler
   {
      public Response Get()
      {
         var response = new Response(HttpStatusCode.Found);

         //TODO Deze moet uiteindelijk naar de resource die het startformulier heeft
         response.SetLocationHeaderByRouteIdentifier("AllPeople");

         return response;
      }
   }
}