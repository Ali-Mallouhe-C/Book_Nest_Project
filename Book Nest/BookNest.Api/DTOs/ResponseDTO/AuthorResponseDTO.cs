using BookNest.Domain.Entities;
using System.Text.Json.Serialization;

namespace BookNest.Api.DTOs.ResponseDTO
{
    public class AuthorResponseDTO
    {
        public string Name { get; set; } = string.Empty;

        public string BIO { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        //Navigation Properties:
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
