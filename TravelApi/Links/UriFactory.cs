namespace TravelApi.Hypermedia
{
   public class UriFactory
   {
      private static string GetUri(string uri, params object[] parameters)
      {
         string formattedUri = string.Format(uri, parameters);
         return $"http://localhost:32456{formattedUri}";
      }

      public static string GetPeopleUri()
      {
         string uri = GetUri("/people");
         return uri;
      }

      public static string GetPersonUri(string personId)
      {
         string uri = GetUri("/people/{0}", personId);
         return uri;
      }

      public static string GetLocationUri(string locationName)
      {
         string uri = GetUri("/locations/{0}", locationName);
         return uri;
      }

      /// <summary>
      /// Returns a templated rels URI, to be used with curies.
      /// </summary>
      /// <returns>The rels URI.</returns>
      public static string GetRelationsUri()
      {
         string uri = GetUri("/rels/{{rel}}");
         return uri;
      }

      /// <summary>
      /// Returns a rels URI with the given relations name, typically to be used with HAL Forms.
      /// </summary>
      /// <returns>The rels URI.</returns>
      public static string GetRelationsUri(string relationName)
      {
         string uri = GetUri($"/rels/{relationName}");
         return uri;
      }
   }
}