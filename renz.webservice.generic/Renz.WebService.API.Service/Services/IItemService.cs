using RivTech.WebService.Generic.DTO;
using System.Collections.Generic;

namespace RivTech.WebService.Generic.Service.Services
{
    public interface IItemService
    {
        string InsertItem(ItemDTO model);
        List<ItemDTO> GetAll();
        ItemDTO GetItem(byte id);
        string UpdateItem(ItemDTO model);
        string RemoveItem(byte id);
    }
}
