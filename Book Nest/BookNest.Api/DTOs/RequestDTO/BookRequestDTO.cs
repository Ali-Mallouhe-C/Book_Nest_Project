using BookNest.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookNest.Api.DTOs.RequestDTO
{
    public class BookRequestDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(30)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime PublishYear { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string ImgUrl { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int AuthorId { get; set; }

    }
}
