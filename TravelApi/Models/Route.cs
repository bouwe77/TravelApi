using TravelApi.Sqlite;

namespace TravelApi.Models
{
   [Table("Routes")]
   public class Route : Entity
   {
      public string FromLocationId { get; set; }

      [Ignore]
      public Location FromLocation { get; set; }
      
      public string ToLocationId { get; set; }

      [Ignore]
      public Location ToLocation { get; set; }
      
      public string Transportation { get; set; }

      //TODO Distance in KM
      //TODO Direction (north, north east, north west, etc.)
   }
}
