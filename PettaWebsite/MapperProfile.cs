using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PettaWebsite.DTOs.AuthDTOs;
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
            CreateMap<IdentityUser, UserDTO>();
            CreateMap<Cat, GetCatDTO>();
            CreateMap<Dog, GetDogDTO>();
            CreateMap<Horse, GetHorseDTO>();

        }

    }
}
