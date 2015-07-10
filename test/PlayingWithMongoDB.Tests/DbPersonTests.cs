using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using NUnit.Framework;

namespace PlayingWithMongoDB.Tests
{
    [TestFixture]
    public class DbPersonTests
    {
        [SetUp]
        public void SetUp()
        {
            MongoConfiguration.Config();
        }

        [Test]
        public async Task CanUpdate()
        {
            var id = ObjectId.GenerateNewId().ToString();

            var db = new Db<Person>("your mongoDb connection string here :-)");

            await db.Add(new Person
            {
                Id = id,
                FirstName = "Luiz",
                LastName = "Freneda",
                
                Metadata = new Dictionary<string, object>
                {
                    { "CustomProperty1", 1 },
                    { "CustomProperty2", "2" },
                }
            });

            var selectedBeforeUpdate = await db.GetById(id);

            selectedBeforeUpdate.FirstName = "Luis";
            selectedBeforeUpdate.LastName = "Junior";
            selectedBeforeUpdate.Metadata["CustomProperty1"] = 2;
            selectedBeforeUpdate.Metadata["CustomProperty2"] = "1";

            await db.Update(selectedBeforeUpdate);

            var selectedAfterUpdate = await db.GetById(id);

            Assert.AreEqual(selectedAfterUpdate.FirstName, selectedBeforeUpdate.FirstName);
            Assert.AreEqual(selectedAfterUpdate.LastName, selectedBeforeUpdate.LastName);
            Assert.AreEqual(selectedAfterUpdate.Metadata["CustomProperty1"], selectedBeforeUpdate.Metadata["CustomProperty1"]);
            Assert.AreEqual(selectedAfterUpdate.Metadata["CustomProperty2"], selectedBeforeUpdate.Metadata["CustomProperty2"]);
        }
    }
}