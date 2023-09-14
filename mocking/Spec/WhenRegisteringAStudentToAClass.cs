using FluentAssertions;
using FluentAssertions.Execution;

namespace Mocking.Spec;

public class WhenRegisteringAStudentToAClass
{
    #region Setup

    private readonly Class _class = new();
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly Enrollment _enrollment;
    private readonly Student _student = new();

    public WhenRegisteringAStudentToAClass()
    {
        var service = new EnrollmentService(_dateTimeProvider = new MockDateTimeProvider());

        _enrollment = service.Register(_student, _class);
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenEnrollmentIsExpected()
    {
        using var scope = new AssertionScope();
        _enrollment.ClassId.Should().Be(_class.Id);
        _enrollment.StudentId.Should().Be(_student.Id);
        _enrollment.EnrolledOn.Should().Be(_dateTimeProvider.Now);
    }

    [Fact]
    public void ThenStudentWasAddedToClass() => _class.Students.Should().Contain(_student);

    #endregion
}
