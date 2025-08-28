using System.ComponentModel.DataAnnotations;

namespace Food_Reservation.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; } = "Pending";

        public List<ReservationItem> ReservationItems { get; set; }
    }
}
