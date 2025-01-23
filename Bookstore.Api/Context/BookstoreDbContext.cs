using Bookstore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Api.Context
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookClientLending> BookClientLendings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookClientLending>()
                .HasOne(bcl => bcl.Book)
                .WithMany(b => b.Lendings)
                .HasForeignKey(bcl => bcl.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BookClientLending>()
                .HasOne(bcl => bcl.Client)
                .WithMany(c => c.Lendings)
                .HasForeignKey(bcl => bcl.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

    }
}
