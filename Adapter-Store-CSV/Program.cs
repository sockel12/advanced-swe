using Application_Code.Interfaces;
using Domain_Code;

namespace Adapter_Store_CSV;

public class Program
{
    public static void Main()
    {
        IRepository<Customer> repository = new Repository<Customer>();
        Customer customer = new()
        {
            Id = new Key("1"),
            FirstName = "Banjamin",
            LastName = "Appel",
            PassportNumber = "1234-5678-9101"
        };
        repository.Add(customer);
    }
}