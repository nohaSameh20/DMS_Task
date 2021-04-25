using Application.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Items.Commands
{
    public class AddItemModel:BaseModel
    {
        public string Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public int QTY { get; set; }
        public string Price { get; set; }
        public string UOM { get; set; }

    }
}
