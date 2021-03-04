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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Produces(typeof(List<ItemDTO>))]
        public IActionResult GetItems()
        {

            var resources = _itemService.GetAll();
            return new ObjectResult(resources);
        }

        [HttpGet("{id}")]
        [Produces(typeof(ItemDTO))]
        public IActionResult GetItem([FromRoute] byte id)
        {
            var res = _itemService.GetItem(id);
            return Ok(res);
        }

        [Authorize]
        [HttpPost]
        [Produces(typeof(ItemDTO))]
        public IActionResult PostItem([FromBody] ItemDTO resource)
        {
            return Ok(_itemService.InsertItem(resource));
        }

        [Authorize]
        [HttpPut("{id}")]
        [Produces(typeof(ItemDTO))]
        public IActionResult PutItem([FromRoute] byte id, [FromBody] ItemDTO resource)
        {
            try
            {
                if (resource.Id != id) return BadRequest();
                return Ok(_itemService.UpdateItem(resource));
            }
            catch (ModelNotFoundException)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        [Produces(typeof(ItemDTO))]
        public IActionResult InActiveItem([FromRoute] byte id)
        {
            try
            {
                string result = string.Empty;
                result = _itemService.RemoveItem(id);
                return Ok(result);
            }
            catch (ModelNotFoundException)
            {
                return NotFound();
            }
        }
    }


}