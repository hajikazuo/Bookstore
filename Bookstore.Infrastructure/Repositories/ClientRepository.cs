using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Pagination;
using Bookstore.Infrastructure.Context;
using Bookstore.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BookstoreDbContext _context;

        public ClientRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Client>> GetAll(int pageNumber, int pageSize)
        {
            var query = _context.Clients.AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
        }

        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
        }

        public void Remove(Client client)
        {
            _context.Clients.Remove(client);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
