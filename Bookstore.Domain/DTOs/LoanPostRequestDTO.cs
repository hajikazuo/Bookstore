using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookstore.Domain.DTOs
{
    public class LoanPostRequestDTO
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [JsonIgnore]
        public DateTime LendingDate { get; set; }
        public DateTime? DevolutionDate { get; set; }
    }
}
