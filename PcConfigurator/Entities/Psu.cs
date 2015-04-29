using Newtonsoft.Json;

namespace PcConfigurator.Entities
{
    public class Psu : Component
    {
        public int MaximumPower { get; set; }
        public int Efficiency { get; set; }
        public int ActualPower { get; set; }
    }
}