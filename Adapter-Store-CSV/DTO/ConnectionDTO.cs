using Adapter_Repositories;
using Domain_Code;

namespace Adapter_Store_CSV.DTO;

public class ConnectionDTO : IDTO
{
    public string Id { get; set; }
    public string AirportFrom { get; set; }
    public string AirportTo { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public int FlightDuration { get; set; } // In minutes
    public double Distance { get; set; }
    public string DistanceUnit { get; set; }
}