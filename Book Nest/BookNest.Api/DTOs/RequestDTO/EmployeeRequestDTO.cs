using BookNest.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookNest.Api.DTOs.RequestDTO
{
    public class EmployeeRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int BranchId { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; }
    }
}
