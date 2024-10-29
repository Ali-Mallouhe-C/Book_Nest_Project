using BookNest.Domain.Entities;

namespace BookNest.Api.DTOs.ResponseDTO
{
    public class CategoryResponseDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Book> Books { get; set; }
    }
}
