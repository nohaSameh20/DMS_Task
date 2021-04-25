using Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Customers
{
    [Table(nameof(Customer))]
    public class Customer : Entity<Guid>
    {
        [Column(nameof(Description))]
        [Required]
        public string _Description { internal set; get; }


        //=================Not Mapped Properties=======================
        [Required]
        [NotMapped]
        public List<LookupDescriptionValueObject> Description
        {
            set { _Description = JsonConvert.SerializeObject(value, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }); }
            get { return _Description == null ? null : JsonConvert.DeserializeObject<List<LookupDescriptionValueObject>>(_Description); }
        }

    }
}
