using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class ReservationHandler(IEntityManager entityManager)
{
    private readonly IRepository<Booking> _bookingRepository = new DomainVisitor<Booking>().GetRepository(entityManager);
    private readonly IRepository<Reservation> _reservationRepository = new DomainVisitor<Reservation>().GetRepository(entityManager);
    private readonly IRepository<Customer> _customerRepository = new DomainVisitor<Customer>().GetRepository(entityManager);
    
    public Reservation ReserveBooking(Booking booking)
    {
        Reservation reservation = (Reservation)booking;
        reservation.ReservationStatus = ReservationStatus.RESERVED;
        _reservationRepository.Add(reservation);
        return reservation;
    }

    public Reservation PayReservation(Reservation reservation, double price)
    {
        reservation.PaidPrice = price;
        reservation.ReservationStatus = ReservationStatus.PAID;
        _reservationRepository.Update(reservation);
        return reservation;
    }

    public bool CancelReservation(string bookingNumber)
    {
        Reservation reservation = _reservationRepository.Get(bookingNumber);
        if (reservation == null) return false;
        reservation.ReservationStatus = ReservationStatus.CANCELED;
        return true;
    }
}