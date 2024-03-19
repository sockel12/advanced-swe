using Adapter_Repositories;

namespace Adapter_Store_CSV.DTO;

public class CarrierDTO : IDTO
{
    public string CarrCode { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Website { get; set; }
}