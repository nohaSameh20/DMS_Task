using Application.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Orders
{
    public class AddOrderModel:BaseModel
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public int ItemPrice { get; set; }
        public int Quantity { get; set; }
        public int ItemName { get; set; }
        public int ItemImage { get; set; }



    }
}
