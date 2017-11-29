using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;

namespace AppRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Order
        [HttpGet]
        public IEnumerable<OrderBO> Get()
        {
            return facade.OrderService.GetAll();
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "GetOrder")]
        public OrderBO Get(int id)
        {
            return facade.OrderService.Get(id);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody]OrderBO o)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.OrderService.Create(o));
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderBO o)
        {
            if (id != o.Id)
            {
                return BadRequest("Path ID does not match object ID in json object");
            }

            try
            {
                return Ok(facade.OrderService.Update(o));
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
                return Ok(facade.OrderService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}