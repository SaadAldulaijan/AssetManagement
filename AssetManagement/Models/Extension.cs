using AssetManagement.Models.Abstraction;
using AssetManagement.Models.Abstraction.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Extension : BaseModel<int>
    {
        public int Number { get; set; }
        public ExtensionUsage Usage { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
