using System.Text.Json.Serialization;

namespace BookNest.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        //Foreign Key for User: 
        public int UserId { get; set; }

        //the name of employee
        public string Name { get; set; } =  string.Empty;

        //adding the number of employee:
        public string PhoneNumber { get; set; } = string.Empty;

        //Foreign Key for Branch:
        public int BranchId { get; set; }

        public decimal Salary { get; set; }

        //Navigation Properties:
        [JsonIgnore]
        public User User { get; set; }
        
        [JsonIgnore]
        public Branch Branch { get; set; }
    }
}