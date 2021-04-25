using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Items
{
    public interface IGetItemsQuery
    {
       List< GetItemsQueryResult> Execute();
    }
}
