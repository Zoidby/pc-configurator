using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PcConfigurator.Entities
{
    public class Psu : Component
    {
        [Required]
        public int MaximumPower { get; set; }
        [Required]
        public int Efficiency { get; set; }
        public int ActualPower { get; set; }
    }
}