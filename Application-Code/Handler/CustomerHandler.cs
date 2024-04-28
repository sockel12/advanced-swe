using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class CustomerHandler(IEntityManager entityManager)
{
    private readonly IRepository<Customer> _customerRepository = entityManager.GetRepository<Customer>();

    public Customer CreateCustomer(string firstname, string lastname, string passportNumber)
    {
        Customer c = new Customer()
        {
            Id = new UUIDKey(),
            FirstName = firstname,
            LastName = lastname,
            PassportNumber = passportNumber
        };
        _customerRepository.Add(c);
        return c;
    }
    
    public bool DeleteCustomer(string id)
    {
        return _customerRepository.Delete(new Key(id));
    }

    public bool UpdateCustomer(string id, string firstname, string lastname, string passportNumber)
    {
        Customer? c = _customerRepository.Get(new Key(id));
        if (c is null) return false;
        c.FirstName = firstname;
        c.LastName = lastname;
        c.PassportNumber = passportNumber;
        return _customerRepository.Update(c);
    }
    
    public Customer GetCustomer(string id)
    {
        return _customerRepository.Get(new Key(id))!;
    }
    
    public Customer[] GetAllCustomers()
    {
        return _customerRepository.GetAll().ToArray();
    }
}