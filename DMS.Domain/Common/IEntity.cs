using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public interface IEntity
    {
      
    }


    public interface IEntity<T> : IEntity
    {
        [Key]
        T Id { set; get; }
    }
}
