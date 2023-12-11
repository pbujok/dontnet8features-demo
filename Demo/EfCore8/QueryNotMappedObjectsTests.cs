using Demo.EfCore8.Dal;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Demo.EfCore8;

public class QueryNotMappedObjectsTests
{
    [Fact]
    public void ReadUnmappedObject()
    {
        using var context = new TestContext();

        var address = new Address("Private drive 4", "N1C 4AX", "Little Whinging");
        var party = new Party("Harry Potter", address, address);

        party.DeclareIncome(new Income(new DateOnly(2021, 1, 1), new DateOnly(2021, 12, 31), 10000));
        party.DeclareIncome(new Income(new DateOnly(2022, 1, 1), new DateOnly(2022, 12, 31), 20000));

        context.Parties.Add(party);
        context.SaveChanges();


        var data = context.Database.SqlQuery<IncomeViewDto>(
                $"SELECT p.[Name], i.DateFrom, i.DateTo, i.Value as IncomeValue FROM Parties p left join dbo.Income i on p.Id = i.PartyId")
            .ToList();

        data.Count().Should().BePositive();
    }

    class IncomeViewDto
    {
        public string Name { get; set; }
        
        public DateOnly? DateFrom { get; set; }
        
        public DateOnly? DateTo { get; set; }
        
        decimal? IncomeValue { get; set; }
    }
}