using System;
using System.Collections.Generic;

namespace PcConfigurator.Models
{
    public class CaseDto : IDto
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public List<String> MotherBoardCompatibility { get; set; }

        public string Features { get; set; }
    }
}