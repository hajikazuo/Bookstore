﻿using Bookstore.Domain.Entities;
using Bookstore.Domain.Pagination;
using Bookstore.Infrastructure.Context;
using Bookstore.Infrastructure.Helpers;
using loanstore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BookstoreDbContext _context;

        public LoanRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Loan>> GetAll(int pageNumber, int pageSize)
        {
            var query = _context.Loans
                .Include(c => c.Client)
                .Include(c => c.Book)
                .AsQueryable();

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Loan> GetById(Guid id)
        {
            return await _context.Loans
                .Include(c => c.Client)
                .Include(c => c.Book)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Add(Loan loan)
        {
            _context.Loans.Add(loan);
        }

        public void Update(Loan loan)
        {
            _context.Entry(loan).State = EntityState.Modified;
        }

        public void Remove(Loan loan)
        {
            _context.Loans.Remove(loan);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CheckAvailability(Guid id)
        {
            var available = await _context.Loans.Where(x => x.BookId == id && x.IsReturned == false).AnyAsync();
            return !available;
        }
    }
}
