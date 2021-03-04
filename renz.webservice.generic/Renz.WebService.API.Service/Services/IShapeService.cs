using RivTech.WebService.Generic.DTO;
using System.Collections.Generic;

namespace RivTech.WebService.Generic.Service.Services
{
    public interface IShapeService
    {
        ShapeDTO GetArea(byte a, byte b, byte c, byte d);
    }
}
