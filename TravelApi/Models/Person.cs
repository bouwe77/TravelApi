using TravelApi.Sqlite;

namespace TravelApi.Models
{
   [Table("People")]
   public class Person : Entity
   {
      public string Name { get; set; }

      public string LocationId { get; set; }

      [Ignore]
      public Location Location { get; set; }
   }
}