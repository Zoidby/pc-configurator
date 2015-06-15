using System.ComponentModel.DataAnnotations;

namespace PcConfigurator.Entities
{
    public abstract class Component : BaseEntity
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Name { get; set; }
    }
}