using AssetManagement.Models.Abstraction;
using AssetManagement.Models.Abstraction.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Pager
    {
        public int Number { get; set; }
        public Status Status { get; set; }
        public string Capcode { get; set; }
        public string Comment { get; set; }
        public string Cust { get; set; }
        public string RateCode { get; set; }
        [Required(ErrorMessage = "Serial Number cannot be empty")]
        public string SerialNo { get; set; }
        public string MailCode { get; set; }
        public string Facility { get; set; }
        public int? EmployeeBadgeNo { get; set; }
        public Employee Employee { get; set; }
    }
}
