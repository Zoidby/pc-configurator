using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Driver;
using PcConfigurator.Models;

namespace PcConfigurator.DAL
{
    public class CpuDal
    {
        private string connectionString;

        private MongoUrl url;

        private string dbName = "pc_configurator";
        private string collectionName = "cpu";

        public CpuDal()
        {
#if DEBUG
            connectionString = "mongodb://root:root@ds062797.mongolab.com:62797/pc_configurator";
#else
            connectionString = System.Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MONGOLAB_URI");
#endif

            url = new MongoUrl(connectionString);
        }


        public Task CreateCpu(Cpu cpu)
        {
            var collection = GetCpuCollection();
            return collection.InsertOneAsync(cpu);
        }

        public Task<List<Cpu>> GetAll()
        {
            return GetCpuCollection().Find(_ => true).ToListAsync();
        } 

        private IMongoCollection<Cpu> GetCpuCollection()
        {
            var client = new MongoClient(url);
            var database = client.GetDatabase(dbName);
            var collection = database.GetCollection<Cpu>(collectionName);
            return collection;
        }
    }
}