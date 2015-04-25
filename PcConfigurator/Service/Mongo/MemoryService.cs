using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class MemoryService : Service<Memory>, IMemoryService
    {
        private IMemoryRepository _repo;

        public MemoryService(IMemoryRepository repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}