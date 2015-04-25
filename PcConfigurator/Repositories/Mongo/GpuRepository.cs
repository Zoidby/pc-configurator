using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories.Mongo
{
    public class GpuRepository : MongoRepository<Gpu>, IGpuRepository
    {
        public GpuRepository(MongoDatabase db) : base(db)
        {
        }

        public override void Update(Gpu entity)
        {
            Collection.Update(Query<Gpu>.EQ(e => e.Id, entity.Id), Update<Gpu>.Replace(entity));
        }
    }
}