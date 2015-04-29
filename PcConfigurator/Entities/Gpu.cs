namespace PcConfigurator.Entities
{
    public class Gpu : PowerConsumerComponent
    {
        public string ExpansionSlot { get; set; }
        public string ChipsetManufacturer { get; set; }
    }
}