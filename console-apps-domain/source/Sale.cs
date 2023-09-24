namespace ConsoleApps.Domain;

public class Sale : Entity
{
    public Sale(Guid carId, Guid customerId, Guid dealershipId, Guid salespersonId, decimal price) : this(
        NewGuid(),
        carId,
        customerId,
        dealershipId,
        salespersonId,
        price
    )
    {
    }

    public Sale(Guid id, Guid carId, Guid customerId, Guid dealershipId, Guid salespersonId, decimal price) : base(id)
    {
        CarId = carId;
        CustomerId = customerId;
        DealershipId = dealershipId;
        SalespersonId = salespersonId;
        Price = price;
    }

    public Guid CarId { get; }
    public Guid CustomerId { get; }
    public Guid DealershipId { get; }
    public Guid SalespersonId { get; }
    public decimal Price { get; }
}
