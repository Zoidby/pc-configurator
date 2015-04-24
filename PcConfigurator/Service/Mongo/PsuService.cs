using AutoMapper;
using PcConfigurator.Entities.Mongo;
using PcConfigurator.Models;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class PsuService : Service<Psu, PsuDto>, IPsuService
    {
        private IPsuRepository _repo;

        public PsuService(IPsuRepository repo) : base(repo)
        {
            _repo = repo;
        }

        protected override Psu DtoToEntity(PsuDto dto)
        {
            return Mapper.Map<Psu>(dto);
        }

        protected override PsuDto EntityToDto(Psu entity)
        {
            return Mapper.Map<PsuDto>(entity);
        }
    }
}