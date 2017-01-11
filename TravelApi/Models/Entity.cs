using TravelApi.Sqlite;

namespace TravelApi.Models
{
   public abstract class Entity
   {
      protected Entity()
      {
         Id = IdGenerator.GetId();
      }

      [PrimaryKey]
      public string Id { get; set; }

      public string LastModified { get; set; }

      protected bool Equals(Entity other)
      {
         return string.Equals(Id, other.Id);
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != GetType()) return false;
         return Equals((Entity)obj);
      }

      public override int GetHashCode()
      {
         return Id?.GetHashCode() ?? 0;
      }
   }
}