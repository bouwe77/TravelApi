using System;
using Dolores.Configuration;
using Dolores.Http;
using Dolores.Responses;
using TravelApi.Handlers;

namespace TravelApi
{
   public class Global : System.Web.HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         DoloresConfig.ErrorDetailsInResponses = ErrorResponseDetails.All;

         DoloresConfig.JsonSerializerSettings = LowercaseContractResolver.GetSettings();

         DoloresConfig.Route(routeIdentifier: "Root", uriTemplate: "")
            .Get(type: "TravelApi.Handlers.RootHandler, TravelApi", classMethod: "Get");

         DoloresConfig.Route(routeIdentifier: "People", uriTemplate: "/people")
            .Get(type: "TravelApi.Handlers.PeopleHandler, TravelApi", classMethod: "GetAll")
            .Post(type: "TravelApi.Handlers.PeopleHandler, TravelApi", classMethod: "Post");

         DoloresConfig.Route(routeIdentifier: "Person", uriTemplate: "/people/{id}")
            .Get(type: "TravelApi.Handlers.PeopleHandler, TravelApi", classMethod: "GetOne");

         DoloresConfig.Route(routeIdentifier: "Locations", uriTemplate: "/locations")
            .Get(type: "TravelApi.Handlers.LocationHandler, TravelApi", classMethod: "GetAll");

         DoloresConfig.Route(routeIdentifier: "Location", uriTemplate: "/locations/{id}")
            .Get(type: "TravelApi.Handlers.LocationHandler, TravelApi", classMethod: "GetOne");

         DoloresConfig.Route(routeIdentifier: "Relation", uriTemplate: "/rels/{id}")
            .Get(type: "TravelApi.Handlers.RelationHandler, TravelApi", classMethod: "Get");

         DoloresConfig.OnSendResponse((request, response) =>
         {
            response.SetHeader(HttpResponseHeaderFields.AccessControlAllowOrigin, "*");
         });
      }
   }
}