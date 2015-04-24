using AutoMapper;
using PcConfigurator.Entities.Mongo;
using PcConfigurator.Models;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class MotherboardService : Service<Motherboard, MotherboardDto>, IMotherboardService
    {
        private IMotherboardRepository _repo;

        public MotherboardService(IMotherboardRepository repo) : base(repo)
        {
            _repo = repo;
        }

        protected override Motherboard DtoToEntity(MotherboardDto dto)
        {
            return Mapper.Map<Motherboard>(dto);
        }

        protected override MotherboardDto EntityToDto(Motherboard entity)
        {
            return Mapper.Map<MotherboardDto>(entity);
        }
    }
}