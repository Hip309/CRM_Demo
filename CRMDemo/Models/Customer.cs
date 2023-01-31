using System;
using System.Collections.Generic;

namespace CRMDemo.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string CusName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? CusAddress { get; set; }
        public decimal Expense { get; set; }
        public int CusRankId { get; set; }

        public virtual CusRank CusRank { get; set; } = null!;
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
