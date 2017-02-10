using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TravelApi.Handlers
{
   /// <summary>
   /// JSON contract resolver to ensure property names are lower case.
   /// </summary>
   public class LowercaseContractResolver : DefaultContractResolver
   {
      protected override string ResolvePropertyName(string propertyName)
      {
         return propertyName.ToLower();
      }

      /// <summary>
      /// Factory method for providing JSON serializer settings containing the <see cref="LowercaseContractResolver"/>
      /// and some other convenient settings.
      /// </summary>
      /// <returns></returns>
      public static JsonSerializerSettings GetSettings()
      {
         return new JsonSerializerSettings
         {
            ContractResolver = new LowercaseContractResolver(),
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
         };
      }
   }
}
