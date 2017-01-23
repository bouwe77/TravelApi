using System;
using Dolores.Configuration;

namespace Portal
{
   public class Global : System.Web.HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         DoloresConfig.AddRoute(
            routeIdentifier: "Root",
            uriTemplate: "*",
            get: new GetMethodSettings { Type = "Portal.Handlers.Handler, Portal", MethodName = "Get" },
            post: null,
            put: null,
            delete: null,
            patch: null,
            head: null,
            options: null);
      }
   }
}