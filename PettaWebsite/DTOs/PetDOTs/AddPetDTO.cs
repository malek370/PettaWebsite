namespace PettaWebsite.DTOs.PetDOTs
{
    public class AddPetDTO
    {
        public string Name { get; set; }
        public string? Breed { get; set; }
        public bool Pure { get; set; }
        public int? Age { get; set; }
        public int? Weight { get; set; }
        public bool IsMale { get; set; }
        public string? Img { get; set; }
        public string? Description { get; set; }
    }
}
