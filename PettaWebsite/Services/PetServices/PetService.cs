global using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PettaWebsite.DataContext;
using PettaWebsite.DTOs;
using PettaWebsite.DTOs.PetDTO;
using PettaWebsite.Models;

namespace PettaWebsite.Services.PetServices
{
    public class PetService : IPetService
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly IHttpContextAccessor _contextAccessor;
        public readonly IMapper _mapper;
        public readonly PettaDbContext _dbContext;
        public PetService(UserManager<IdentityUser> userManager,IHttpContextAccessor httpContextAccessor,IMapper mapper, PettaDbContext dbContext)
        {
            _contextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<Response<Pet>> AddPet(AddPetDTO petDTO)
        {
            var result = new Response<Pet>();
            try
            {
                Pet pet=petDTO.Map(_mapper);
                //Pet pet = _mapper.Map(petDTO);
                //pet.Owner = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
                pet.Owner = await _userManager.FindByEmailAsync("admin@gamil.com");
                pet.Created= DateTime.Now;
                await _dbContext.AddAsync(pet);
                await _dbContext.SaveChangesAsync();
                result.Data = pet;
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public Task<Response<object>> DeletPet(string petId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Pet>>> GetAllPet(string petType)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Pet>> GetPet(string petId)
        {
            throw new NotImplementedException();
        }
    }
}
