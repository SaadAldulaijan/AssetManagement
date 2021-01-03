using System.Collections.Generic;

namespace AssetManagement.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Telephone> Telephones { get; set; }
    }
}