using System;
using System.Collections.Generic;
using System.Text;

namespace RivTech.WebService.Generic.Data.Entity
{
    public class LvWeight : BaseEntity<byte>
    {
        public string Priority { get; set; }
        public string Type { get; set; }
        public long Rule { get; set; }
        public string Operator { get; set; }
        public long Cost { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
