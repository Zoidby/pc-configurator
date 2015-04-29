using Newtonsoft.Json;

namespace PcConfigurator.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}