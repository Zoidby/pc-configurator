using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities.Mongo;

namespace PcConfigurator.Repositories.Mongo
{
    public class MemoryRepository : MongoRepository<Memory>, IMemoryRepository
    {
        public override void Update(Memory entity)
        {
            Collection.Update(Query<Memory>.EQ(e => e.Id, entity.Id), Update<Memory>.Replace(entity));
        }

        public MemoryRepository(MongoDatabase db)
            : base(db)
        {
        }
    }
}