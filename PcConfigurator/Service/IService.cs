using System.Collections.Generic;
using PcConfigurator.Models;

namespace PcConfigurator.Service
{
    public interface IService<TDto> where TDto : IDto
    {
        TDto GetById(string id);
        void Insert(TDto dto);
        void Update(TDto dto);
        void Delete(string id);
        IList<TDto> GetAll();
    }
}