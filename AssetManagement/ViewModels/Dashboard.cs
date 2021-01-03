using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class Dashboard
    {
        public int NoOfPhones { get; set; }
        public int NoOfEricsson { get; set; }
        public int NoOfCisco { get; set; }
        public int NoOfExtension { get; set; }
        public int NoOfAvailableExtension { get; set; }
        public int NoOfUsedExtension { get; set; }
        public int NoOfHuntGroupExtension { get; set; }
        public int NoOfPilotNumberExtension { get; set; }
        public int NoOfSystemUseExtension { get; set; }
    }
}
