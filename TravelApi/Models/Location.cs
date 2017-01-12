using TravelApi.Repository;

namespace TravelApi.Models
{
   [Table("Locations")]
   public class Location : Entity
   {
      public string Name { get; set; }
   }
}
