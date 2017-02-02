using System;
using System.Collections.Generic;
using System.Net.Http;
using Bouwe.Hal;

namespace TravelApi.Hypermedia
{
   public class HalFormProvider
   {
      private static readonly Dictionary<string, Func<HalForm>> Forms = new Dictionary<string, Func<HalForm>>
      {
         { RelationNames.CreatePerson, GetCreatePersonForm }
      };

      public static bool TryFindHalForm(string formName, out HalForm halForm)
      {
         halForm = null;

         Func<HalForm> halFormFunc;
         bool found = Forms.TryGetValue(formName, out halFormFunc);
         if (found)
         {
            halForm = halFormFunc.Invoke();
         }

         return found;
      }

      private static HalForm CreateHalForm(string selfHref, DefaultTemplate defaultTemplate)
      {
         var template = new Template(defaultTemplate);
         var halForm = new HalForm(selfHref, template);
         return halForm;
      }

      private static HalForm GetCreatePersonForm()
      {
         var defaultTemplate = new DefaultTemplate
         {
            Title = "Create person",
            Method = HttpMethod.Post.ToString()
         };

         var property = new Property("name")
         {
            Prompt = "Name",
            Required = true,
            Value = string.Empty
         };
         defaultTemplate.AddProperty(property);

         property = new Property("location")
         {
            Prompt = "Location",
            Required = true
            //TODO Hier "suggest" implementeren, zie https://github.com/mamund/hal-forms/issues/9
         };
         defaultTemplate.AddProperty(property);

         return CreateHalForm(UriFactory.CreatePersonUri, defaultTemplate);
      }
   }
}