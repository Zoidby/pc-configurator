using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IHarddriveService : IService<Harddrive>
    {
        IEnumerable<Harddrive> GetValidHarddrives(Configuration configuration);
    }
}