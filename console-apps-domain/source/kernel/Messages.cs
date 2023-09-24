namespace ConsoleApps.Domain;

public abstract record Command
{
    public interface IHandler<in T> where T : Command
    {
        void Handle(T command);
    }
}

public abstract record Query
{
    public interface IHandler<in T, out TResult> where T : Query
    {
        TResult Handle(T query);
    }
}
