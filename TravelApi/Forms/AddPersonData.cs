using System;
using Newtonsoft.Json;

namespace TravelApi.Resources
{
   /// <summary>
   /// When adding a Person via POST, the JSON of the POST request must be serialized to this class.
   /// </summary>
   public class AddPersonData
   {
      public string Name { get; set; }

      [JsonProperty("Location")]
      public string LocationUri { get; set; }

      public string GetLocationId()
      {
         //TODO Get the Location Id from the Location URI
         throw new NotImplementedException();
      }
   }
}