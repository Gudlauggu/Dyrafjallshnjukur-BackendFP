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
    public class PubController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Pub
        [HttpGet]
        public IEnumerable<PubBO> Get()
        {
            return facade.PubService.GetAll();
        }

        // GET: api/Pub/5
        [HttpGet("{id}", Name = "GetPub")]
        public PubBO Get(int id)
        {
            return facade.PubService.Get(id);
        }

        // POST: api/Pub
        [HttpPost]
        public IActionResult Post([FromBody]PubBO p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.PubService.Create(p));
        }

        // PUT: api/Pub/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PubBO p)
        {
            if (id != p.Id)
            {
                return BadRequest("Path ID does not match pub ID in json object");
            }

            try
            {
                return Ok(facade.PubService.Update(p));
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
                return Ok(facade.PubService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}