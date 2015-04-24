namespace PcConfigurator.Models
{
    public class GpuDto : IDto
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Interface { get; set; }

        public string ChipsetManufacturer { get; set; }

        public string GpuModel { get; set; }
    }
}