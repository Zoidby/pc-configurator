using AutoMapper;
using PcConfigurator.Entities.Mongo;
using PcConfigurator.Models;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class CpuService : Service<Cpu, CpuDto>, ICpuService
    {
        private ICpuRepository _repo;

        public CpuService(ICpuRepository repo) : base(repo)
        {
            _repo = repo;
        }

        protected override Cpu DtoToEntity(CpuDto dto)
        {
            return Mapper.Map<Cpu>(dto);
        }

        protected override CpuDto EntityToDto(Cpu entity)
        {
            return Mapper.Map<CpuDto>(entity);
        }
    }
}