using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Asset
    {
        public int TelephoneId { get; set; }
        public int ExtensionId { get; set; }
        public DateTime InstalledDate { get; set; } = DateTime.Now;
        public Telephone Telephone { get; set; }
        public Extension Extension { get; set; }
    }
}
