using System.ComponentModel.DataAnnotations;

namespace assigment2.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
