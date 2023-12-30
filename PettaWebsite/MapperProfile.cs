using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PettaWebsite.DTOs.AuthDTOs;
using PettaWebsite.DTOs.PetDOTs;
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
            CreateMap<IdentityUser, OwnerDTO>();
            CreateMap<Cat, GetCatDTO>();
            CreateMap<Dog, GetDogDTO>();
            CreateMap<Horse, GetHorseDTO>();
        }
    }
}
