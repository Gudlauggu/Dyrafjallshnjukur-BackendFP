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

    public class UserController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/User
        [HttpGet]
        public IEnumerable<UserBO> Get()
        {
            return facade.UserService.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public UserBO Get(int id)
        {
            return facade.UserService.Get(id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody]UserBO p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.UserService.Create(p));
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserBO p)
        {
            if (id != p.Id)
            {
                return BadRequest("Path ID does not match pub ID in json object");
            }

            try
            {
                return Ok(facade.UserService.Update(p));
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
                return Ok(facade.UserService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
