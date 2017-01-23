using TravelApi.Sqlite;

namespace TravelApi.Models
{
   [Table("Trips")]
   public class Trip : Entity
   {
      public string PersonId { get; set; }

      [Ignore]
      public Person Person { get; set; }

      public string RouteId { get; set; }
      
      [Ignore]
      public Route Route { get; set; }
   }
}
