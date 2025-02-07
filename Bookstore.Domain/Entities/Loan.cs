namespace Bookstore.Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime? DevolutionDate { get; set; }
        public bool IsReturned { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Client? Client { get; set; }
    }
}
