using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CRMDemo.Models
{
    public partial class Account
    {
        public Account()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }

        [Display(Name = "Tên người dùng")]
        public string UserName { get; set; } = null!;

        [Display(Name = "Mật khẩu")]
        public string Pass { get; set; } = null!;

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; } = null!;
        public int PositionId { get; set; }
        public int BranchId { get; set; }

        [Display(Name = "Chi nhánh")]
        public virtual Branch Branch { get; set; } = null!;

        [Display(Name = "Chức vụ")]
        public virtual Position Position { get; set; } = null!;
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
