using Database.DbObjects;

namespace Administration.Models;

public record Currency : IPersistable
{
    [PrimaryKey]
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Symbol { get; private set; }
    
    public Currency(string code, string name, string symbol)
    {
        Code = code;
        Name = name;
        Symbol = symbol;
    }
}