using System.IO;
using Dolores;
using Dolores.Http;
using Dolores.Responses;

namespace Portal.Handlers
{
   public class Handler : DoloresHandler
   {
      public Response Get()
      {
         var response = new Response(HttpStatusCode.Ok);

         string filePath = @"D:\Mijn Projecten\TravelApi\TravelApi\Portal\Views\index.view";
         //TODO Eigenlijk hier de filestream in stoppen
         response.Html(File.ReadAllText(filePath));

         return response;
      }
   }
}