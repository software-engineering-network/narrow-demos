using ConsoleApps.Domain;

namespace ConsoleApps.Services;

public record MakeSale(
    Guid CarId,
    Guid CustomerId,
    Guid DealershipId,
    Guid SalespersonId,
    decimal Price
) : Command;

public class MakeSaleHandler : Command.IHandler<MakeSale>
{
    private readonly ICarRepository _carRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IDealershipRepository _dealershipRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly ISalespersonRepository _salespersonRepository;
    private readonly ISalesService _salesService;

    public MakeSaleHandler(
        ICarRepository carRepository,
        ICustomerRepository customerRepository,
        IDealershipRepository dealershipRepository,
        ISaleRepository saleRepository,
        ISalespersonRepository salespersonRepository,
        ISalesService salesService
    )
    {
        _salesService = salesService;
        _carRepository = carRepository;
        _customerRepository = customerRepository;
        _dealershipRepository = dealershipRepository;
        _saleRepository = saleRepository;
        _salespersonRepository = salespersonRepository;
    }

    public void Handle(MakeSale command)
    {
        var (carId, customerId, dealershipId, salespersonId, price) = command;

        var car = _carRepository.Find(carId);
        var customer = _customerRepository.Find(customerId);
        var dealership = _dealershipRepository.Find(dealershipId);
        var salesperson = _salespersonRepository.Find(salespersonId);

        var sale = _salesService.MakeSale(car, customer, dealership, salesperson, price);

        _saleRepository.Create(sale);
    }
}
