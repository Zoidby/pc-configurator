using System.ComponentModel.DataAnnotations;

namespace PcConfigurator.Entities
{
    public class Memory : PowerConsumerComponent
    {
        [Required]
        public int TotalCapacity { get; set; }
        [Required]
        public int Count { get; set; }
    }
}