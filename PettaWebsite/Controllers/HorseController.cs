using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PettaWebsite.DTOs;
using PettaWebsite.DTOs.PetDTO;
using PettaWebsite.Models;
using PettaWebsite.Services.PetServices;

namespace PettaWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly IPetService _petService;
        public HorseController(IPetService petService)
        {
            _petService = petService;
        }
        [HttpPost]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> AddDog(AddHorseDTO horse)
        {
            var result = await _petService.AddPet(horse);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpGet("Horse")]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> Get(string horse)
        {
            var result = await _petService.GetPet(horse);
            if (result.Success) { return Ok(result.Data); }
            else { return BadRequest(result); }
        }
        [HttpGet("HorseAll")]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _petService.GetAllPet<Horse>();
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpDelete]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> Delete(string HorseId)
        {
            var result = await _petService.DeletPet(HorseId);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        //by user to add

    }
}
