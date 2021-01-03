using AssetManagement.Models.Abstraction;
using AssetManagement.Models.Abstraction.Enums;
using System.Collections.Generic;

namespace AssetManagement.Models
{
    public class Telephone: BaseModel<int>
    {
        public string MAC { get; set; }
        public string SerialNo { get; set; }
        public string Tag { get; set; }
        public string Remark { get; set; }
        public Status Status { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
