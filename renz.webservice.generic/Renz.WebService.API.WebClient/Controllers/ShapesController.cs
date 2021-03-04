using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RivTech.WebService.Generic.DTO;
using RivTech.WebService.Generic.Service.Exceptions;
using RivTech.WebService.Generic.Service.Services;
using System.Collections.Generic;

namespace RivTech.WebService.Generic.WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        private readonly IShapeService _shapeService;
        public ShapesController(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        [HttpGet("{a}/{b}/{c}/{d}")]
        [Produces(typeof(ShapeDTO))]
        public IActionResult GetArea([FromRoute] byte a, byte b, byte c, byte d)
        {
            var res = _shapeService.GetArea(a,b,c,d);
            return Ok(res);
        }
    }


}