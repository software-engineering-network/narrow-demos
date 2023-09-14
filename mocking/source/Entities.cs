namespace Mocking;

public class Entity
{
    #region Creation

    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Entity(Guid id)
    {
        Id = id;
    }

    #endregion

    #region Implementation

    public Guid Id { get; }

    #endregion
}

public class Student : Entity
{
}

public class Class : Entity
{
    private readonly HashSet<Student> _students = new();

    #region Implementation

    public IReadOnlyList<Student> Students => _students.ToList().AsReadOnly();

    public Class Add(Student student)
    {
        _students.Add(student);
        return this;
    }

    #endregion
}

public class Enrollment : Entity
{
    #region Creation

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

    #endregion

    #region Implementation

    public Guid ClassId { get; }
    public Guid StudentId { get; }
    public DateTime EnrolledOn { get; }

    #endregion
}
