using AssetManagement.Models.Abstraction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Badge Number cannot be empty")]
        public int BadgeNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<Extension> Extensions { get; set; }
        public virtual ICollection<Pager> Pagers { get; set; }
        public virtual ICollection<OtherAsset> OtherAssets { get; set; }
    }
}