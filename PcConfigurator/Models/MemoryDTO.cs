namespace PcConfigurator.Models
{
    public class MemoryDto : IDto
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Capacity { get; set; }

        public string CasLatency { get; set; }

        public string Voltage { get; set; }

        public string Type { get; set; }

        public string Speed { get; set; }

        public string Features { get; set; }
    }
}