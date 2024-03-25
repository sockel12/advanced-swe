using Adapter_Repositories;

namespace Adapter_Store_CSV.DTO;

public class BookingDTO : IDTO
{
    public string BookingNumber { get; set; }
    public string Customer { get; set; }
    public string Flight { get; set; }
    public string FlightClass { get; set; }
    public int LuggageCount { get; set; }
    public double PaidPrice { get; set; }
    public DateTime BookingDate { get; set; }
}