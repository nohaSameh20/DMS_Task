using Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Items.Commands
{
    public interface IAddItemFactory
    {
        Item Create(AddItemModel data);
    }
}
