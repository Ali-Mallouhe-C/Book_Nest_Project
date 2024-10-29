using System.Text.Json.Serialization;

namespace BookNest.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Passowred { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime LastLogIn { get; set; }

        //Foreign Key For Role 
        public int RoleId { get; set; }

        //Navigation Properties:
        [JsonIgnore]
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        
        public Role Role { get; set; }
    }
}