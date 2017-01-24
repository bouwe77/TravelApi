using Hal;
using TravelApi.Hypermedia;

namespace TravelApi.Resources
{
   public class LocationResource : HalResource
   {
      public LocationResource(string locationId)
         : base(new LocationLinks(locationId))
      {
      }

      public string Name { get; set; }

      //TODO Routes

      //public override object Embedded => new { Destinations };
   }
}
