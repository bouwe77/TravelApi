using TravelApi.Repository;

namespace TravelApi.Models
{
   [Table("Destinations")]
   public class Destination : Entity
   {
      public string LocationId { get; set; }

      [Ignore]
      public Location Location { get; set; }

      //TODO enum as string
      public string TransportationId { get; set; }

      [Ignore]
      public Transportation Transportation { get; set; }
   }
}