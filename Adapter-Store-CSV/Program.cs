using Domain_Code;

namespace Adapter_Store_CSV;

public class Program
{
    public static void Main()
    {
        CsvRepositoryFactory factory = new();
        var repo = factory.GetRepository<Customer>();
        Customer c = new Customer()
        {
            Id = new Key("1"),
            FirstName = "Niklas",
            LastName = "Haas",
            PassportNumber = "000000000"
        };
        repo.Add(c);
    }
}