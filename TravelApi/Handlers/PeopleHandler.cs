using System;
using System.Collections.Generic;
using Dolores;
using Dolores.Exceptions;
using Dolores.Http;
using Dolores.Requests;
using Dolores.Responses;
using TravelApi.Models;
using TravelApi.Repository;

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
         //TODO case insensitivity testen van ID's

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
         //var person = Request.MessageBody.DeserializeJson<PersonThingy>();

         //// buts PersonThingy om naar person, dus bijvoorbeeld het locationId ook achterhalen

         //using (var repository = new SqliteRepository<Person>())
         //{
         //   repository.Insert(person);
         //}

         //var response = new Response(HttpStatusCode.Created);
         //response.SetLocationHeader("OnePerson", person.Id);

         //return response;

         return new Response(HttpStatusCode.NotImplemented);
      }
   }
}