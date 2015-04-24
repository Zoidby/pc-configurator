using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities.Mongo;

namespace PcConfigurator.Repositories.Mongo
{
    public class CaseRepository : MongoRepository<Case>, ICaseRepository
    {
        public override void Update(Case entity)
        {
            Collection.Update(Query<Case>.EQ(e => e.Id, entity.Id), Update<Case>.Replace(entity));
        }

        public CaseRepository(MongoDatabase db) : base(db)
        {
        }
    }
}