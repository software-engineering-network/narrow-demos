namespace ConsoleApps.ConsoleApp;

public class SelectorViewModel<T> : IObservable<SelectorViewModel<T>>
{
    private const int PageSize = 10;
    private readonly List<IObserver<SelectorViewModel<T>>> _observers = new();
    private readonly Func<IEnumerable<T>> _query;
    private readonly List<T> _values = new();
    private int _page;

    public SelectorViewModel(Func<IEnumerable<T>> query)
    {
        _query = query;
        Refresh();
    }

    public int Page => _page + 1;

    public IReadOnlyList<T> Values =>
        _values
            .Skip(_page * PageSize)
            .Take(PageSize)
            .ToList()
            .AsReadOnly();

    private int MaxPage => (int) Math.Ceiling((float) _values.Count / PageSize);

    public SelectorViewModel<T> NextPage()
    {
        _page = Math.Min(MaxPage - 1, _page + 1);
        return this;
    }

    public SelectorViewModel<T> PreviousPage()
    {
        _page = Math.Max(0, _page - 1);
        return this;
    }

    public SelectorViewModel<T> Refresh()
    {
        _values.Clear();
        _values.AddRange(_query());
        _page = 0;
        return this;
    }

    public T Select(int index)
    {
        var selection = Values[index];

        Refresh();

        return selection;
    }

    public void Unsubscribe(IObserver<SelectorViewModel<T>> observer)
    {
        if (_observers.Any(x => x == observer))
            _observers.Remove(observer);
    }

    public IDisposable Subscribe(IObserver<SelectorViewModel<T>> observer)
    {
        _observers.Add(observer);
        return new Disposer(observer, this);
    }

    private class Disposer : IDisposable
    {
        private readonly IObserver<SelectorViewModel<T>> _observer;
        private readonly SelectorViewModel<T> _viewModel;

        public Disposer(IObserver<SelectorViewModel<T>> observer, SelectorViewModel<T> viewModel)
        {
            _observer = observer;
            _viewModel = viewModel;
        }

        public void Dispose() => _viewModel.Unsubscribe(_observer);
    }
}
