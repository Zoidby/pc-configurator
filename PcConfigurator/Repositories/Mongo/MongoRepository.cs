using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories.Mongo
{
    public abstract class MongoRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MongoCollection<T> Collection;

        protected MongoRepository(MongoDatabase db)
        {
            Collection = db.GetCollection<T>(typeof (T).Name);
        }

        public virtual T GetById(string id)
        {
            return Collection.FindOne(Query<T>.EQ(e => e.Id, id));
        }

        public virtual void Insert(T entity)
        {
            Collection.Insert(entity);
        }

        public virtual void Delete(string id)
        {
            Collection.Remove(Query<T>.EQ(e => e.Id, id));
        }

        public virtual IQueryable<T> GetAll()
        {
            return Collection.AsQueryable();
        }

        public abstract void Update(T entity);
    }
}