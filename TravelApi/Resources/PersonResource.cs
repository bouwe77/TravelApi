using Hal;
using Newtonsoft.Json;
using TravelApi.Hypermedia;

namespace TravelApi.Resources
{
   public class PersonResource : HalResource
   {
      public PersonResource(string personId)
         : base(new PersonLinks(personId))
      {
      }

      public string Name { get; set; }

      [JsonIgnore]
      public LocationResource Location { get; set; }

      public override object Embedded => new { Location };
   }
}
