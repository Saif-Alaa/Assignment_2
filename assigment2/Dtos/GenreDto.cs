using System.ComponentModel.DataAnnotations;

namespace assigment2.Dtos
{
    public class GenreDto
    {
        public int Id { get; set; }
 
        public string Name { get; set; }

    }

    public class CreateGenreDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }   
}
