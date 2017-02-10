using System;
using System.Collections.Generic;
using System.Linq;
using Dolores;
using Dolores.Exceptions;
using Dolores.Http;
using Dolores.Requests;
using Dolores.Responses;
using TravelApi.Hypermedia;
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

         var personResources = people.Select(PersonResourceFactory.Create);
         var peopleResource = new PeopleResource(personResources);

         var response = new Response(HttpStatusCode.Ok);
         response.Json(peopleResource);

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
            var personResource = PersonResourceFactory.Create(person);
            response = new Response(HttpStatusCode.Ok);
            response.Json(personResource);
         }

         return response;
      }

      // POST /people
      public Response Post()
      {
         var personData = Request.MessageBody.DeserializeJson<CreatePersonData>();

         bool valid = !string.IsNullOrWhiteSpace(personData.Name) && !string.IsNullOrWhiteSpace(personData.LocationId);
         if (!valid)
         {
            throw new HttpBadRequestException("Both Name and Location are required");
         }

         // Check location exists.
         using (var locationRepository = new SqliteRepository<Location>())
         {
            //TODO LocationId kan/mag een URI zijn, dus plitten op / en laatste segment pakken als LocationId
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
         response.SetLocationHeaderByRouteIdentifier("Person", personId);

         return response;
      }
   }
}
