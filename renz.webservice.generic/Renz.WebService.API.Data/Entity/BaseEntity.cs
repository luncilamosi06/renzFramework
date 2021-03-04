using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RivTech.WebService.Generic.Data.Entity
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IBaseEntity.Id
        {
            get { return this.Id; }
            set => throw new System.NotImplementedException();
        }
        public bool IsActive { get; set; }
    }
}
