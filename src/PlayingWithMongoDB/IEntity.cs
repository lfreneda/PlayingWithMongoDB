using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayingWithMongoDB
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }

        IDictionary<string, object> Metadata { get; set; }
    }

    public class Entity : IEntity<string>
    {
        public string Id { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
    }
}