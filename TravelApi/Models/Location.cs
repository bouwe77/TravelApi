using TravelApi.Sqlite;

namespace TravelApi.Models
{
   [Table("Locations")]
   public class Location : Entity
   {
      public string Name { get; set; }

      //TODO SQLite public IEnumerable<Destination> Destinations { get; set; }
   }
}