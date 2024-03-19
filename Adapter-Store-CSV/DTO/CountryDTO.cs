using Adapter_Repositories;

namespace Adapter_Store_CSV.DTO;

public class CountryDTO : IDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

}