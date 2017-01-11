using Hal;
using TravelApi.Hypermedia;

namespace TravelApi.Resources
{
   public class LocationResource : HalResource
   {
      public LocationResource(string teamId)
         : base(new LocationLinks(teamId))
      {
      }

      public string Name { get; set; }

      //TODO Destinations

      //public override object Embedded => new { Destinations };
   }
}
