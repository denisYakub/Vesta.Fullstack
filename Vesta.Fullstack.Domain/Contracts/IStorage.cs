using Vesta.Fullstack.Domain.Entities;

namespace Vesta.Fullstack.Domain.Contracts
{
    public interface IStorage
    {
        void Add(Order newOrder);
        Order Get(long id);
        IEnumerable<Order> GetAll();
        void Save();
    }
}
