namespace ConsoleApps.ConsoleApp;

public class WelcomePrompter : IPrompter
{
    public bool Prompt()
    {
        Write("\n  Press any key to continue...");
        ReadKey();
        return true;
    }
}

public class WelcomeView : IView
{
    public void Print()
    {
        WriteLine("\n\tWelcome!");
    }
}
