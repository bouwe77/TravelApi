using TravelApi.Repository;

namespace TravelApi.Models
{
   [Table("Destinations")]
   public class Destination : Entity
   {
      public string FromLocationId { get; set; }

      [Ignore]
      public Location FromLocation { get; set; }
      
      public string ToLocationId { get; set; }

      [Ignore]
      public Location ToLocation { get; set; }
      
      public string Transportation { get; set; }
   }
}
