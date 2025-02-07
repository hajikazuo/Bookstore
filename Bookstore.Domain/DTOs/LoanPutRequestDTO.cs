using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookstore.Domain.DTOs
{
    public class LoanPutRequestDTO
    {
        [Required]
        public DateTime? DevolutionDate { get; set; }

        [Required]
        public bool IsReturned { get; set; }
    }
}
