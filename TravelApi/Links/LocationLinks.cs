using Hal;

namespace TravelApi.Hypermedia
{
   public class LocationLinks : Links
   {
      public LocationLinks(string locationId)
         : base(UriFactory.GetLocationUri(locationId))
      {
      }
   }
}