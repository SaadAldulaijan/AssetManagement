using AssetManagement.Models.Abstraction;
using System.Collections.Generic;

namespace AssetManagement.Models
{
    public class Department : BaseModel<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}