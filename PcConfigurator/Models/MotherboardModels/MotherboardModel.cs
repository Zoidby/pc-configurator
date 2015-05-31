using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PcConfigurator.Models.MotherboardModels
{
    public class MotherboardModel
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public string Socket { get; set; }
        public int MemoryMaximum { get; set; }
        public int MemorySlots { get; set; }
        public string HarddriveInterfaces { get; set; }
        public string ExpansionSlots { get; set; }
    }
}