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
    public class WeightController : ControllerBase
    {
        private readonly IWeightService _weightService;
        public WeightController(IWeightService weightService)
        {
            _weightService = weightService;
        }

        [HttpGet]
        [Produces(typeof(List<WeightDTO>))]
        public IActionResult GetWeights()
        {

            var resources = _weightService.GetAll();
            return new ObjectResult(resources);
        }

        [HttpGet("{id}")]
        [Produces(typeof(WeightDTO))]
        public IActionResult GetWeight([FromRoute] byte id)
        {
            var res = _weightService.GetWeight(id);
            return Ok(res);
        }

        [Authorize]
        [HttpPost]
        [Produces(typeof(WeightDTO))]
        public IActionResult PostWeight([FromBody] WeightDTO resource)
        {
            return Ok(_weightService.InsertWeight(resource));
        }

        [Authorize]
        [HttpPut("{id}")]
        [Produces(typeof(WeightDTO))]
        public IActionResult PutWeight([FromRoute] byte id, [FromBody] WeightDTO resource)
        {
            try
            {
                if (resource.Id != id) return BadRequest();
                return Ok(_weightService.UpdateWeight(resource));
            }
            catch (ModelNotFoundException)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        [Produces(typeof(WeightDTO))]
        public IActionResult InActiveWeight([FromRoute] byte id)
        {
            try
            {
                string result = string.Empty;
                result = _weightService.RemoveWeight(id);
                return Ok(result);
            }
            catch (ModelNotFoundException)
            {
                return NotFound();
            }
        }
    }


}