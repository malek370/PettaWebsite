using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PettaWebsite.Models
{
    public class Pet
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Breed { get; set; }
        public bool Pure { get; set; }
        public int? Age { get; set; }
        public int? Weight { get; set; }
        public bool IsMale { get; set; }
        public string? Img { get; set; }
        public string? Description { get; set; }
        public required IdentityUser Owner { get; set; }
        public DateTime? Created { get; set; }

        
    }
    
}
