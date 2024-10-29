using BookNest.Domain.Entities;

namespace BookNest.Api.DTOs.ResponseDTO
{
    public class BranchResponseDTO
    {
        public string Name { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
