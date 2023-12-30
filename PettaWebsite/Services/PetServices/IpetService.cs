using PettaWebsite.DTOs;
using PettaWebsite.DTOs.PetDOTs;
using PettaWebsite.Models;

namespace PettaWebsite.Services.PetServices
{
    public interface IPetService<T,U,V> where T : Pet  where U : AddPetDTO where V : GetPetDTO
    {
        public Task<Response<T>> AddPet(U pet);
        public Task<Response<object>> DeletPet(string petId);
        public Task<Response<V>> GetPet(string petId);
        public Task<Response<List<V>>> GetAllPet();
        public Task<Response<List<V>>> GetPetsByUser();
    }
}
