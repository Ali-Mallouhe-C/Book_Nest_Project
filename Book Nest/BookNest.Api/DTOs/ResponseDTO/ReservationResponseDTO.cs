using BookNest.Domain.Entities;
using BookNest.Domain.Enums;

namespace BookNest.Api.DTOs.ResponseDTO
{
    public class ReservationResponseDTO
    {
        public int BookId { get; set; }

        public int UserId { get; set; }

        public int BranchId { get; set; }

        public DateTime CreatedDate { get; set; }

        public ReservationStatus Status { get; set; }

        public decimal Total { get; set; }

        public int BookNumber { get; set; }

        public User User { get; set; }

        public Book Book { get; set; }

        public Branch Branch { get; set; }
    }
}
