using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using TravelApi.Models;

namespace TravelApi.Sqlite
{
   public class DatabaseCreator
   {
      private readonly SQLiteConnection _sqliteConnection;

      public DatabaseCreator(string connectionString)
      {
         // Connect to the database.
         _sqliteConnection = new SQLiteConnection(connectionString);
      }

      public void CreateDatabase()
      {
         // Create all tables if necessary.
         _sqliteConnection.CreateTable<Person>();
         _sqliteConnection.CreateTable<Location>();
         _sqliteConnection.CreateTable<Trip>();
         _sqliteConnection.CreateTable<Route>();

         // Insert data into the Locations and Routes tables.
         InsertLocations();
         InsertRoutes();
      }

      private void InsertRoutes()
      {
         var routes = GetFromCsv<Route, RouteMap>("Routes.csv");
         _sqliteConnection.InsertAll(routes);
      }

      private void InsertLocations()
      {
         IEnumerable<Location> locations = GetFromCsv<Location, LocationMap>("Locations.csv");
         _sqliteConnection.InsertAll(locations);
      }

      private static List<TEntity> GetFromCsv<TEntity, TMapping>(string filename) where TEntity : Entity where TMapping : CsvClassMap
      {
         IEnumerable<TEntity> records;
         using (var textReader = File.OpenText($@"D:\Mijn Projecten\TravelApi\TravelApi\CSV\{filename}"))
         {
            var csvReader = new CsvReader(textReader);
            csvReader.Configuration.TrimHeaders = true;
            csvReader.Configuration.TrimFields = true;
            csvReader.Configuration.RegisterClassMap<TMapping>();
            records = csvReader.GetRecords<TEntity>().ToList();
         }

         foreach (var record in records)
         {
            record.LastModified = GetLastModified();
         }

         return records.ToList();
      }

      private static string GetLastModified()
      {
         return DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
      }
   }

   public sealed class LocationMap : CsvClassMap<Location>
   {
      public LocationMap()
      {
         Map(m => m.Name).Name("Name");
         Map(m => m.WikipediaUrl).Name("WikipediaUrl");
      }
   }

   public sealed class RouteMap : CsvClassMap<Route>
   {
      public RouteMap()
      {
         Map(m => m.FromLocation).Name("FromLocation");
         Map(m => m.ToLocation).Name("ToLocation");
         Map(m => m.Transportation).Name("Transportation");
      }
   }
}