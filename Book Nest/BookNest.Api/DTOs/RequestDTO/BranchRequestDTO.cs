using System.ComponentModel.DataAnnotations;

namespace BookNest.Api.DTOs.RequestDTO
{
    public class BranchRequestDTO
    {
        [Required]
        [MinLength(6), MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ContactNumber { get; set; } = string.Empty;
    }
}
