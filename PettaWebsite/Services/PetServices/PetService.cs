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
                pet.Owner = await _userManager!.GetUserAsync(_contextAccessor.HttpContext!.User);
                pet.Created= DateTime.Now;
                await _dbContext.AddAsync(pet);
                await _dbContext.SaveChangesAsync();
                result.Data = pet ;
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public async Task<Response<object>> DeletPet(string petId)
        {
            var result = new Response<object>();
            try
            {
                
                Pet? pet=await _dbContext.Pets.FirstOrDefaultAsync(p=>p.Id==petId);
                if(pet==null) { throw new Exception("Pet not found"); }
                _dbContext.Remove(pet);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public async Task<Response<List<GetPetDTO>>> GetAllPet<T>()where T:Pet
        {
            var result = new Response<List<GetPetDTO>>();
            try
            {
                
                result.Data = await _dbContext.Pets
                    .Include(p=>p.Owner)
                    .OfType<T>()
                    .Select(p => p.Map(_mapper))
                    .ToListAsync(); 

            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public async Task<Response<GetPetDTO>> GetPet(string petId)
        {
            var result = new Response<GetPetDTO>();
            try
            {
                GetPetDTO? pet=await _dbContext.Pets
                    .Include (p=>p.Owner)
                    .Select (p=>p.Map(_mapper))
                    .FirstOrDefaultAsync(p=>p.Id==petId) ;
                if (pet == null) { throw new Exception("Pet not found"); }
                result.Data=pet;
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public async Task<Response<List<GetPetDTO>>> GetPetsByUser()
        {
            var result = new Response<List<GetPetDTO>>();
            try
            {
                string userId = _userManager.GetUserAsync(_contextAccessor.HttpContext!.User).Result!.Id;
                result.Data = await _dbContext.Pets
                                        .Include(p => p.Owner)
                                        .Select(p => p.Map(_mapper))
                                        .ToListAsync();
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

    }
}
