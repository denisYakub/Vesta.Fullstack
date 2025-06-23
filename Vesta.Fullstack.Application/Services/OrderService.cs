using Vesta.Fullstack.Domain.Contracts;
using Vesta.Fullstack.Domain.Entities;

namespace Vesta.Fullstack.Application.Services
{
    public class OrderService(IStorage storage)
    {
        public void CreateAndSaveNewOrder(
            string senderCity, string senderAddress,
            string recipientCity, string recipientAddress,
            float cargoWeightKilograms,
            DateTime cargoCollectionDate
        )
        {
            var newOrder = new Order(
                senderCity, senderAddress, 
                recipientCity, recipientAddress, 
                cargoWeightKilograms, 
                cargoCollectionDate
            );

            storage.Add(newOrder);
            storage.Save();
        }

        public IReadOnlyCollection<Order> GetAllOrders()
        {
            var orders = storage.GetAll();

            return [.. orders];
        }
    }
}
