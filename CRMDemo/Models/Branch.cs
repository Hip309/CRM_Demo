using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CRMDemo.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Accounts = new HashSet<Account>();
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }

        [Display(Name = "Tên chi nhánh")]
        public string BranchName { get; set; } = null!;

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Địa chỉ")]
        public string BranchAddress { get; set; } = null!;

        [Display(Name = "Nhân viên")]
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
