using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Items
{
    public class GetItemsQueryResult
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public int QTY { get; set; }
        public string Price { get; set; }
        public string UOM { get; set; }
    }
}
