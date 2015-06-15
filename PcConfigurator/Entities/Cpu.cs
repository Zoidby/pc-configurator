using System.ComponentModel.DataAnnotations;

namespace PcConfigurator.Entities
{
    public class Cpu : PowerConsumerComponent
    {
        [Required]
        public string Socket { get; set; }
    }
}