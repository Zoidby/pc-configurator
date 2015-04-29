using System.Collections.Generic;
using System.Linq;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(string id);
        void Insert(TEntity dto);
        void Update(TEntity dto);
        void Delete(string id);
        IEnumerable<TEntity> GetAll();
    }
}