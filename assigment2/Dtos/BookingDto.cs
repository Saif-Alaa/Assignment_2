using assigment2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assigment2.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal Price { get; set; }

        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
    public class CreateBookingDto
    {
        [Required]
        public DateTime BookingDate { get; set; }
        [Range(1, int.MaxValue)]
        public int NumberOfTickets { get; set; }
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
