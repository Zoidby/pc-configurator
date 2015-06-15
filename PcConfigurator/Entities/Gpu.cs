using System.ComponentModel.DataAnnotations;

namespace PcConfigurator.Entities
{
    public class Gpu : PowerConsumerComponent
    {
        [Required]
        public string ExpansionSlot { get; set; }
        [Required]
        public string ChipsetManufacturer { get; set; }
    }
}