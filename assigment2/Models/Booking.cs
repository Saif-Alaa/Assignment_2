using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assigment2.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Range(1, int.MaxValue)]

        public int NumberOfTickets { get; set; }
        [Range(1, int.MaxValue)]

        public decimal Price { get; set; }

        [ForeignKey("Customer")]

        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
