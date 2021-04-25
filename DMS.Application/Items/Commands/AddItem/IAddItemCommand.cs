using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Items.Commands
{
    public interface IAddItemCommand
    {
        Guid Execute(AddItemModel model);
    }
}
