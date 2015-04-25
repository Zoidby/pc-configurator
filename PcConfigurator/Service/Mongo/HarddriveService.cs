using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class HarddriveService : Service<Harddrive>, IHarddriveService
    {
        private IHarddriveRepository _repo;

        public HarddriveService(IHarddriveRepository repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}