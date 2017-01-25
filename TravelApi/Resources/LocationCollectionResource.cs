using System.Collections.Generic;
using Hal;
using Newtonsoft.Json;
using TravelApi.Hypermedia;

namespace TravelApi.Resources
{
   public class LocationCollectionResource : HalResource
   {
      public LocationCollectionResource(IEnumerable<LocationResource> locations)
         : base(new Links(UriFactory.GetLocationCollectionUri()))
      {
         Locations = locations;
      }

      [JsonIgnore]
      public IEnumerable<LocationResource> Locations { get; }

      public override object Embedded => new { Locations };
   }
}