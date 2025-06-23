using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vesta.Fullstack.Domain.Entities
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public long Id { get; private set; }
        [Column("sender_city")]
        public string SenderCity { get; private set; }
        [Column("sender_address")]
        public string SenderAddress { get; private set; }
        [Column("recipient_city")]
        public string RecipientCity { get; private set; }
        [Column("recipient_address")]
        public string RecipientAddress { get; private set; }
        [Column("cargo_weight_kilograms")]
        public float CargoWeightKilograms { get; private set; }
        [Column("cargo_collection_date")]
        public DateTime? CargoCollectionDate { get; private set; }

        public Order()
        {
            Id = 0;
            SenderCity = string.Empty;
            SenderAddress = string.Empty;
            RecipientCity = string.Empty;
            RecipientAddress = string.Empty;
            CargoWeightKilograms = 0;
            CargoCollectionDate = null;
        }

        public Order(
            string senderCity, string senderAddress,
            string recipientCity, string recipientAddress,
            float cargoWeightKilograms, DateTime cargoCollectionDate
        )
        {
            SenderCity = senderCity;
            SenderAddress = senderAddress;
            RecipientCity = recipientCity;
            RecipientAddress = recipientAddress;
            CargoWeightKilograms = cargoWeightKilograms;
            CargoCollectionDate = cargoCollectionDate.ToUniversalTime();
        }

        public Order(
            long id,
            string senderCity, string senderAddress,
            string recipientCity, string recipientAddress,
            float cargoWeightKilograms, DateTime cargoCollectionDate
        )
        {
            Id = id;
            SenderCity = senderCity;
            SenderAddress = senderAddress;
            RecipientCity = recipientCity;
            RecipientAddress = recipientAddress;
            CargoWeightKilograms = cargoWeightKilograms;
            CargoCollectionDate = cargoCollectionDate;
        }
    }
}
