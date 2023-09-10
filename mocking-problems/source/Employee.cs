namespace Mocking.Problems;

public class Employee
{
    public Employee(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public static implicit operator Employee(string name) => new(name);
}
