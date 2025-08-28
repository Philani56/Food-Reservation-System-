using System.ComponentModel.DataAnnotations;

namespace Food_Reservation.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Store hashed password
    }
}
