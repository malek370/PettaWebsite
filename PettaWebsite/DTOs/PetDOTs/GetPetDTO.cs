using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PettaWebsite.DTOs.AuthDTOs;

namespace PettaWebsite.DTOs.PetDOTs
{
    public class GetPetDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Breed { get; set; }
        public bool Pure { get; set; }
        public int? Age { get; set; }
        public int? Weight { get; set; }
        public bool IsMale { get; set; }
        public string? Img { get; set; }
        public string? Description { get; set; }
        public OwnerDTO Owner { get; set; }
        public DateTime? Created { get; set; }
    }
}
