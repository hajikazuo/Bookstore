using Bookstore.Domain.Entities;
using Bookstore.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<PagedList<Book>> GetAll(int pageNumber, int pageSize);
        Task<Book> GetById(Guid id);
        void Add(Book book);
        void Update(Book book);
        void Remove(Book book);
        Task<bool> SaveAllAsync();
    }
}
