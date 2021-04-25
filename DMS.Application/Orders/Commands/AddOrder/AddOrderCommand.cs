using Application.Interfaces;
using Domain.Enums;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Orders
{
    public class AddOrderCommand : IAddOrderCommand
    {
        IDatabaseService databaseService;
        public AddOrderCommand(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }
        public Guid Execute(AddOrderModel model)
        {
            if (model == null || !model.ValidationState.IsValid)
                throw new ValidationsException("Add New Order not valid", model.ValidationState.ValidationResults);

            var item = databaseService.Items.Single(obj => obj.Id == model.ItemId);
            OrderHeader orderHeader = new OrderHeader()
            {
                Id = Guid.NewGuid(),
                OrderDate = DateTime.Now,
                RequestDate = DateTime.Now,
                DueDate = DateTime.Now,
                Status = OrderHeaderStatus.Open,
                TaxCode = 10,
                DiscountCode = 02,
                DiscountValue = 20,
                EntityStatus = Domain.Common.EntityStatus.New,
            };
            orderHeader.TotalPrice = (double)item.Price - orderHeader.DiscountValue;
         

            OrderDetails orderDetails = new OrderDetails()
            {
                Id = Guid.NewGuid(),
                Discount = 20 / 100,
                CreatedAt = DateTime.Now,
                ItemId = item.Id,
                ItemPrice = item.Price,
                Quantity = item.QTY,
                Tax = 10 / 100,
                OrderHeaderId = orderHeader.Id,
                EntityStatus = Domain.Common.EntityStatus.New,
            };

            databaseService.ExecuteTransaction(() =>
            {
                databaseService.OrderHeaders.Add(orderHeader);
                databaseService.OrderDetails.Add(orderDetails);
                databaseService.SaveChanges();

            });
            return orderHeader.Id;
        }
    }
}
