namespace PlayingWithMongoDB
{
    public class Person : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}