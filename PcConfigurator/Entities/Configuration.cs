namespace PcConfigurator.Entities
{
    public class Configuration : BaseEntity
    {
        public Case Case { get; set; }
        public Cpu Cpu { get; set; }
        public Gpu Gpu { get; set; }
        public Memory Memory { get; set; }
        public Harddrive Harddrive { get; set; }
        public Psu Psu { get; set; }
        public Motherboard Motherboard { get; set; }
    }
}