using ConsoleApps.Domain;

namespace ConsoleApps.Services;

public record PurchaseCar(
    string Make,
    string Model,
    ushort Year
) : Command;

public class PurchaseCarHandler : Command.IHandler<PurchaseCar>
{
    private readonly ICarRepository _carRepository;

    public PurchaseCarHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public void Handle(PurchaseCar command)
    {
        var (make, model, year) = command;

        var car = new Car(make, model, year);

        _carRepository.Create(car);
    }
}
