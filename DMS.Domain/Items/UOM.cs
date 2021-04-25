using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Items
{
    [Table(nameof(UOM))]
    public class UOM : Entity<Guid>
    {
        public string UOMs { get; set; }
        public string Descripton { get; set; }

    }
}
