namespace PcConfigurator.Models
{
    public class CpuDto : IDto
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Series { get; set; }

        public string Socket { get; set; }

        public string Name { get; set; }

        public string CoreName { get; set; }

        public int CoresCount { get; set; }

        public string Frequency { get; set; }

        public string Tdp { get; set; }

        public string Graphics { get; set; }

        public string Voltage { get; set; }
    }
}