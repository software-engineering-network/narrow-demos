using FluentAssertions;
using FluentAssertions.Execution;

namespace Mocking.Problems.Spec;

public class WhenSchedulingEmployees
{
    #region Requirements

    [Fact]
    public void ThenReturnSchedule()
    {
        var scheduler = new Scheduler();
        var service = new EmployeeService(scheduler);
        var employees = new Employee[] { "Amber", "Johnny", "Camille" };

        var schedule = service.Schedule(new DateTime(2023, 9, 9), employees);

        using var scope = new AssertionScope();

        schedule[Shift.First].Name.Should().Be("Amber");
        schedule[Shift.Second].Name.Should().Be("Johnny");
        schedule[Shift.Third].Name.Should().Be("Camille");
    }

    [Fact]
    public void ThenSchedulerWasCalled()
    {
        var scheduler = new SpyScheduler();
        var service = new EmployeeService(scheduler);
        var employees = new Employee[] { "Amber", "Johnny", "Camille" };

        var schedule = service.Schedule(new DateTime(2023, 9, 9), employees);

        using var scope = new AssertionScope();

        scheduler.TimesCalled.Should().Be(1);
    }

    #endregion
}

public class SpyScheduler : IScheduler
{
    public int TimesCalled { get; private set; }

    public Schedule Schedule(DateTime date, Employee[] employees)
    {
        TimesCalled++;
        return new Schedule(date, employees);
    }
}
