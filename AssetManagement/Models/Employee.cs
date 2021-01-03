using AssetManagement.Models.Abstraction;
using System.Collections.Generic;

namespace AssetManagement.Models
{
    public class Employee : BaseModel<int>
    {
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