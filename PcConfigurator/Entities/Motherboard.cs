using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PcConfigurator.Entities
{
    public class Motherboard : PowerConsumerComponent
    {
        [Required]
        public string Format { get; set; }
        [Required]
        public string Socket { get; set; }
        [Required]
        public int MemorySlots { get; set; }
        [Required]
        public string MemoryInterface { get; set; }
        public IList<string> HarddriveInterfaces { get; set; }
        public IList<string> ExpansionSlots { get; set; }
    }
}