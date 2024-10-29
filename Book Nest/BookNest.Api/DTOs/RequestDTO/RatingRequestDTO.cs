using System.ComponentModel.DataAnnotations;

namespace BookNest.Api.DTOs.RequestDTO
{
    public class RatingRequestDTO
    {
        [Range(1, 5)]
        [Required]
        public int Star { get; set; }

        [Required]
        [MaxLength(80)]
        public string FeedBack { get; set; } = string.Empty;

        [Required]
        public int BookId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
