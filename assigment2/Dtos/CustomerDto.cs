using System.ComponentModel.DataAnnotations;

namespace assigment2.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        public string? Phone { get; set; }
    }

    public class CreateCustomerDto
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
    }   
}
