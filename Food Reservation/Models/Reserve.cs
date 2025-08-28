using System;
using System.ComponentModel.DataAnnotations;

namespace Food_Reservation.Models
{
    public class Reserve
    {
        [Key]
        public int ReserveId { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Reservation date is required")]
        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Pending";
    }
}
