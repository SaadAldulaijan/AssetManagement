using AssetManagement.Models.Abstraction;
using AssetManagement.Models.Abstraction.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Telephone
    {
        public string MAC { get; set; }
        [Required(ErrorMessage = "Serial Number cannot be empty")]
        [DataType(DataType.Text)]
        public string SerialNo { get; set; }
        public string Tag { get; set; }
        public string Remark { get; set; }
        public Status Status { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
