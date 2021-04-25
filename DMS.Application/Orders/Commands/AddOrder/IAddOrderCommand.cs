using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Orders
{
    public interface IAddOrderCommand
    {
        Guid Execute(AddOrderModel model);
    }
}
