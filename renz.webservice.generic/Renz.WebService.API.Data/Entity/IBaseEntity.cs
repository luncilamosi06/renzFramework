using System;
using System.Collections.Generic;
using System.Text;

namespace RivTech.WebService.Generic.Data.Entity
{
    public interface IBaseEntity
    {
        object Id { get; set; }
        bool IsActive { get; set; }
    }

    public interface IBaseEntity<T> : IBaseEntity
    {
        new T Id { get; set; }
    }
}
