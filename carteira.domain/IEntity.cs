using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace CarteiraIO.Domain
{
    public interface IIdentity<T>
    {
        T Id { get; set; }
    }

    public interface IArchivable
    {
        bool IsArchived { get; set; }
        void Archive();
        void Restore();
    }
 

    public interface IAuditableEntity
    {
        IEnumerable<Log> Logs { get; set; }
        void AddLog(string description);
    }

    public interface IEntity<T> : IIdentity<T>, IArchivable, IAuditableEntity
    {
        
    }
    public abstract class Entity : IEntity<ObjectId>
    {
        protected Entity()
        {
            Id = ObjectId.GenerateNewId();
        }

        public ObjectId Id { get; set; }

        public bool IsArchived { get; set; }

        public void Archive() => IsArchived = true;
        public void Restore() => IsArchived = false;


        private List<Log> _logs = new List<Log>();
        public IEnumerable<Log> Logs { get => _logs; set => _logs = value.ToList();  }
        public void AddLog(string description) => _logs.Add(new Log() { Description = description });

    }

    public class Log 
    {
        public Log()
        {
            Id = ObjectId.GenerateNewId();
            CreateAt = DateTime.Now;
        }

        public ObjectId Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
    }
 
    public static class EntityExtensions
    {
        public static T GenerateNewId<T>(this T e) where T : IEntity<ObjectId>
        {
            e.Id = ObjectId.GenerateNewId();
            return e;
        }
    }

    public abstract class HoldingEntity : Entity
    {
        public ObjectId HoldingId { get; set; }
    }

    public abstract class OrganizationEntity : Entity
    {
        public ObjectId OrganizationId { get; set; }
    }
}
