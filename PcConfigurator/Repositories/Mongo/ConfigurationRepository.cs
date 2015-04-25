using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories.Mongo
{
    public class ConfigurationRepository : MongoRepository<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepository(MongoDatabase db) : base(db)
        {
        }

        public override void Update(Configuration entity)
        {
            Collection.Update(Query<Configuration>.EQ(e => e.Id, entity.Id), Update<Configuration>.Replace(entity));
        }
    }
}