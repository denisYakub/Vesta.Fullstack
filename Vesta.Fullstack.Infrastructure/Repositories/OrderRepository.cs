using Vesta.Fullstack.Domain.Contracts;
using Vesta.Fullstack.Domain.Entities;
using Vesta.Fullstack.Infrastructure.DbContexts;

namespace Vesta.Fullstack.Infrastructure.Repositories
{
    public class OrderRepository(PostgresDbContext context) : IStorage
    {
        private readonly List<Order> items = new (10);

        public void Add(Order newOrder)
        {
            //context.Orders.Add(newOrder);
            items.Add(newOrder);
        }

        public Order Get(long id)
        {
            var order = 
                context
                .Orders
                .FirstOrDefault(o => o.Id == id);

            return order ?? throw new ArgumentException($"Cant find order with id - {id}");
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = context.Orders;

            return orders;
        }

        public void Save()
        {
            context.AddRange(items);
            context.SaveChanges();
        }
    }
}
