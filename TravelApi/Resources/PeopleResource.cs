using System.Collections.Generic;
using Hal;
using Newtonsoft.Json;
using TravelApi.Hypermedia;

namespace TravelApi.Resources
{
   public class PeopleResource : HalResource
   {
      public PeopleResource(List<PersonResource> people)
         : base(new Links(UriFactory.GetPeopleUri()))
      {
         People = people;
      }

      [JsonIgnore]
      public List<PersonResource> People { get; }

      public override object Embedded => new { People };
   }
}