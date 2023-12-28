using PettaWebsite.DTOs.PetDTO;

namespace PettaWebsite.Models
{
    public class Dog:Pet
    {
        public override GetPetDTO Map(IMapper mapper)
        {
            return mapper.Map<GetDogDTO>(this);
        }
    }
}
