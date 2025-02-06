using System.ComponentModel.DataAnnotations;

namespace Bookstore.Domain.Models
{
    public class Client
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(14)]
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
        public string Cellphone { get; set; }

        [Required]
        [MaxLength(13)]
        public string Telephone { get; set; }

        public virtual ICollection<BookClientLending>? Lendings { get; set; }
    }
}
