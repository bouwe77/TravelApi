using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelApi.Models;

namespace TravelApi.Resources
{
   public class PersonResourceFactory
   {
      public static PersonResource Create(Person person)
      {
         var locationResource = LocationResourceFactory.Create(person.Location, false);

         var personResource = new PersonResource(person.Id)
         {
            Name = person.Name,
            Location = locationResource
         };

         return personResource;
      }
   }
}