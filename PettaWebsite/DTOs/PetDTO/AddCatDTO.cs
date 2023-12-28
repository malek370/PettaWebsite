using PettaWebsite.Models;

namespace PettaWebsite.DTOs.PetDTO
{
    public class AddCatDTO:AddPetDTO
    {
        public override Pet Map( IMapper mapper)
        {
            return mapper.Map<Cat>(this);
        }
    }
}
