using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PettaWebsite.DTOs.PetDOTs;
using PettaWebsite.Models;
using PettaWebsite.Services.PetServices;

namespace PettaWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly IPetService<Horse, AddHorseDTO, GetHorseDTO> _PetService;
        public HorseController(IPetService<Horse, AddHorseDTO, GetHorseDTO> petService)
        {
            _PetService = petService;
        }
        [HttpPost]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> AddDog(AddHorseDTO horse)
        {
            var result = await _PetService.AddPet(horse);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpGet()]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> Get(string horseId)
        {
            var result = await _PetService.GetPet(horseId);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpGet("All")]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _PetService.GetAllPet();
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpDelete]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> Delete(string petId)
        {
            var result = await _PetService.DeletPet(petId);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        //by user to add
    }
}
