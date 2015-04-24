using AutoMapper;
using PcConfigurator.Entities.Mongo;
using PcConfigurator.Models;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class GpuService : Service<Gpu, GpuDto>, IGpuService
    {
        private IGpuRepository _repo;

        public GpuService(IGpuRepository repo) : base(repo)
        {
            _repo = repo;
        }

        protected override Gpu DtoToEntity(GpuDto dto)
        {
            return Mapper.Map<Gpu>(dto);
        }

        protected override GpuDto EntityToDto(Gpu entity)
        {
            return Mapper.Map<GpuDto>(entity);
        }
    }
}