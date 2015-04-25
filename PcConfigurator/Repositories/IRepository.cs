using System.Linq;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(string id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(string id);
        IQueryable<T> GetAll();
    }
}