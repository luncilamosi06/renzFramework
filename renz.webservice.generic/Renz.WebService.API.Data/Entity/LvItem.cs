using System;
using System.Collections.Generic;
using System.Text;

namespace RivTech.WebService.Generic.Data.Entity
{
    public class LvItem : BaseEntity<byte>
    {
        public string Name { get; set; }
        public long Weight { get; set; }
        public long TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
