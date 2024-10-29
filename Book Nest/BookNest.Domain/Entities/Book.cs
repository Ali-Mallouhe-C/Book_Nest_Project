using System.Text.Json.Serialization;

namespace BookNest.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime PublishYear { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImgUrl { get; set; } = string.Empty;

        //Foreign Key: => relation between Category and Book (one to many) ---> required
        public int CategoryId { get; set; }

        //Foreign Key: => relation between Author and Book (one to many) ---> required
        public int AuthorId { get; set; }

        //Navigation Properties:
        [JsonIgnore]
        public Author Author { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
        
        [JsonIgnore]
        public List<Rating> Ratings { get; set; } = new List<Rating>();

        [JsonIgnore]
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}