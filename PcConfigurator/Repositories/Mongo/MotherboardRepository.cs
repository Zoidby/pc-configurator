using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories.Mongo
{
    public class MotherboardRepository : MongoRepository<Motherboard>, IMotherboardRepository
    {
        public MotherboardRepository(MongoDatabase db)
            : base(db)
        {
        }

        public override void Update(Motherboard entity)
        {
            Collection.Update(Query<Motherboard>.EQ(e => e.Id, entity.Id), Update<Motherboard>.Replace(entity));
        }
    }
}