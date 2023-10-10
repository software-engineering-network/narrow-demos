using ConsoleApps.Domain;
using ConsoleApps.Services;

namespace ConsoleApps.ConsoleApp;

public class CarSeeder : IApp
{
    private readonly Command.IHandler<PurchaseCar> _purchaseCarHandler;

    public CarSeeder(Command.IHandler<PurchaseCar> purchaseCarHandler)
    {
        _purchaseCarHandler = purchaseCarHandler;
    }

    public void Run()
    {
        Clear();

        WriteLine("\n  Stocking...");

        foreach (var command in GetCarsToPurchase())
        {
            _purchaseCarHandler.Handle(command);
            var (make, model, year) = command;
            WriteLine($"    Purchased {year} {make} {model} from supplier.");
        }

        Write("\n  Press any key to continue...");
        ReadKey();
    }

    private static IEnumerable<PurchaseCar> GetCarsToPurchase()
    {
        yield return new("Chevrolet", "Camaro", 2015);
        yield return new("Chevrolet", "Equinox", 2015);
        yield return new("Ford", "Mustang", 2015);
        yield return new("Ford", "Fusion", 2015);
        yield return new("Toyota", "Camry", 2015);
        yield return new("Toyota", "Prius", 2015);
        yield return new("Subaru", "Brz", 2015);
        yield return new("Subaru", "WRX", 2015);
        yield return new("Chevrolet", "Camaro", 2016);
        yield return new("Chevrolet", "Equinox", 2016);
        yield return new("Ford", "Mustang", 2016);
        yield return new("Ford", "Fusion", 2016);
        yield return new("Toyota", "Camry", 2016);
        yield return new("Toyota", "Prius", 2016);
        yield return new("Subaru", "Brz", 2016);
        yield return new("Subaru", "WRX", 2016);
    }
}
