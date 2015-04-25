using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class CpuService : Service<Cpu>, ICpuService
    {
        private ICpuRepository _repo;

        public CpuService(ICpuRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}