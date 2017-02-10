using System.Collections.Generic;
using System.Net.Http;
using Hal;
using Newtonsoft.Json;
using TravelApi.Resources;

namespace TravelApi.Hypermedia
{
   public class CreatePersonForm : HalForm
   {
      public CreatePersonForm(IEnumerable<LocationResource> locations)
         : base(UriFactory.CreatePersonUri, GetDefaultTemplate())
      {
         Locations = locations;
      }

      private static DefaultTemplate GetDefaultTemplate()
      {
         var defaultTemplate = new DefaultTemplate
         {
            Title = "Create person",
            Method = HttpMethod.Post.ToString()
         };

         var property = new Property("name")
         {
            Prompt = "Name",
            Required = true,
            Value = string.Empty
         };
         defaultTemplate.AddProperty(property);

         var locationSuggestion = new Suggestion("locations", "id", "name");

         property = new Property("location")
         {
            Prompt = "Location",
            Required = true,
            Suggest = locationSuggestion
         };

         defaultTemplate.AddProperty(property);

         return defaultTemplate;
      }

      [JsonIgnore]
      public IEnumerable<LocationResource> Locations { get; }

      public override object Embedded => new { Locations };
   }
}