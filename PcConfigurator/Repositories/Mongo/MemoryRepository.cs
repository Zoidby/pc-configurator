using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories.Mongo
{
    public class MemoryRepository : MongoRepository<Memory>, IMemoryRepository
    {
        public MemoryRepository(MongoDatabase db)
            : base(db)
        {
        }

        public override void Update(Memory entity)
        {
            Collection.Update(Query<Memory>.EQ(e => e.Id, entity.Id), Update<Memory>.Replace(entity));
        }
    }
}