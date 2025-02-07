using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.DTOs
{
    public class LoanResponseDTO
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime? DevolutionDate { get; set; }
        public bool IsReturned { get; set; }

        public BookDTO BookDTO { get; set; }
        public ClientDTO ClientDTO { get; set; }
    }
}
