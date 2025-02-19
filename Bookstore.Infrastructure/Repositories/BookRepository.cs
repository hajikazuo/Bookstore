using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Pagination;
using Bookstore.Infrastructure.Context;
using Bookstore.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreDbContext _context;

        public BookRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Book>> GetAll(int pageNumber, int pageSize)
        {
            var query = _context.Books.AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }
        public void Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
