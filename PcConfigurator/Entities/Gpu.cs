namespace PcConfigurator.Entities
{
    public class Gpu : PowerConsumerComponent
    {
        public string Interface { get; set; }
        public string ChipsetManufacturer { get; set; }
    }
}