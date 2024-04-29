using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class BookingHandler(IEntityManager entityManager) : BaseHandler<Booking>(entityManager)
{

    public Booking CreateBooking(
        string customerId,
        string flightNumber,
        string flightClass,
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
        Repository.Add(booking);
        return booking;
    }
}