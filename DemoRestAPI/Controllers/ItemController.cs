using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using BLL;
using BLL.BusinessObjects;

namespace AppRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Item
        [HttpGet]
        public IEnumerable<ItemBO> Get()
        {
            return facade.ItemService.GetAll();
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public ItemBO Get(int id)
        {
            return facade.ItemService.Get(id);
        }

        // POST: api/Item
        [HttpPost]
        public IActionResult Post([FromBody]ItemBO i)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.ItemService.Create(i));
        }

        // PUT: api/Video/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ItemBO i)
        {
            if (id != i.Id)
            {
                return BadRequest("Path ID does not match item ID in json object");
            }

            try
            {
                return Ok(facade.ItemService.Update(i));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(facade.ItemService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}