using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class GpuService : Service<Gpu>, IGpuService
    {
        private IGpuRepository _repo;

        public GpuService(IGpuRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}