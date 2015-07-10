using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace PlayingWithMongoDB
{
    public static class MongoConfiguration
    {
        private static readonly object Lock = new object();

        public static void Config()
        {
            lock (Lock)
            {
                var conventionPack = new ConventionPack
                {
                    new IgnoreIfNullConvention(true),
                    new CamelCaseElementNameConvention()
                };

                ConventionRegistry.Register("ConventionPack", conventionPack, t => true);

                if (!BsonClassMap.IsClassMapRegistered(typeof(Entity)))
                {
                    BsonClassMap.RegisterClassMap<Entity>(classMap =>
                    {
                        classMap.AutoMap();
                        classMap.MapIdProperty(p => p.Id);
                        classMap.MapExtraElementsProperty(p => p.Metadata);
                    });
                }
            }
        }
    }
}
