using AssetManagement.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Category : BaseModel<int>
    {
        public string Name { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
