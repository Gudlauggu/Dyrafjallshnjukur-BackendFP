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
    public class ProfileController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Profile
        [HttpGet]
        public IEnumerable<ProfileBO> Get()
        {
            return facade.ProfileService.GetAll();
        }

        // GET: api/Profile/5
        [HttpGet("{id}", Name = "GetProfile")]
        public ProfileBO Get(int id)
        {
            return facade.ProfileService.Get(id);
        }

        // POST: api/Profile
        [HttpPost]
        public IActionResult Post([FromBody]ProfileBO p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.ProfileService.Create(p));
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProfileBO p)
        {
            if (id != p.Id)
            {
                return BadRequest("Path ID does not match object ID in json object");
            }

            try
            {
                return Ok(facade.ProfileService.Update(p));
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
                return Ok(facade.ProfileService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}