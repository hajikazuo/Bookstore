using Bookstore.Domain.Entities;
using Bookstore.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loanstore.Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task<PagedList<Loan>> GetAll(int pageNumber, int pageSize);
        Task<Loan> GetById(Guid id);
        void Add(Loan loan);
        void Update(Loan loan);
        void Remove(Loan loan);
        Task<bool> SaveAllAsync();
        Task<bool> CheckAvailability(Guid id);
    }
}
