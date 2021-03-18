using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Inventory.Controllers.api
{

    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemREpository)
        {
            _itemRepository = itemREpository;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetItems()
        {
            return Ok(_itemRepository.GetItems());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetItem(Guid id)
        {
            var item = _itemRepository.GetItem(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound($"Item not found:{id}");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddItem([FromBody]Item item)
        {
            if (!ModelState.IsValid) return BadRequest("Not valid!");
            _itemRepository.AddItem(item);
            return Ok(item);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteItem(Guid id)
        {
          _itemRepository.DeleteItem(id);
            return NoContent();
        }
    }
}