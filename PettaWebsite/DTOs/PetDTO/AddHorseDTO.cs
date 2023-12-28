using PettaWebsite.Models;

namespace PettaWebsite.DTOs.PetDTO
{
    public class AddHorseDTO : AddPetDTO
    {
        public int Height { get; set; }

        public override Pet Map(IMapper mapper)
        {
            return mapper.Map<Horse>(this);
        }
    }
}
