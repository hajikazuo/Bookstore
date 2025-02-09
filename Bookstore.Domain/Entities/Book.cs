﻿using System.ComponentModel.DataAnnotations;

namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Author { get; set; }

        [Required]
        [MaxLength(100)]
        public string Publisher { get; set; }

        public int Year { get; set; }

        [Required]
        [MaxLength(50)]
        public string Edition { get; set; }

        public virtual ICollection<Loan>? Lendings { get; set; }
    }
}
