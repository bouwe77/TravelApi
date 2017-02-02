namespace TravelApi.Hypermedia
{
   public static class UriFactory
   {
      public const string HostUri = "http://localhost:32456";
      public const string CreatePersonUri = HostUri + "/rels/create-person";
      public const string PeopleUri = HostUri + "/people";
      public const string LocationsUri = HostUri + "/locations";

      public static string GetPeopleUri()
      {
         return PeopleUri;
      }

      public static string GetPersonUri(string personId)
      {
         return $"{PeopleUri}/{personId}";
      }

      public static string GetLocationUri(string locationId)
      {
         return $"{LocationsUri}/{locationId}";
      }

      public static string GetLocationCollectionUri()
      {
         return LocationsUri;
      }
   }
}