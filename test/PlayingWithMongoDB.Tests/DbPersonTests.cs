using System.Threading.Tasks;
using MongoDB.Bson;
using NUnit.Framework;

namespace PlayingWithMongoDB.Tests
{
    [TestFixture]
    public class DbPersonTests
    {
        [Test]
        public async Task CanUpdate()
        {
            var id = ObjectId.GenerateNewId().ToString();

            var db = new Db<Person>("your mongoDb connection string here :-)");

            await db.Add(new Person
            {
                Id = id,
                FirstName = "Luiz",
                LastName = "Freneda"
            });

            var selectedBeforeUpdate = await db.GetById(id);

            selectedBeforeUpdate.FirstName = "Luis";
            selectedBeforeUpdate.LastName = "Junior";

            await db.Update(selectedBeforeUpdate);

            var selectedAfterUpdate = await db.GetById(id);

            Assert.AreEqual(selectedAfterUpdate.FirstName, selectedBeforeUpdate.FirstName);
            Assert.AreEqual(selectedAfterUpdate.LastName, selectedBeforeUpdate.LastName);
        }
    }
}