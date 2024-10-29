using BookNest.Domain.Entities;

namespace BookNest.Api.DTOs.ResponseDTO
{
    public class BookResponseDTO
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime PublishYear { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImgUrl { get; set; } = string.Empty;

        public Category Category { get; set; }

        public Author Author { get; set; }

        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}