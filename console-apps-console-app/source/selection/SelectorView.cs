namespace ConsoleApps.ConsoleApp;

public class SelectorView<T> : IView
{
    private readonly SelectorViewModel<T> _vm;

    public SelectorView(SelectorViewModel<T> vm)
    {
        _vm = vm;
    }

    public void Print()
    {
        if (_vm.MaxPage > 0)
            WriteLine($"\n\n  CurrentPage {_vm.CurrentPage} of {_vm.MaxPage}\n\n");

        var values = _vm.GetValues();

        for (var i = 0; i < values.Count; i++)
            WriteLine($"    {i}. {values[i]}");
    }
}

public interface ISelectorViewModel<out T>
{
    T? Selection { get; }
    bool Select(int index);
}

public abstract class SelectorViewModel<T> : IViewModel, ISelectorViewModel<T>
{
    protected readonly IPageable<T> _pageable = new BasicPageable<T>();

    public int CurrentPage => _pageable.CurrentPage;
    public int MaxPage => _pageable.MaxPage;

    public IReadOnlyList<T> GetValues() => _pageable.GetValues();
    public void NextPage() => _pageable.NextPage();
    public void PreviousPage() => _pageable.PreviousPage();

    public T? Selection { get; private set; }

    public bool Select(int index)
    {
        if (_pageable.Count <= index)
        {
            Selection = default;
            return false;
        }

        Selection = _pageable[index];

        return true;
    }
}
