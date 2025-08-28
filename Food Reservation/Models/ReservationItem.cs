using System.ComponentModel.DataAnnotations;

namespace Food_Reservation.Models
{
    public class ReservationItem
    {
        [Key]
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public int ItemId { get; set; }
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }
    }
}
