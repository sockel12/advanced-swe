using System.Globalization;
using Application_Code.Interfaces;
using Domain_Code;
using Domain_Code.Management;

namespace Application_Code.Handler;

public class ReservationHandler(IEntityManager entityManager)
{
    private readonly IRepository<Reservation> _reservationRepository = entityManager.GetRepository<Reservation>();
    private readonly IRepository<Booking> _bookingRepository = entityManager.GetRepository<Booking>();

    public Reservation[] GetAllReservations()
    {
        return _reservationRepository.GetAll().ToArray();
    }

    public Reservation? GetReservation(string id)
    {
        return _reservationRepository.Get(new Key(id));
    }
    
    public Reservation ReserveBooking(string bookingId)
    {
        Booking? booking = _bookingRepository.Get(new Key(bookingId));
        
        if (booking == null) 
            throw new InvalidInputException(bookingId);

        if (_reservationRepository.GetAll().Any(reservation1 => reservation1.Booking == bookingId))
            throw new ElementExistsException(bookingId);
        
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
        if (!_reservationRepository.Contains(reservation)) throw new InvalidInputException(reservation.GetIdString());

        Booking? booking = _bookingRepository.Get(new Key(reservation.Booking));
        if (booking == null || Math.Abs(booking.Price - price) > .001)
            throw new InvalidInputException(price.ToString(CultureInfo.InvariantCulture));
        
        reservation.PaidPrice = price;
        reservation.ReservationStatus = ReservationStatus.PAID;
        
        _reservationRepository.Update(reservation);
        
        return reservation;

    }

    public bool CancelReservation(string bookingId)
    {
        try
        {
            var reservation = _reservationRepository.GetAll()
                .First(reservation1 => reservation1.Booking == bookingId);
            
            // If there is a paid reservation, the customer should be refunded
            // but this is not modeled here
            
            reservation.ReservationStatus = ReservationStatus.CANCELED;
            return _reservationRepository.Update(reservation);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidInputException(bookingId);
        }
    }
}