using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class ReservationHandler(IEntityManager entityManager)
{
    private readonly IRepository<Reservation> _reservationRepository = entityManager.GetRepository<Reservation>();
    private readonly IRepository<Booking> _bookingRepository = entityManager.GetRepository<Booking>();

    public IList<Reservation> GetAllReservations()
    {
        return _reservationRepository.GetAll();
    }

    public Reservation? GetReservation(string id)
    {
        return _reservationRepository.Get(new Key(id));
    }

    public Reservation ReserveBooking(string bookingId)
    {
        Booking? booking = _bookingRepository.Get(new Key(bookingId));
        if (booking == null) throw new Exception("Bookings does not exist");
        Reservation reservation = new()
        {
            Id = new UUIDKey(),
            PaidPrice = 0,
            Customer = booking.Customer,
            Booking = bookingId,
            ReservationStatus = ReservationStatus.RESERVED,
            ReservationDate = DateTime.Today
        };
        _reservationRepository.Add(reservation);
        return reservation;
    }

    public Reservation PayReservation(Reservation reservation, double price)
    {
        if (!_reservationRepository.Contains(reservation)) throw new Exception("Invalid reservation");

        Booking? booking = _bookingRepository.Get(new Key(reservation.Booking));
        if (booking == null || Math.Abs(booking.Price - price) > .001)
            throw new Exception("Price has to confirm with the price due");
        
        reservation.PaidPrice = price;
        reservation.ReservationStatus = ReservationStatus.PAID;
        
        _reservationRepository.Update(reservation);
        
        return reservation;

    }

    public bool CancelReservation(Booking booking)
    {
        var reservation = _reservationRepository.GetAll().First(reservation1 => reservation1.Booking == booking.GetIdString());
        reservation.ReservationStatus = ReservationStatus.CANCELED;
        // If there is a paid reservation, the customer should be refunded
        // but this is not modeled here
        return true;
    }
}