namespace Mocking.Problems;

public interface IScheduler
{
    Schedule Schedule(DateTime date, Employee[] employees);
}

public class Scheduler : IScheduler
{
    public Schedule Schedule(DateTime date, Employee[] employees) => new(date, new Employee[3]);
}
