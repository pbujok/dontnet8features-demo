using Demo.EfCore8.Dal;
using Microsoft.EntityFrameworkCore;

namespace Demo.EfCore8;

public class ComplexTypesExample
{
    [Fact]
    public void Migrate()
    {
        using var context = new TestContext();
        context.Database.Migrate();
        context.RemoveRange(context.Parties.ToArray());
        context.SaveChanges();
    }

    [Fact]
    public void ComplexTypesSaveExample()
    {
        using var context = new TestContext();
        var address = new Address("Private drive 4", "N1C 4AX", "Little Whinging");
        var party = new Party("Harry Potter", address, address);

        context.Parties.Add(party);
        context.SaveChanges();
    }

    [Fact]
    public void PrimitiveCollection()
    {
        using var context = new TestContext();

        var address = new Address("Private drive 4", "N1C 4AX", "Little Whinging");
        var party = new Party("Harry Potter", address, address)
        {
            PartyType = ["Student", "Chosen one"]
        };

        context.Parties.Add(party);
        context.SaveChanges();
    }

    [Fact]
    public void SetupIncome()
    {
        using var context = new TestContext();

        var address = new Address("Private drive 4", "N1C 4AX", "Little Whinging");
        var party = new Party("Harry Potter", address, address);

        party.DeclareIncome(new Income(new DateOnly(2021, 1, 1), new DateOnly(2021, 12, 31), 1410));
        party.DeclareIncome(new Income(new DateOnly(2022, 1, 1), new DateOnly(2022, 12, 31), 2137));

        context.Parties.Add(party);
        context.SaveChanges();
    }
    

}