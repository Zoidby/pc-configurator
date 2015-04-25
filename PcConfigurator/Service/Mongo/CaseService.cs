using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class CaseService : Service<Case>, ICaseService
    {
        private ICaseRepository _repo;

        public CaseService(ICaseRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}