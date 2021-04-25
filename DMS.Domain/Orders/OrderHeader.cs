using Domain.Common;
using Domain.Customers;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Orders
{
    [Table(nameof(OrderHeader))]
    public class OrderHeader : Entity<Guid>
    {
        public DateTime OrderDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DueDate { get; set; }
        public OrderHeaderStatus Status { get; set; }
        public int TaxCode { get; set; }
        public int DiscountCode { get; set; }
        public double DiscountValue { get; set; }
        public double TotalPrice { get; set; }

        //====================Navigation Properites================//
        public Customer Customer { set; get; }
        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
    }
}
