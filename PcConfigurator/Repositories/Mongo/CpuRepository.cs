using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities.Mongo;

namespace PcConfigurator.Repositories.Mongo
{
    public class CpuRepository : MongoRepository<Cpu>, ICpuRepository
    {
        public override void Update(Cpu entity)
        {
            Collection.Update(Query<Cpu>.EQ(e => e.Id, entity.Id), Update<Cpu>.Replace(entity));
        }

        public CpuRepository(MongoDatabase db) : base(db)
        {
        }
    }
}