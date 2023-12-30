using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PettaWebsite.DTOs.PetDOTs;
using PettaWebsite.Models;
using PettaWebsite.Services.PetServices;

namespace PettaWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IPetService<Dog,AddDogDTO,GetDogDTO> _DogService;
        public DogController(IPetService<Dog, AddDogDTO, GetDogDTO> petService) 
        {
            _DogService = petService;
        }
        [HttpPost]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> AddDog(AddDogDTO dog)
        {
            var result = await _DogService.AddPet(dog);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpGet()]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> Get(string dogId)
        {
            var result = await _DogService.GetPet(dogId);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpGet("All")]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _DogService.GetAllPet();
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpDelete]
        //[Authorize(Roles = "CLIENT")]
        public async Task<IActionResult> Delete(string petId)
        {
            var result = await _DogService.DeletPet(petId);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        //by user to add
    }
}
