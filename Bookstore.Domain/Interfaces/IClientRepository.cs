using Bookstore.Domain.Models;

namespace Bookstore.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(Guid id);
        void Add(Client client);
        void Update(Client client);
        void Remove(Client client);
        Task<bool> SaveAllAsync();
    }
}
