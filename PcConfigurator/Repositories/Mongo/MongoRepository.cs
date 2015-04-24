using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities.Mongo;

namespace PcConfigurator.Repositories.Mongo
{
    public abstract class MongoRepository<T> : IRepository<T> where T : MongoEntity
    {
        protected MongoCollection<T> Collection;

        public virtual T GetById(string id)
        {
            return Collection.FindOne(Query<T>.EQ(e => e.Id, new ObjectId(id)));
        }

        public virtual void Insert(T entity)
        {
            Collection.Insert(entity);
        }

        public virtual void Delete(string id)
        {
            Collection.Remove(Query<T>.EQ(e => e.Id, new ObjectId(id)));
        }

        public virtual IList<T> GetAll()
        {
            return Collection.FindAll().ToList();
        }

        public abstract void Update(T entity);

        protected MongoRepository(MongoDatabase db)
        {
            Collection = db.GetCollection<T>(typeof (T).Name.ToLower());
        }
    }
}