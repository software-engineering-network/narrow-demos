namespace ConsoleApps.Domain;

public class SalesService : ISalesService
{
    public Sale MakeSale(Car car, Customer customer, Dealership dealership, Salesperson salesperson, decimal price) =>
        new(car.Id, customer.Id, dealership.Id, salesperson.Id, price);
}
