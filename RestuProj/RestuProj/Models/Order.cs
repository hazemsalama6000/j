using System;
using System.Collections.Generic;

#nullable disable

namespace RestuProj.Models
{
    public partial class Order
    {
        public Order()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Orderdate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PaymentMethod Payment { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
