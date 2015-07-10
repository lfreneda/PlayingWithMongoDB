namespace PlayingWithMongoDB.Extensions
{
    public static class DbExtensions
    {
        public static string BuildCollectionName<T>(this IDb<T> db)
            where T : IEntity
        {
            var pluralizedName = typeof (T).Name.EndsWith("s") ? typeof (T).Name : typeof (T).Name + "s";
            return pluralizedName;
        }
    }
}