using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.EfCore8.Dal;

public class Party
{
    protected Party()
    {
    }

    public Party(string name, Address billingAddress, Address deliveryAddress)
    {
        Name = name;
        BillingAddress = billingAddress;
        DeliveryAddress = deliveryAddress;
    }
    
    public Guid Id { get; init; }  = Guid.NewGuid();
    
    public string Name { get; set; }

    public Address BillingAddress { get; set; }

    public Address DeliveryAddress { get; set; }

    public List<string> PartyType { get; init; } = new();

    public List<Income> Incomes { get; } = new List<Income>();

    public void DeclareIncome(Income income)
    {
        Incomes.Add(income);
    }
}

public record Income(DateOnly DateFrom, DateOnly DateTo, decimal Value);

public record Address(string Street, string ZipCode, string City);


public class PartyEntityConfiguration : IEntityTypeConfiguration<Party>
{
    public void Configure(EntityTypeBuilder<Party> builder)
    {
        builder.ComplexProperty(x => x.BillingAddress);
        builder.ComplexProperty(x => x.DeliveryAddress);

        builder.OwnsMany(x => x.Incomes);
    }
}