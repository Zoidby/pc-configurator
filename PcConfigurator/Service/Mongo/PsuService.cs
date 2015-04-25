using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class PsuService : Service<Psu>, IPsuService
    {
        private IPsuRepository _repo;

        public PsuService(IPsuRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}