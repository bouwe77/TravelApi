using TravelApi.Hypermedia;
using TravelApi.Models;

namespace TravelApi.Resources
{
   public class LocationResourceFactory
   {
      public static LocationResource Create(Location location, bool fullRepresentation, bool includeId)
      {
         var locationResource = new LocationResource(location.Id)
         {
            Name = location.Name
         };

         // IDs are typically used when locations are embedded resources for a HAL Form.
         if (includeId)
         {
            locationResource.Id = UriFactory.GetLocationUri(location.Id);
         }

         // The full representation contains all properties of the resource, typically only used when a specific location is requested
         if (fullRepresentation)
         {
            locationResource.WikipediaUrl = location.WikipediaUrl;
            //TODO destinations...
         }

         return locationResource;
      }

      public static LocationResource Create(Location location, bool fullRepresentation)
      {
         return Create(location, fullRepresentation, false);
      }

      public static LocationResource Create(Location location)
      {
         return Create(location, false, false);
      }
   }
}