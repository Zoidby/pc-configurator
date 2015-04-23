using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PcConfigurator.Models.CpuModels
{
    public class CpuAddModel
    {
        #region Cpu
        [Required(AllowEmptyStrings = false)]
        public string Number { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Socket { get; set; }
        #endregion
    }
}