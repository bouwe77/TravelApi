using System.Collections.Generic;
using Hal;
using Newtonsoft.Json;
using TravelApi.Hypermedia;

namespace TravelApi.Resources
{
   public class PeopleResource : HalDocument
   {
      public PeopleResource(IEnumerable<PersonResource> people)
         : base(new PeopleLinks())
      {
         People = people;
      }

      [JsonIgnore]
      public IEnumerable<PersonResource> People { get; }

      public override object Embedded => new { People };
   }
}