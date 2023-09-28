namespace ConsoleApps.ConsoleApp;

public class SelectorViewModel<T>
{
    private const int PageSize = 10;
    private readonly Func<IEnumerable<T>> _query;
    private readonly List<T> _values = new();
    private int _page;

    public SelectorViewModel(Func<IEnumerable<T>> query)
    {
        _query = query;
        Refresh();
    }

    public int MaxPage => (int) Math.Ceiling((float) _values.Count / PageSize);
    public int Page => _page + 1;

    public IReadOnlyList<T> Values =>
        _values
            .Skip(_page * PageSize)
            .Take(PageSize)
            .ToList()
            .AsReadOnly();

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
}
