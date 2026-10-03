using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assigment2.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
    
        public string Title { get; set; }
  
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public decimal TicketPrice { get; set; }

        public int AvaillableSeats { get; set; }

        public decimal Rating { get; set; }

        public int GenreId { get; set; }
    }

    public class CreateMovieDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Director { get; set; }
        [Range(1950, 2026)]
        public int ReleaseYear { get; set; }
        [Range(30, 300)]
        public int Duration { get; set; }
        [Range(0, int.MaxValue)]
        public decimal TicketPrice { get; set; }
        [Range(0, int.MaxValue)]
        public int AvaillableSeats { get; set; }
        [Range(0, 10)]
        public decimal Rating { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
    }
}
