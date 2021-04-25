using Domain.Common;
using Domain.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Orders
{
    [Table(nameof(OrderDetails))]
    public class OrderDetails : Entity<Guid>
    {

        public int ItemPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int Tax { get; set; }
        public int Discount { get; set; }




        //====================Navigation Properites================//
        public OrderHeader OrderHeader { set; get; }
        [ForeignKey(nameof(OrderHeader))]
        public Guid OrderHeaderId { get; set; }

        public Item Item { set; get; }
        [ForeignKey(nameof(Item))]
        public Guid ItemId { get; set; }

        public UOM UOM { set; get; }
        [ForeignKey(nameof(UOM))]
        public Guid UOMId { get; set; }
    }
}
