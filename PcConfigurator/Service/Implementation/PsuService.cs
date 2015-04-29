using System.Collections.Generic;
using System.Linq;
using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class PsuService : Service<Psu>, IPsuService
    {
        private readonly IPsuRepository _psuRepo;
        private readonly IConfigurationService _configService;

        public PsuService(IPsuRepository psuRepo, IConfigurationService configService)
            : base(psuRepo)
        {
            _psuRepo = psuRepo;
            _configService = configService;
        }

        public override void Insert(Psu dto)
        {
            dto.ActualPower = dto.MaximumPower*dto.Efficiency/100;
            _psuRepo.Insert(dto);
        }

        public IEnumerable<Psu> GetValidPsus(Configuration configuration)
        {
            return _psuRepo.GetAll().Where(p => _configService.GetTotalConsumption(configuration) <= p.ActualPower);
        }
    }
}