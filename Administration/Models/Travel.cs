using Database.DbObjects;

namespace Administration.Models;

public record Travel : IPersistable
{
    /*
     key TravelUUID : UUID;
  TravelID       : Integer @readonly default 0;
  BeginDate      : Date;
  EndDate        : Date;
  BookingFee     : Decimal(16, 3);
  TotalPrice     : Decimal(16, 3) @readonly;
  CurrencyCode   : Currency;
  Description    : String(1024);
  TravelStatus   : Association to TravelStatus @readonly;
  to_Agency      : Association to TravelAgency;
  to_Customer    : Association to Passenger;
  to_Booking     : Composition of many Booking on to_Booking.to_Travel = $self;
     */
    [PrimaryKey]
    public string Id { get; private set; }
    public DateOnly BeginDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public decimal BookingFee { get; private set; }
    public decimal TotalPrice { get; private set; }
    public Association<Currency> Currency { get; private set; }
    public string Description { get; private set; }
    public Association<TravelStatus> TravelStatus { get; private set; }
    public Association<TravelAgency> Agency { get; private set; }
    public Association<Passenger> Customer { get; private set; }
    public Association<Booking> Bookings { get; private set; }
}