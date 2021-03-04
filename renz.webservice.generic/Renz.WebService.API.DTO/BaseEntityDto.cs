using System;
using System.Collections.Generic;
using System.Text;

namespace RivTech.WebService.Generic.DTO
{
    public abstract class BaseEntityDto<T>
    {
        public T Id { get; set; }        
        public bool IsActive { get; set; }
    }
}
