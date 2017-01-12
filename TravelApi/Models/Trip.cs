using TravelApi.Repository;

namespace TravelApi.Models
{
   [Table("Trips")]
   public class Trip : Entity
   {
      public string PersonId { get; set; }

      [Ignore]
      public Person Person { get; set; }

      public string DestinationId { get; set; }
      
      [Ignore]
      public Destination Destination { get; set }
   }
}
