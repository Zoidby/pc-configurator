using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class MotherboardService : Service<Motherboard>, IMotherboardService
    {
        private IMotherboardRepository _repo;

        public MotherboardService(IMotherboardRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}