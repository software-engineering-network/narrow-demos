using static System.Console;

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
        WriteLine("\n\n  Cars:");

        for (var i = 0; i < _vm.Values.Count; i++)
            WriteLine($"    {i}. {_vm.Values[i]}");

        if (_vm.MaxPage > 0)
            WriteLine($"\n\n  Page {_vm.Page} of {_vm.MaxPage}");
    }
}
