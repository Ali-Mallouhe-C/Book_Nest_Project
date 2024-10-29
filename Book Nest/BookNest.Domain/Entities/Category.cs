using System.Text.Json.Serialization;

namespace BookNest.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        //Navigation Properties:
        [JsonIgnore]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}