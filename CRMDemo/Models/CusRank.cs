using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CRMDemo.Models
{
    public partial class CusRank
    {
        public CusRank()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }

        [Display(Name = "Tên Hạng")]
        public string RankName { get; set; } = null!;

        [Display(Name = "Điều kiện")]
        public decimal Condition { get; set; }

        [Display(Name = "Danh sách khách hàng")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
