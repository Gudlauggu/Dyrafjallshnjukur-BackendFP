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
    public class SupplierController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/supplier
        [HttpGet]
        public IEnumerable<SupplierBO> Get()
        {
            return facade.SupplierService.GetAll();
        }

        // GET: api/supplier/5
        [HttpGet("{id}", Name = "GetSupplier")]
        public SupplierBO Get(int id)
        {
            return facade.SupplierService.Get(id);
        }

        // POST: api/supplier
        [HttpPost]
        public IActionResult Post([FromBody]SupplierBO s)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.SupplierService.Create(s));

        }

        // PUT: api/supplier/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SupplierBO s)
        {
            if (id != s.Id)
            {
                return BadRequest("Path ID does not match supplier ID in json object");
            }

            try
            {
                return Ok(facade.SupplierService.Update(s));
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
                return Ok(facade.SupplierService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}