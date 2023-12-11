using FluentAssertions;

namespace Demo;

public class CollectionSyntax
{
    [Fact]
    public void NewCollectionSyntax()
    {
        int[] a = [1, 2, 3, 4, 5];
        List<int> b = [10, 20, 30, 40, 50];

        int[] result = [..a, ..b, 1001];

        result.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 10, 20, 30, 40, 50, 1001 });
    }
}

