using TravelApi.Sqlite;

namespace TravelApi.Models
{
   [Table("Trips")]
   public class Trip : Entity
   {
      public string PersonId { get; set; }

      [Ignore]
      public Person Person { get; set; }

      public string FromLocationId { get; set; }

      [Ignore]
      public Location FromLocation { get; set; }

      public string ToLocationId { get; set; }

      [Ignore]
      public Location ToLocation { get; set; }

      public string CreatedAt { get; set; }
   }
}