using AutoMapper;
using PcConfigurator.Entities.Mongo;
using PcConfigurator.Models;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Mongo
{
    public class CaseService : Service<Case, CaseDto>, ICaseService
    {
        private ICaseRepository _repo;

        public CaseService(ICaseRepository repo) : base(repo)
        {
            _repo = repo;
        }

        protected override Case DtoToEntity(CaseDto dto)
        {
            return Mapper.Map<Case>(dto);
        }

        protected override CaseDto EntityToDto(Case entity)
        {
            return Mapper.Map<CaseDto>(entity);
        }
    }
}