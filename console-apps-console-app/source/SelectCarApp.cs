//using ConsoleApps.Domain;
//using ConsoleApps.Infrastructure.Read;
//using Car = ConsoleApps.Infrastructure.Read.Car;

//public class SelectCarApp : IApp
//{
//    private readonly List<Car> _cars = new();
//    private readonly Query.IHandler<FetchCars, IEnumerable<Car>> _fetchCarsHandler;

//    public SelectCarApp(Query.IHandler<FetchCars, IEnumerable<Car>> fetchCarsHandler)
//    {
//        _fetchCarsHandler = fetchCarsHandler;
//    }

//    private void DisplayChoices()
//    {
//        for (var i = 0; i < _cars.Count; i++)
//            Console.WriteLine($"{i + 1,2:##}. {_cars[i].GetDisplayString()}");
//    }

//    private void FetchCars()
//    {
//        _cars.Clear();

//        var cars = _fetchCarsHandler.Handle(new FetchCars());

//        _cars.AddRange(cars);
//    }

//    private void Prompt()
//    {
//        Console.Write("Pick car");
//        try
//        {
//            index = int.Parse(Console.ReadLine() ?? string.Empty);
//        }
//        catch (Exception e)
//        {
//        }
//    }

//    public void Run()
//    {
//        FetchCars();

//        var index = 0;

//        while (index == 0)
//        {
//            Console.Clear();
//            DisplayChoices();
//            Prompt();
//        }
//    }
//}

//public static class Extensions
//{
//    public static string GetDisplayString(this Car car)
//    {
//        var (_, make, model, year) = car;
//        return $"{year} {make} {model}";
//    }
//}


