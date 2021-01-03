using AssetManagement.Models.Abstraction;
using AssetManagement.Models.Abstraction.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Pager : BaseModel<int>
    {
        public int Number { get; set; }
        public Status Status { get; set; }
        public string Capcode { get; set; }
        public string Comment { get; set; }
        public string Cust { get; set; }
        public string RateCode { get; set; }
        public string SerialNo { get; set; }
        public string MailCode { get; set; }
        public string Facility { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
