using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookNest.Api.DTOs.RequestDTO
{
    public class LogInRequestDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Passowred { get; set; } = string.Empty;

        [ReadOnly(true)]
        public DateTime LastLogIn = DateTime.UtcNow;
    }
}
