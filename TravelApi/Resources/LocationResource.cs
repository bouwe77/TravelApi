using Hal;
using TravelApi.Hypermedia;

namespace TravelApi.Resources
{
   public class LocationResource : HalDocument
   {
      public LocationResource(string locationId)
         : base(new Links(UriFactory.GetLocationUri(locationId)))
      {
      }

      public string Id { get; set; }

      public string Name { get; set; }

      //TODO Eigenlijk moet de wikipedia URL een link zijn (dus LocationLinks class introduceren), maar het is even de vraag of de client daarmee om kan gaan qua GUI waar wat te tonen...
      public string WikipediaUrl { get; set; }

      //TODO Routes

      //public override object Embedded => new { Destinations };
   }
}
