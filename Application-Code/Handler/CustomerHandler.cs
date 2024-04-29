using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class CustomerHandler(IEntityManager entityManager) : BaseHandler<Customer>(entityManager)
{
    public Customer CreateCustomer(string firstname, string lastname, string passportNumber)
    {
        Customer c = new Customer()
        {
            Id = new UUIDKey(),
            FirstName = firstname,
            LastName = lastname,
            PassportNumber = passportNumber
        };
        Repository.Add(c);
        return c;
    }

    public bool UpdateCustomer(string id, string firstname, string lastname, string passportNumber)
    {
        Customer? c = Repository.Get(new Key(id));
        if (c is null) return false;
        c.FirstName = firstname;
        c.LastName = lastname;
        c.PassportNumber = passportNumber;
        return Repository.Update(c);
    }
}