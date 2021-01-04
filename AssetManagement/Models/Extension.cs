using AssetManagement.Models.Abstraction;
using AssetManagement.Models.Abstraction.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Extension
    {
        [Required]
        public int Number { get; set; }
        public ExtensionUsage Usage { get; set; }
        public int? EmployeeBadgeNo { get; set; }
        public Employee Employee { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
