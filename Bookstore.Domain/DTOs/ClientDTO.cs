using Bookstore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Domain.DTOs
{
    public class ClientDTO
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(14)]
        [MinLength(14)]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Neighborhood { get; set; }

        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        [MaxLength(14)]
        [RegularExpression(@"^\+?[0-9]*$", ErrorMessage = "Only numeric values are allowed.")]
        public string Cellphone { get; set; }

        [Required]
        [MaxLength(13)]
        [RegularExpression(@"^\+?[0-9]*$", ErrorMessage = "Only numeric values are allowed.")]
        public string Telephone { get; set; }
    }
}
