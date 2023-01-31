using System;
using System.Collections.Generic;

namespace CRMDemo.Models
{
    public partial class Position
    {
        public Position()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string PositionName { get; set; } = null!;
        public decimal Salary { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
