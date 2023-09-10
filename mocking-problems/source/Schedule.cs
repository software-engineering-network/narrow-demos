namespace Mocking.Problems;

public class Schedule
{
    public Schedule(DateTime date, Employee[] employees)
    {
        Date = date;

        var currentShift = Shift.First;

        foreach (var employee in employees)
        {
            _assignments.Add(currentShift, employee);
            currentShift = currentShift.Next();
        }
    }

    private readonly Dictionary<Shift, Employee> _assignments = new();

    public Employee this[Shift shift] => _assignments[shift];

    public DateTime Date { get; }
}
