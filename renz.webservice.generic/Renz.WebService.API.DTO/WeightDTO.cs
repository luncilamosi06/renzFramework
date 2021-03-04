using System;

namespace RivTech.WebService.Generic.DTO
{
    public class WeightDTO : BaseEntityDto<byte>
    {
        public string Priority { get; set; }
        public string Type { get; set; }
        public long Rule { get; set; }
        public string Operator { get; set; }
        public long Cost { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
