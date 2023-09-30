using ConsoleApps.ConsoleApp;
using ConsoleApps.Domain;
using ConsoleApps.Infrastructure.Read;
using static System.Console;
using Car = ConsoleApps.ConsoleApp.Car;

public enum States
{
    Login,
    SelectCar
}

public class App : IApp
{
    private readonly SelectorViewModel<Car> _carViewModel;
    private readonly bool _isRunning = true;
    private readonly State _state;

    public App(Query.IHandler<FetchCars, IEnumerable<ConsoleApps.Infrastructure.Read.Car>> fetchCarsHandler)
    {
        _state = new Login(this);
        _carViewModel = new(() => fetchCarsHandler.Handle(new()).Select(x => (Car) x));
    }

    public void Run()
    {
        while (_isRunning)
        {
            _state.Display();

            ReadKey();
        }
    }
}

public abstract class State
{
    protected readonly App App;
    protected readonly List<IView> Views = new();

    protected State(App app)
    {
        App = app;
    }

    public void Display()
    {
        Clear();
        foreach (var view in Views)
            view.Print();

        Prompt();
    }

    public abstract void EnterState();
    public abstract void OnStateEntered();
    public abstract void Prompt();
}

public class Login : State
{
    public Login(App app) : base(app)
    {
    }

    public override void EnterState()
    {
    }

    public override void OnStateEntered()
    {
        throw new NotImplementedException();
    }

    public override void Prompt()
    {
        throw new NotImplementedException();
    }
}

public class Selecting<T> : State
{
    private readonly SelectorViewModel<T> _vm;

    public Selecting(App app, SelectorViewModel<T> vm) : base(app)
    {
        _vm = vm;
    }

    public override void EnterState()
    {
        Views.Clear();
        Views.Add(new SelectorView<T>(_vm));
    }

    public override void OnStateEntered()
    {
        throw new NotImplementedException();
    }

    public override void Prompt()
    {
        Write($"{typeof(T).Name}> ");

        ConsoleKeyInfo key;

        do
        {
            key = ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                case ConsoleKey.D6:
                case ConsoleKey.D7:
                case ConsoleKey.D8:
                case ConsoleKey.D9:
                case ConsoleKey.D0:
                case ConsoleKey.NumPad1:
                case ConsoleKey.NumPad2:
                case ConsoleKey.NumPad3:
                case ConsoleKey.NumPad4:
                case ConsoleKey.NumPad5:
                case ConsoleKey.NumPad6:
                case ConsoleKey.NumPad7:
                case ConsoleKey.NumPad8:
                case ConsoleKey.NumPad9:
                case ConsoleKey.NumPad0:
                    if (_vm.TrySelect(int.Parse(key.KeyChar.ToString()), out var selection))
                    {
                        //var state = 
                    }

                    break;
                case ConsoleKey.Q:
                case ConsoleKey.X:
                case ConsoleKey.Escape:
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    _vm.PreviousPage();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    _vm.NextPage();
                    break;
            }
        } while (true);
    }
}
