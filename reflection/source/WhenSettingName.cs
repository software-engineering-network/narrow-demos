using FluentAssertions;

namespace Reflection;

public class WhenSettingName
{
    #region Implementation

    public static IEnumerable<object[]> GetNameables()
    {
        yield return new object[] { new Person(), "jhope" };
        yield return new object[] { new Product(), "sprite" };
    }

    #endregion

    #region Requirements

    [Theory]
    [MemberData(nameof(GetNameables))]
    public void WithNameableObjects_ThenNameIsSet(object obj, string name)
    {
        // we don't know the specific type, so we get it at runtime
        var type = obj.GetType();

        // we can get a property by its name. this is the reflection part.
        var nameProperty = type.GetProperties().First(x => x.Name.Contains("Name"));

        // we can assign the target "Name" property on the given object obj
        nameProperty.SetValue(obj, name);

        // we can check the "Name" property value
        nameProperty.GetValue(obj).Should().Be(name);
    }

    #endregion
}

public class Person
{
    public string FirstName { get; set; }
}

public class Product
{
    public string Name { get; set; }
}
