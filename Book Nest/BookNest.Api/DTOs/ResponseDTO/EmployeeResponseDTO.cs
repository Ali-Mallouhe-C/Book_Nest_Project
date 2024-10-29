using BookNest.Domain.Entities;

namespace BookNest.Api.DTOs.ResponseDTO
{
    public class EmployeeResponseDTO
    {
        public string Name { get; set; }

        public int UserId { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public Branch Branch { get; set; }
    }
}
