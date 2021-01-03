using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class EmployeeAssetViewModel
    {
        public int Id { get; set; }
        public int BadgeNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public List<Telephone> Telephones { get; set; }
        public List<Pager> Pagers { get; set; }
        public List<Extension> Extensions { get; set; }
        public List<OtherAsset> OtherAssets { get; set; }

        public EmployeeAssetViewModel()
        {
            Telephones = new List<Telephone>();
            Pagers = new List<Pager>();
            Extensions = new List<Extension>();
            OtherAssets = new List<OtherAsset>();
        }
    }
}
