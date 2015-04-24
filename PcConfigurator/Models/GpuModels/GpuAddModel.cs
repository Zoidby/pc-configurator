using System.ComponentModel.DataAnnotations;

namespace PcConfigurator.Models.GpuModels
{
    public class GpuAddModel
    {
        #region gpu

        [Required(AllowEmptyStrings = false)]
        public string Brand { get; set; }

        [Required]
        public string GpuModel { get; set; }

        #endregion
    }
}