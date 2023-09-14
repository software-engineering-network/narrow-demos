namespace Mocking.Problems;

public class EmployeeService
{
    public EmployeeService(IScheduler scheduler)
    {
        _scheduler = scheduler;
    }

    private readonly IScheduler _scheduler;

    public Schedule Schedule(DateTime date, Employee[] employees) => _scheduler.Schedule(date, employees);

    //public Schedule Schedule(DateTime date, Employee[] employees) => new(date, employees);
}
