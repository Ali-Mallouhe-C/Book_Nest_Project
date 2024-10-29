using System.ComponentModel.DataAnnotations;

namespace BookNest.Api.DTOs.RequestDTO
{
    public class CategoryRequestDTO
    {
        [Required]
        [MinLength(8), MaxLength(35)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(60)]
        public string Description { get; set; } = string.Empty;
    }
}
