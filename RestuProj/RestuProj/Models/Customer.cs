using System;
using System.Collections.Generic;

#nullable disable

namespace RestuProj.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLocat { get; set; }
        public string Telepone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
