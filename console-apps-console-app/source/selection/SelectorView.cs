namespace ConsoleApps.ConsoleApp;

public class SelectorView<T> : IObserver<SelectorViewModel<T>>, IDisposable
{
    private readonly IDisposable _disposer;

    public SelectorView(SelectorViewModel<T> viewModel)
    {
        _disposer = viewModel.Subscribe(this);
    }

    public void Dispose() => _disposer.Dispose();

    public void OnCompleted() => Dispose();

    public void OnError(Exception error) => throw new NotImplementedException();

    public void OnNext(SelectorViewModel<T> viewModel)
    {
        Display(viewModel.Values);
    }

    private static void Display(IReadOnlyList<T> values)
    {
        for (var i = 0; i < values.Count; i++)
            Console.WriteLine($"{i}. {values[i]}");
    }
}
