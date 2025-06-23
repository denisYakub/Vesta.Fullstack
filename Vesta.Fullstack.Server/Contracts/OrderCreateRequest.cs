namespace Vesta.Fullstack.Server.Contracts
{
    public record struct OrderCreateRequest(
        string SenderCity,
        string SenderAddress,
        string RecipientCity,
        string RecipientAddress,
        float CargoWeightKilograms,
        DateTime CargoCollectionDate
    );
}
