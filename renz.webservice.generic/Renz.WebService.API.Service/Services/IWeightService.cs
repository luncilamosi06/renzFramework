using RivTech.WebService.Generic.DTO;
using System.Collections.Generic;

namespace RivTech.WebService.Generic.Service.Services
{
    public interface IWeightService
    {
        string InsertWeight(WeightDTO model);
        List<WeightDTO> GetAll();
        WeightDTO GetWeight(byte id);
        string UpdateWeight(WeightDTO model);
        string RemoveWeight(byte id);
    }
}
