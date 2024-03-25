using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class ReservationHandler(IEntityManager entityManager)
{
    private readonly IRepository<Booking> _bookingRepository = entityManager.GetRepository<Booking>();
    private readonly IRepository<Reservation> _reservationRepository = entityManager.GetRepository<Reservation>();
    private readonly IRepository<Customer> _customerRepository = entityManager.GetRepository<Customer>();
    
    public Reservation ReserveBooking(Booking booking)
    {
        Reservation reservation = new Reservation();
        reservation.Booking = booking.GetIdString();
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

    public bool CancelReservation(Booking booking)
    {
        Reservation? reservation = _reservationRepository.Get(booking.GetId());
        if (reservation == null) return false;
        reservation.ReservationStatus = ReservationStatus.CANCELED;
        // If there is a paid reservation, the customer should be refunded
        // but this is not modeled here
        return true;
    }
}