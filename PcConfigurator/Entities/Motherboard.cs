using System.Collections.Generic;

namespace PcConfigurator.Entities
{
    public class Motherboard : PowerConsumerComponent
    {
        public string Format { get; set; }
        public string Socket { get; set; }
        public int MemoryMaximum { get; set; }
        public int MemorySlots { get; set; }
        public IList<string> HarddriveInterfaces { get; set; }
        public IList<string> ExpansionSlots { get; set; }
    }
}