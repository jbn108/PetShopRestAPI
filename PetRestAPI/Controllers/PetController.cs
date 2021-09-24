using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTY.PetShop.Core.IServices;
using NTY.PetShop.Core.Models;

namespace PetRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _petService.ReadAll();
        }

        [HttpGet("id")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be greater than 0.");
            }
            return _petService.ReadById(id);
        }

        [HttpPost]
        public Pet Post([FromBody] Pet pet)
        {
            return _petService.Create(pet);
        }

        [HttpPut("id")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                if (id != pet.Id)
                {
                    return BadRequest("Id not matching!");
                }
                return Ok(_petService.UpdatePet(pet));
            }
            catch (Exception e)
            {
                return StatusCode(500, "KAN DU IKKE FINDE UD AF AT BRUGE INTERNETTET ELLER HVAD ER DU DUM!?");
            }
        }

        [HttpDelete ("id")]
        public ActionResult<Pet> Delete(int id)
        {
            var pet = _petService.Delete(id);
            if (pet == null) return StatusCode(404, "Did not find customer ID");
            return Ok($"Pet with id: {pet.Id} was deleted.");
        }
        
    }
}