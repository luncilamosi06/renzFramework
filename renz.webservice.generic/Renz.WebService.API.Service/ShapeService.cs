using AutoMapper;
using RivTech.WebService.Generic.Data.Entity;
using RivTech.WebService.Generic.DataProvider.Repository;
using RivTech.WebService.Generic.DTO;
using RivTech.WebService.Generic.Service.Exceptions;
using RivTech.WebService.Generic.Service.Services;
using System.Collections.Generic;

namespace RivTech.WebService.Generic.Service
{
    public class ShapeService : IShapeService
    {
        private readonly IMapper _mapper;
        public ShapeService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ShapeDTO GetArea(byte a, byte b, byte c, byte d)
        {
            double PI = 3.1415926535897931;
            ShapeDTO data = new ShapeDTO();
            data.Triangle = ((a + b + c) / 2);
            data.Square = (a * a);
            data.Rectangle = (a * b);
            data.Circle = (PI * d);

            var result = _mapper.Map<ShapeDTO>(data);

            return data;
        }
    }


}
