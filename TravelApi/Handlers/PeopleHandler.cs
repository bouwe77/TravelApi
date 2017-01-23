using System;
using System.Collections.Generic;
using Dolores;
using Dolores.Exceptions;
using Dolores.Http;
using Dolores.Requests;
using Dolores.Responses;
using TravelApi.Models;
using TravelApi.Resources;
using TravelApi.Sqlite;

namespace TravelApi.Handlers
{
   public class PeopleHandler : DoloresHandler
   {
      // GET /people
      public Response GetAll()
      {
         IEnumerable<Person> people;
         using (var repository = new SqliteRepository<Person>())
         {
            people = repository.GetAll();
         }

         var response = new Response(HttpStatusCode.Ok);
         response.Json(people);

         return response;
      }

      // GET /people/{personId}
      public Response GetOne(string personId)
      {
         Person person;
         using (var repository = new SqliteRepository<Person>())
         {
            person = repository.GetById(personId);
         }

         var response = new Response(HttpStatusCode.NotFound);
         if (person != null)
         {
            response = new Response(HttpStatusCode.Ok);
            response.Json(person);
         }

         return response;
      }

      // POST /people
      public Response Post()
      {
         var personData = Request.MessageBody.DeserializeJson<AddPersonData>();

         // Check location exists.
         using (var locationRepository = new SqliteRepository<Location>())
         {
            var location = locationRepository.GetById(personData.LocationId);
            if (location == null)
            {
               throw new HttpBadRequestException($"LocationId '{personData.LocationId}' does not exist");
            }
         }

         // Insert person.
         string personId;
         using (var repository = new SqliteRepository<Person>())
         {
            var person = new Person { Name = personData.Name, LocationId = personData.LocationId };
            personId = person.Id;
            repository.Insert(person);
         }

         var response = new Response(HttpStatusCode.Created);
         response.SetLocationHeaderByRouteIdentifier("OnePerson");

         return response;
      }
   }
}