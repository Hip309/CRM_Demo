using System;
using System.Collections.Generic;

namespace CRMDemo.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceInfos = new HashSet<InvoiceInfo>();
        }

        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CusId { get; set; }
        public int StaffId { get; set; }
        public int BranchId { get; set; }
        public int VoucherId { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual Customer Cus { get; set; } = null!;
        public virtual Account Staff { get; set; } = null!;
        public virtual Voucher Voucher { get; set; } = null!;
        public virtual ICollection<InvoiceInfo> InvoiceInfos { get; set; }
    }
}
