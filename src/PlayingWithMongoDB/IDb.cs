using System.Threading.Tasks;
using MongoDB.Driver;

namespace PlayingWithMongoDB
{
    public interface IDb<T> where T : Entity
    {
        IMongoCollection<T> Collection { get; }
        Task<T> GetById(string id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
    }
}