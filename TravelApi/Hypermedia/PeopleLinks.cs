using Bouwe.Hal;
using Newtonsoft.Json;

namespace TravelApi.Hypermedia
{
   class PeopleLinks : Links
   {
      public PeopleLinks()
         : base(UriFactory.GetPeopleUri())
      {
         CreatePerson = new Link(UriFactory.GetPeopleUri(), "Create person");
      }

      [JsonProperty(UriFactory.CreatePersonUri)]
      public Link CreatePerson { get; }
   }
}