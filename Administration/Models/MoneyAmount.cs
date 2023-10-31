using Database.DbObjects;

namespace Administration.Models;

public record MoneyAmount : IPersistable
{
    public decimal Amount { get; private set; }
    public Association<Currency> Currency { get; private set; }
    
    public MoneyAmount(decimal amount, Association<Currency> currency)
    {
        Amount = amount;
        Currency = currency;
    }
}