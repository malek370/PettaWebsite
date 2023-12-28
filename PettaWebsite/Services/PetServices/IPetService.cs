using PettaWebsite.DTOs;
using PettaWebsite.DTOs.PetDTO;
using PettaWebsite.Models;

namespace PettaWebsite.Services.PetServices
{
    public interface IPetService
    {
        public Task<Response<Pet>> AddPet(AddPetDTO pet);
        public Task<Response<object>> DeletPet(string petId);
        public Task<Response<GetPetDTO>> GetPet(string petId);
        public Task<Response<List<GetPetDTO>>> GetAllPet<T>() where T : Pet;
        public Task<Response<List<GetPetDTO>>> GetPetsByUser();
    }
}
