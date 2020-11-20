using System;
using System.Collections.Generic;

#nullable disable

namespace RestuProj.Models
{
    public partial class OrdersDetail
    {
        public int Id { get; set; }
        public float? TotalPrice { get; set; }
        public int? FoodId { get; set; }
        public int? OrdersId { get; set; }
        public int? Quantity { get; set; }

        public virtual Food Food { get; set; }
        public virtual Order Orders { get; set; }
    }
}
