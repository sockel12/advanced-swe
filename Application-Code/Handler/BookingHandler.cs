using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class BookingHandler(IEntityManager entityManager)
{
    private readonly IRepository<Booking> _bookingRepository = entityManager.GetRepository<Booking>();

    public Booking? Get(string id)
    {
        return _bookingRepository.Get(new Key(id));
    }

    public IList<Booking> GetAll()
    {
        return _bookingRepository.GetAll();
    }

    public Booking CreateBooking(
        string customerId,
        string flightNumber,
        FlightClass flightClass,
        int luggageCount,
        int price,
        DateTime bookingDate)
    {
        Booking booking = new Booking()
        {
            BookingNumber = new UUIDKey(),
            Customer = customerId,
            FlightClass = flightClass,
            Flight = flightNumber,
            Price = price,
            BookingDate = bookingDate,
            LuggageCount = luggageCount,
        };
        _bookingRepository.Add(booking);
        return booking;
    }
}