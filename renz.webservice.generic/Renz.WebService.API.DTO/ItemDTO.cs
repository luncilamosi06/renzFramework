using System;

namespace RivTech.WebService.Generic.DTO
{
    public class ItemDTO : BaseEntityDto<byte>
    {
        public string Name { get; set; }
        public long Weight { get; set; }
        public long TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
