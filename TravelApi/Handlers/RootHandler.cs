using Dolores;
using Dolores.Http;
using Dolores.Responses;

namespace TravelApi.Handlers
{
   public class RootHandler : DoloresHandler
   {
      // GET /
      public Response Get()
      {
         var response = new Response(HttpStatusCode.Found);

         response.SetLocationHeaderByRouteIdentifier("People");

         return response;
      }
   }
}