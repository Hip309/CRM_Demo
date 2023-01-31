using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CRMDemo.Models
{
    public partial class Product
    {
        public Product()
        {
            InvoiceInfos = new HashSet<InvoiceInfo>();
        }

        public int Id { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        public string ProductName { get; set; } = null!;

        [Display(Name = "Đơn Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Đơn Vị")]
        public string Unit { get; set; } = null!;

        public virtual ICollection<InvoiceInfo> InvoiceInfos { get; set; }
    }
}
