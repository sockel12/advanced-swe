using Adapter_Repositories;

namespace Adapter_Store_CSV.DTO;

public class ReservationDTO : IDTO
{
    public String Id { get; set; }
    public string Booking { get; set; }
    public string Customer { get; set; }
    public DateTime ReservationDate { get; set; }
    public double PaidPrice { get; set; }
    public string ReservationStatus { get; set; }
}