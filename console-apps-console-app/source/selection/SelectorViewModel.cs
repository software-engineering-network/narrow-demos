namespace ConsoleApps.ConsoleApp;

public interface IPageable<T>
{
    T this[int index] { get; }
    int Count { get; }
    int CurrentPage { get; }
    int MaxPage { get; }
    IReadOnlyList<T> GetValues();
    void Load(IEnumerable<T> values);
    void NextPage();
    void PreviousPage();
}

public class BasicPageable<T> : IPageable<T>
{
    private const int PageSize = 10;
    protected readonly List<T> _values = new();
    private int _page;

    public T this[int index] => _values[index];
    public int Count => GetValues().Count;
    public int CurrentPage => _page + 1;
    public int MaxPage => (int) Math.Ceiling((float) _values.Count / PageSize);

    public IReadOnlyList<T> GetValues() =>
        _values
            .Skip(_page * PageSize)
            .Take(PageSize)
            .ToList()
            .AsReadOnly();

    public void Load(IEnumerable<T> values)
    {
        _values.Clear();
        _values.AddRange(values);
    }

    public void NextPage()
    {
        _page = Math.Min(MaxPage - 1, _page + 1);
    }

    public void PreviousPage()
    {
        _page = Math.Max(0, _page - 1);
    }
}
