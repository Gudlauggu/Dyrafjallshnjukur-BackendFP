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
    public class ItemTypeController : Controller
    {
            BLLFacade facade = new BLLFacade();

            // GET: api/ItemType
            [HttpGet]
            public IEnumerable<ItemTypeBO> Get()
            {
                return facade.ItemTypeService.GetAll();
            }

            // GET: api/ItemType/5
            [HttpGet("{id}", Name = "GetItemType")]
            public ItemTypeBO Get(int id)
            {
                return facade.ItemTypeService.Get(id);
            }

            // POST: api/ItemType
            [HttpPost]
            public IActionResult Post([FromBody]ItemTypeBO i)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(facade.ItemTypeService.Create(i));
            }

            // PUT: api/VideoType/5
            [HttpPut("{id}", Name = "PutItemType")]
            public IActionResult Put(int id, [FromBody]ItemTypeBO i)
            {
                if (id != i.Id)
                {
                    return BadRequest("Path ID does not match ItemType ID in json object");
                }

                try
                {
                    return Ok(facade.ItemTypeService.Update(i));
                }
                catch (InvalidOperationException e)
                {
                    return StatusCode(404, e.Message);
                }

            }

            // DELETE: api/ApiWithActions/5
            [HttpDelete("{id}", Name = "DeleteItemType")]
            public IActionResult Delete(int id)
            {
                try
                {
                    return Ok(facade.ItemTypeService.Delete(id));
                }
                catch (InvalidOperationException e)
                {
                    return StatusCode(404, e.Message);
                }
            }
        }
    
}