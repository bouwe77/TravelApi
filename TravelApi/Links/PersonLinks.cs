//TODO Let op dat deze Links classes alleen nodig zijn als er specifieke links zijn.
// Voor alleen een self link hoeft dit niet.

using Hal;

namespace TravelApi.Hypermedia
{
   public class PersonLinks : Links
   {
      public PersonLinks(string personId)
         : base(UriFactory.GetPersonUri(personId))
      {
      }
   }
}