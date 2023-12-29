using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PettaWebsite.DTOs.PetDTO;
using PettaWebsite.Models;
using PettaWebsite.Services.PetServices;

namespace PettaWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IPetService _petService;
        public DogController(IPetService petService)
        {
            _petService = petService;
        }
        [HttpPost]
        [Authorize(Roles ="CLIENT")]
        public async Task<IActionResult> AddDog(AddDogDTO dog)
        {
            var result = await _petService.AddPet(dog);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpGet("Dog")]
        [Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> Get(string dogId)
        {
            var result = await _petService.GetPet(dogId);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpGet("DogAll")]
        [Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _petService.GetAllPet<Dog>();
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpDelete]
        [Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> Delete(string petId)
        {
            var result = await _petService.DeletPet(petId);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        //by user to add

    }
}
