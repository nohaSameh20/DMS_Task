using Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Items.Commands
{
    public class AddItemFactory : IAddItemFactory
    {
        public Item Create(AddItemModel data)
        {
            Item item = new Item()
            {
                Description = data.Description,
                Id = Guid.NewGuid(),
                EntityStatus = Domain.Common.EntityStatus.New,
                Price = data.Price,
                QTY = data.QTY,
                CreatedAt = DateTime.Now,
                Name=data.Name,
                UOM=data.UOM,
            };
            return item;
        }
    }
}
