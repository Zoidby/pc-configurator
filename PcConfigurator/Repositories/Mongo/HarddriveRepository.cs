using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories.Mongo
{
    public class HarddriveRepository : MongoRepository<Harddrive>, IHarddriveRepository
    {
        public HarddriveRepository(MongoDatabase db)
            : base(db)
        {
        }

        public override void Update(Harddrive entity)
        {
            Collection.Update(Query<Harddrive>.EQ(e => e.Id, entity.Id), Update<Harddrive>.Replace(entity));
        }
    }
}