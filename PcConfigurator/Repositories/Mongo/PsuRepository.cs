using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories.Mongo
{
    public class PsuRepository : MongoRepository<Psu>, IPsuRepository
    {
        public PsuRepository(MongoDatabase db)
            : base(db)
        {
        }

        public override void Update(Psu entity)
        {
            Collection.Update(Query<Psu>.EQ(e => e.Id, entity.Id), Update<Psu>.Replace(entity));
        }
    }
}