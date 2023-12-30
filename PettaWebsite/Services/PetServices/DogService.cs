using PettaWebsite.DTOs;
using PettaWebsite.DTOs.PetDOTs;
using PettaWebsite.Models;

namespace PettaWebsite.Services.PetServices
{
    public class DogService : IPetService<Dog, AddDogDTO, GetDogDTO>
    {
        public Task<Response<Dog>> AddPet(AddDogDTO pet)
        {
            throw new NotImplementedException();
        }

        public Task<Response<object>> DeletPet(string petId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<GetDogDTO>>> GetAllPet()
        {
            throw new NotImplementedException();
        }

        public Task<Response<GetDogDTO>> GetPet(string petId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<GetDogDTO>>> GetPetsByUser()
        {
            throw new NotImplementedException();
        }
    }
}
