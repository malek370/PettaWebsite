using PettaWebsite.DTOs.PetDTO;

namespace PettaWebsite.Models
{
    public class Cat : Pet
    {
        public override GetPetDTO Map(IMapper mapper)
        {
            return mapper.Map<GetCatDTO>(this);
        }
    }
}
