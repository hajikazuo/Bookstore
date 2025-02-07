using Bookstore.Domain.Entities;
using Bookstore.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Context
{
    public class BookstoreDbContext : IdentityDbContext<User, Role, Guid>
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        

    }
}
