using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(string id);
        void Insert(TEntity dto);
        void Update(TEntity dto);
        void Delete(string id);
        IList<TEntity> GetAll();
    }
}