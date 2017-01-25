using TravelApi.Models;

namespace TravelApi.Resources
{
   public class LocationResourceFactory
   {
      public static LocationResource Create(Location location, bool fullRepresentation)
      {
         var locationResource = new LocationResource(location.Id)
         {
            Name = location.Name
         };

         if (fullRepresentation)
         {
            //TODO destinations...
         }

         return locationResource;
      }

      public static LocationResource Create(Location location)
      {
         return Create(location, false);
      }
   }
}