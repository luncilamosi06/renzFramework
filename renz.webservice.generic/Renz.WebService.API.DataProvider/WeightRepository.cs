using RivTech.WebService.Generic.Data.Context;
using RivTech.WebService.Generic.Data.Entity;
using RivTech.WebService.Generic.DataProvider.Repository;

namespace RivTech.WebService.Generic.DataProvider
{
    public class WeightRepository : BaseRepository<LvWeight> , IWeightRepository
    {
        public WeightRepository(AppDbContext context) : base(context)
        {                  
        }

    }

}
