using AssetManagement.Models.Abstraction;
using AssetManagement.Models.Abstraction.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class OtherAsset : BaseModel<int>
    {
        public string SerialNo { get; set; }
        public string DN { get; set; }
        public string Model { get; set; }
        public Status Status { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
