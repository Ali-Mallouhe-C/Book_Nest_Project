using BookNest.Domain.Entities;
using BookNest.Domain.Enums;
using System.Text.Json.Serialization;

namespace BookNest.Api.DTOs.RequestDTO
{
    public class ReservationRequestDTO
    {
        public int BookId { get; set; }

        public int UserId { get; set; }

        public int BranchId { get; set; }

        public ReservationStatus Status { get; set; }

        public decimal Total { get; set; }

        public int BookNumber { get; set; }
    }
}