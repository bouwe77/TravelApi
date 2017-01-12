using TravelApi.Sqlite;

namespace TravelApi.Models
{
   [Table("Locations")]
   public class Location : Entity
   {
      public string Name { get; set; }
      
      public string WikipediaUrl { get; set; }
   }
}
