namespace ConsoleApps.ConsoleApp;

public interface IView
{
    void Print();
}

public class CompositeView : IView
{
    private readonly List<IView> _views;

    public CompositeView(params IView[] views)
    {
        _views = new();
        _views.AddRange(views);
    }

    public void Print()
    {
        foreach (var view in _views)
            view.Print();
    }
}
