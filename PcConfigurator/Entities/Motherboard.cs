namespace PcConfigurator.Entities
{
    public class Motherboard : PowerConsumerComponent
    {
        public string Socket { get; set; }
        public int MemoryMaximum { get; set; }
        public int MemorySlots { get; set; }
    }
}