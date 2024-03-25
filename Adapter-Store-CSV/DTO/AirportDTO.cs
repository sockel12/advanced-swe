using Adapter_Repositories;
using Domain_Code;

namespace Adapter_Store_CSV.DTO;

public class AirportDTO : IDTO
{
    public string AirportCode { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Timezone { get; set; }

}