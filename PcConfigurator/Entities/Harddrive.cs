using System.ComponentModel.DataAnnotations;

namespace PcConfigurator.Entities
{
    public class Harddrive : PowerConsumerComponent
    {
        [Required]
        public string Interface { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}