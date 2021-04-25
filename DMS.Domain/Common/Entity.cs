using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public class Entity : IEntity
    {
       
    }

    public class Entity<T> : IEntity<T>
    {
        // Identity 
        [Key]
        public T Id { get; set; }

        [NotMapped]
        public EntityStatus EntityStatus { set; get; } = EntityStatus.NoChanges; 

        //=========Audit Members============ 
        public DateTime CreatedAt { set; get; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
