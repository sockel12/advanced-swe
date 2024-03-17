using Adapter_Repositories;
using AutoMapper;
using Domain_Code;

namespace Adapter_Store_CSV.DTO;

public class CustomerDTO : IDTO
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
}