using AutoMapper;
using PettaWebsite.DTOs.PetDTO;
using PettaWebsite.Models;

namespace PettaWebsite
{
    public class MapperProfile:Profile
    {
        public MapperProfile() 
        {
            CreateMap<AddCatDTO, Cat>();
            CreateMap<AddHorseDTO, Horse>();
            CreateMap<AddDogDTO, Dog>();
            
        }

    }
}
