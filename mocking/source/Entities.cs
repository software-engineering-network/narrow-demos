namespace Mocking;

public class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}

public class Student : Entity
{
}

public class Class : Entity
{
    private readonly HashSet<Student> _students = new();

    public IReadOnlyList<Student> Students => _students.ToList().AsReadOnly();

    public Class Add(Student student)
    {
        _students.Add(student);
        return this;
    }
}

public class Enrollment : Entity
{
    public Enrollment(Guid classId, Guid studentId, DateTime enrolledOn)
    {
        ClassId = classId;
        StudentId = studentId;
        EnrolledOn = enrolledOn;
    }

    public Enrollment(Guid id, Guid classId, Guid studentId, DateTime enrolledOn) : base(id)
    {
        ClassId = classId;
        StudentId = studentId;
        EnrolledOn = enrolledOn;
    }

    public Guid ClassId { get; }
    public Guid StudentId { get; }
    public DateTime EnrolledOn { get; }
}
