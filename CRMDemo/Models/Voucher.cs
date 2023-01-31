using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMDemo.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }

        [Display(Name = "Tên voucher")]
        public string VoucherName { get; set; } = null!;

        [Display(Name = "Giá trị")]
        public decimal VoucherValue { get; set; }

        [Display(Name = "Điều kiện")]
        public decimal Condition { get; set; }

        [Display(Name = "Hạn sử dụng")]
        public DateTime Exd { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
