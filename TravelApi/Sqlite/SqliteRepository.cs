using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using TravelApi.Models;

namespace TravelApi.Sqlite
{
   public class SqliteRepository<TEntity> : IDisposable where TEntity : Entity, new()
   {
      private readonly SQLiteConnection _sqliteConnection;
      private readonly ForeignKeyHelper _foreignKeyHelper;

      public SqliteRepository()
      {
         const string connectionString = @"D:\Mijn Databases\Sqlite\TravelApi\database.db";

         // Connect to the database.
         _sqliteConnection = new SQLiteConnection(connectionString);

         // Create the table if necessary.
         _sqliteConnection.CreateTable<TEntity>();

         _foreignKeyHelper = new ForeignKeyHelper();
      }

      public IEnumerable<TEntity> GetAll(bool resolveForeignKeys = true)
      {
         var entities = _sqliteConnection.Table<TEntity>().ToList();

         if (resolveForeignKeys)
         {
            foreach (var entity in entities)
            {
               _foreignKeyHelper.Resolve(entity);
            }
         }
         
         return entities;
      }

      public TEntity GetById(string id, bool resolveForeignKeys = true)
      {
         var entity = _sqliteConnection.Get<TEntity>(id);
         
         if (resolveForeignKeys)
         {
            _foreignKeyHelper.Resolve(entity);
         }
         
         return entity;
      }

      public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool resolveForeignKeys = true)
      {
         var entities = _sqliteConnection.Table<TEntity>().AsQueryable().Where(predicate.Compile()).ToList();

         if (resolveForeignKeys)
         {
            foreach (var entity in entities)
            {
               _foreignKeyHelper.Resolve(entity);
            }
         }
         
         return entities;
      }

      public void Insert(TEntity entity)
      {
         entity.LastModified = GetLastModified();
         _sqliteConnection.Insert(entity);
      }

      public void Update(TEntity entity)
      {
         entity.LastModified = GetLastModified();
         _sqliteConnection.Update(entity);
      }

      private string GetLastModified()
      {
         return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
      }

      public void Delete(TEntity entity)
      {
         _sqliteConnection.Delete(entity);
      }

      public void Dispose()
      {
         _sqliteConnection?.Dispose();
      }
   }
}
