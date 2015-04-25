using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories.Mongo
{
    public class CaseRepository : MongoRepository<Case>, ICaseRepository
    {
        public CaseRepository(MongoDatabase db) : base(db)
        {
        }

        public override void Update(Case entity)
        {
            Collection.Update(Query<Case>.EQ(e => e.Id, entity.Id), Update<Case>.Replace(entity));
        }
    }
}