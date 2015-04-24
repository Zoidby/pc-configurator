namespace PcConfigurator.Models
{
    public class MotherboardDto : IDto
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string CpuSocket { get; set; }

        public string CpuType { get; set; }

        public string MemoryMaximum { get; set; }

        public string MemorySlots { get; set; }

        public string Features { get; set; }
    }
}