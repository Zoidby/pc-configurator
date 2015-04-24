using System.ComponentModel.DataAnnotations;

namespace PcConfigurator.Models.CpuModels
{
    public class CpuAddModel
    {
        #region Cpu

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Socket { get; set; }

        [Required]
        public string Series { get; set; }

        #endregion
    }
}