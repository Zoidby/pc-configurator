using System.Collections.Generic;
using System.Linq;
using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service
{
    public abstract class Service<TEntity> : IService<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repo;

        protected Service(IRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public virtual TEntity GetById(string id)
        {
            return _repo.GetById(id);
        }

        public virtual void Insert(TEntity dto)
        {
            _repo.Insert(dto);
        }

        public virtual void Delete(string id)
        {
            _repo.Delete(id);
        }

        public virtual IList<TEntity> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public virtual void Update(TEntity dto)
        {
            _repo.Update(dto);
        }
    }
}