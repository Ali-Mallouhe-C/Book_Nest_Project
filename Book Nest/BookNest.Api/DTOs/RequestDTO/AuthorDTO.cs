using System.ComponentModel.DataAnnotations;

namespace BookNest.Api.DTOs.RequestDTO
{
    public class AuthorRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(60)]
        public string BIO { get; set; } = string.Empty;

        [Required]
        public DateTime DOB { get; set; }
    }
}
