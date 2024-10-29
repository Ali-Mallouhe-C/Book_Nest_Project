using BookNest.Domain.Enums;
using System.Text.Json.Serialization;

namespace BookNest.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        //Foreign Key: => relation between Book and Reservation (one to many) ---> required
        public int BookId { get; set; }

        //Foreign Key: => relation between User and Reservation (one to many) ---> required
        public int UserId { get; set; }

        //Foreign Key: => relation between Branch and Reservation (one to many) ---> required
        public int BranchId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ReservationStatus Status { get; set; } = ReservationStatus.Awaiting;

        public decimal Total { get; set; }

        public int BookNumber { get; set; } = 1;

        //Navigation Properties: User -- Book -- Branch
        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Book Book { get; set; }

        [JsonIgnore]
        public Branch Branch { get; set; }
    }
}