using PettaWebsite.DTOs;
using PettaWebsite.DTOs.PetDTO;
using PettaWebsite.Models;

namespace PettaWebsite.Services.PetServices
{
    public interface IPetService
    {
        public Task<Response<Pet>> AddPet(AddPetDTO pet);
        public Task<Response<object>> DeletPet(string petId);
        public Task<Response<Pet>> GetPet(string petId);
        public Task<Response<List<Pet>>> GetAllPet(string petType);

    }
}
