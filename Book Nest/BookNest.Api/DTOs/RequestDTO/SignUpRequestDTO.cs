using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookNest.Api.DTOs.RequestDTO
{
    public class SignUpRequestDTO
    {
        [Required]
        [MinLength(10)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(10), MaxLength(26)]
        public string Passowred { get; set; } = string.Empty;

        [ReadOnly(true)]
        public int RoleId = 3;
    }
}