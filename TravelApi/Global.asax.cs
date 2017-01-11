//TODO Reference naar HAL via reusables ipv FMG2
//TODO SQLite repo uit de Monitoring tool halen?
using System;
using Dolores.Configuration;

namespace TravelApi
{
   public class Global : System.Web.HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         DoloresConfig.AddRoute(
            routeIdentifier: "AllPeople",
            uriTemplate: "/people",
            get: new GetMethodSettings { Type = "TravelApi.Handlers.PeopleHandler, TravelApi", MethodName = "GetAll" },
            post: null,
            put: null,
            delete: null,
            patch: null,
            head: null,
            options: null);

         DoloresConfig.AddRoute(
            routeIdentifier: "OnePerson",
            uriTemplate: "/people/{id}",
            get: new GetMethodSettings { Type = "TravelApi.Handlers.PeopleHandler, TravelApi", MethodName = "GetOne" },
            post: null,
            put: null,
            delete: null,
            patch: null,
            head: null,
            options: null);

      }
   }
}