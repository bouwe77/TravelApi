using TravelApi.Sqlite;

namespace TravelApi.Models
{
   [Table("Locations")]
   public class Location : Entity
   {
      [Unique]
      public string Name { get; set; }
      
      public string WikipediaUrl { get; set; }
   }
}
