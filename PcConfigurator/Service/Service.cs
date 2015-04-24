using System.Collections.Generic;
using System.Linq;
using PcConfigurator.Entities;
using PcConfigurator.Models;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service
{
    public abstract class Service<TEntity, TDto> : IService<TDto> where TEntity : IEntity where TDto : IDto
    {
        protected abstract TEntity DtoToEntity(TDto dto);
        protected abstract TDto EntityToDto(TEntity entity);

        protected IRepository<TEntity> Repo;

        protected Service(IRepository<TEntity> repo)
        {
            Repo = repo;
        }

        public virtual TDto GetById(string id)
        {
            return EntityToDto(Repo.GetById(id));
        }

        public virtual void Insert(TDto dto)
        {
            Repo.Insert(DtoToEntity(dto));
        }

        public virtual void Delete(string id)
        {
            Repo.Delete(id);
        }

        public virtual IList<TDto> GetAll()
        {
            return Repo.GetAll().Select(EntityToDto).ToList();
        }

        public virtual void Update(TDto dto)
        {
            Repo.Update(DtoToEntity(dto));
        }
    }
}