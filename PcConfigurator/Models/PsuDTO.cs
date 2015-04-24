namespace PcConfigurator.Models
{
    public class PsuDto : IDto
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public string MaximumPower { get; set; }

        public string Efficiency { get; set; }

        public string Features { get; set; }
    }
}