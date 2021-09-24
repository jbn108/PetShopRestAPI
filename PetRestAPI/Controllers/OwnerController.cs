using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NTY.PetShop.Core.IServices;
using NTY.PetShop.Core.Models;

namespace PetRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService iOwnerService)
        {
            _ownerService = iOwnerService;
        }
        // GET: api/Owner
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerService.ReadAll();
        }

        // GET: api/Owner/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be greater than 0.");
            }
            return _ownerService.ReadById(id);
        }

        // POST: api/Owner
        [HttpPost]
        public Owner Post([FromBody] Owner owner)
        {
            return _ownerService.Create(owner);
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest("Id not matching!");
            }
            return Ok(_ownerService.Update(owner));
        }

        // DELETE: api/Owner/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.Delete(id);
            if (owner == null) return StatusCode(404, "Did not find customer ID");
            return Ok($"Owner with id: {owner.Id} was deleted.");
        }
    }
}
