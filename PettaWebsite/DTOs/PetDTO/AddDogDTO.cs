using PettaWebsite.Models;

namespace PettaWebsite.DTOs.PetDTO
{
    public class AddDogDTO:AddPetDTO
    {
        public override Pet Map( IMapper mapper)
        {
            return mapper.Map<Dog>(this);
        }
    }
}
