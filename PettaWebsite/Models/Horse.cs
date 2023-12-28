using PettaWebsite.DTOs.PetDTO;

namespace PettaWebsite.Models
{
    public class Horse:Pet
    {
        public int Height { get; set; }
        public override GetPetDTO Map(IMapper mapper)
        {
            return mapper.Map<GetHorseDTO>(this);
        }
    }
}
