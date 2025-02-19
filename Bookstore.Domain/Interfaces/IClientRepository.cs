using Bookstore.Domain.Entities;
using Bookstore.Domain.Pagination;

namespace Bookstore.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<PagedList<Client>> GetAll(int pageNumber, int pageSize);
        Task<Client> GetById(Guid id);
        void Add(Client client);
        void Update(Client client);
        void Remove(Client client);
        Task<bool> SaveAllAsync();
    }
}
