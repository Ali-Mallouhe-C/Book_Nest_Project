using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookNest.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Star { get; set; }

        public string FeedBack { get; set; } = string.Empty;

        //Foreign Key: => one Book With Many Ratings:
        public int BookId { get; set; }

        //Foreign Key: => one User With Many Ratings:
        public int UserId { get; set; }

        //Navigation Properties:
        [JsonIgnore]
        public Book Book { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}