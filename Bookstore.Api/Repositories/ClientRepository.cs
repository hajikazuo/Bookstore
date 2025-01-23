using Bookstore.Api.Context;
using Bookstore.Api.Interfaces;
using Bookstore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Api.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BookstoreDbContext _context;

        public ClientRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
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
