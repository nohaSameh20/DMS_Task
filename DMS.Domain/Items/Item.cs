using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Items
{
    [Table(nameof(Item))]
    public class Item : Entity<Guid>
    {

        public string Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public int QTY { get; set; }
        public int Price { get; set; }
        public string UOM { get; set; }


    }
}
