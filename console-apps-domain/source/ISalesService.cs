namespace ConsoleApps.Domain;

public interface ISalesService
{
    Sale MakeSale(Car car, Customer customer, Dealership dealership, Salesperson salesperson, decimal price);
}
