using System;
using System.Collections.Generic;

#nullable disable

namespace RestuProj.Models
{
    public partial class Food
    {
        public Food()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float? UnitPrice { get; set; }

        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
