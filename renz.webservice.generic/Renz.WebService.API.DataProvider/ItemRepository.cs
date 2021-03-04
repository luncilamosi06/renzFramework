using RivTech.WebService.Generic.Data.Context;
using RivTech.WebService.Generic.Data.Entity;
using RivTech.WebService.Generic.DataProvider.Repository;

namespace RivTech.WebService.Generic.DataProvider
{
    public class ItemRepository : BaseRepository<LvItem> , IItemRepository
    {
        public ItemRepository(AppDbContext context) : base(context)
        {                  
        }

    }

}
