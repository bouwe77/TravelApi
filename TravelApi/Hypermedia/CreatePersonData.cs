namespace TravelApi.Hypermedia
{
   /// <summary>
   /// When creating a Person via POST, the JSON of the POST request must be serialized to this class.
   /// </summary>
   public class CreatePersonData
   {
      public string Name { get; set; }

      public string Location { get; set; }
   }
}