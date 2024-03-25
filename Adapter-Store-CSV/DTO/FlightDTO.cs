using Adapter_Repositories;

namespace Adapter_Store_CSV.DTO;

public class FlightDTO : IDTO
{
    public string FlightNumber { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public string Connection { get; set; }
    public DateTime FlightDate { get; set; }
    public string PlaneType { get; set; }
}