using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PettaWebsite.DataContext;
using PettaWebsite.DTOs;
using PettaWebsite.DTOs.PetDOTs;
using PettaWebsite.Models;

namespace PettaWebsite.Services.PetServices
{
    public class PetService<T, U, V> : IPetService<T, U, V> where T : Pet where U : AddPetDTO where V : GetPetDTO
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly IHttpContextAccessor _contextAccessor;
        public readonly IMapper _mapper;
        public readonly PettaDbContext _dbContext;
        public PetService(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper, PettaDbContext dbContext)
        {
            _contextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<Response<T>> AddPet(U petDTO)
        {
            var result = new Response<T>();
            try
            {
                T pet = _mapper.Map<T>(petDTO);
                pet.Owner = await _userManager!.GetUserAsync(_contextAccessor.HttpContext!.User);
                pet.Created = DateTime.Now;
                await _dbContext.AddAsync(pet);
                await _dbContext.SaveChangesAsync();
                result.Data = pet;
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public async Task<Response<object>> DeletPet(string petId)
        {
            var result = new Response<object>();
            try
            {

                Pet? pet = await _dbContext.Pets.FirstOrDefaultAsync(p => p.Id == petId);
                if (pet == null) { throw new Exception("Pet not found"); }
                _dbContext.Remove(pet);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public async  Task<Response<List<V>>> GetAllPet()
        {
            var result = new Response<List<V>>();
            try
            {

                result.Data = await _dbContext.Pets
                    .Include(p => p.Owner)
                    .OfType<T>()
                    .Select(p=>_mapper.Map<V>(p))
                    .ToListAsync();

            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public async Task<Response<V>> GetPet(string petId)
        {
            var result = new Response<V>();
            try
            {
                Pet? pet = await _dbContext.Pets
                    .Include(p => p.Owner)
                    .FirstOrDefaultAsync(p => p.Id == petId);
                if (pet == null) { throw new Exception("Pet not found"); }
                result.Data = _mapper.Map<V>(pet);
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public async Task<Response<List<V>>> GetPetsByUser()
        {
            var result = new Response<List<V>>();
            try
            {
                string userId = _userManager.GetUserAsync(_contextAccessor.HttpContext!.User).Result!.Id;
                result.Data = await _dbContext.Pets
                                        .Include(p => p.Owner)
                                        .Select(p => _mapper.Map<V>(p))
                                        .ToListAsync();
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result; ;
        }
    }
}
