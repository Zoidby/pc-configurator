using AutoMapper;
using PcConfigurator.Entities.Mongo;
using PcConfigurator.Models;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class MemoryService : Service<Memory, MemoryDto>, IMemoryService
    {
        private IMemoryRepository _repo;

        public MemoryService(IMemoryRepository repo)
            : base(repo)
        {
            _repo = repo;
        }

        protected override Memory DtoToEntity(MemoryDto dto)
        {
            return Mapper.Map<Memory>(dto);
        }

        protected override MemoryDto EntityToDto(Memory entity)
        {
            return Mapper.Map<MemoryDto>(entity);
        }
    }
}