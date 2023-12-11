using FluentAssertions;
using NSubstitute;

namespace Demo;

public class PrimaryConstructorDemoTest
{
    [Fact]
    public void PrimaryConstructorDemo()
    {
        // Arrange
        var expectedDate = new DateTimeOffset(new DateTime(2023, 11, 20, 12, 31, 0));
        var timeProviderStub = Substitute.For<TimeProvider>();
        timeProviderStub.GetUtcNow().Returns(expectedDate);
        
        // Act
        var sut = new PeopleService(timeProviderStub);
        sut.AddNewPerson("Harry", "Potter");
        
        // Assert
        var person = sut.Storage.First();
        person.FirstName.Should().Be("Harry");
        person.LastName.Should().Be("Potter");
        person.CreationDate.Should().Be(expectedDate);
    }
}

file class Person(Guid id, string firstName, string lastName, DateTimeOffset creationDate)
{
    public Guid Id { get; } = id;

    public string FirstName { get; set; } = firstName;

    public string LastName { get; set; } = lastName;

    public DateTimeOffset CreationDate { get; } = creationDate;
}

file class PeopleService(TimeProvider timeProvider)
{
    public List<Person> Storage { get; } = new();

    public Guid AddNewPerson(string firstName, string lastName)
    {
        var person = new Person(Guid.NewGuid(), firstName, lastName, timeProvider.GetUtcNow());
        Storage.Add(person);
        return person.Id;
    }
}