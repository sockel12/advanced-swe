using System.Collections;
using System.Collections.Immutable;
using Application_Code.Handler;
using Application_Code.Interfaces;
using Domain_Code;
using Moq;

namespace Tests.Application_Code;

public class ReservationHandlerTest
{
    private Mock<IEntityManager> entityManagerMock;
    private Mock<IRepository<Reservation>> reservationRepoMock;
    private Mock<IRepository<Booking>> bookingRepoMock;
    private ReservationHandler cut;

    [SetUp]
    public void Setup()
    {
        // Global Capture
        reservationRepoMock = new Mock<IRepository<Reservation>>();
        bookingRepoMock = new Mock<IRepository<Booking>>();
        
        entityManagerMock = new Mock<IEntityManager>();
        entityManagerMock
            .Setup(manager => manager.GetRepository<Reservation>())
            .Returns(reservationRepoMock.Object);
        
        entityManagerMock
            .Setup(manager => manager.GetRepository<Booking>())
            .Returns(bookingRepoMock.Object);
        
        
        
        // Global Arrange
        cut = new ReservationHandler(entityManagerMock.Object);
    }

    private Booking GenerateBooking(string id, int price = 0)
    {
        return new Booking()
        {
            BookingNumber = new Key(id),
            Customer = "customer-id",
            Flight = "flight-id",
            Price = price,
        };
    }

    private Reservation GenerateReservation(string id, int price = 0, string bookingId = "booking-id", ReservationStatus status = ReservationStatus.RESERVED)
    {
        return new Reservation()
        {
            Id = new Key(id),
            Booking = bookingId,
            Customer = "customer-id",
            PaidPrice = price,
            ReservationStatus = status
        };
    }

    [Test]
    public void Test01_PayReservation()
    {
        var price = 100;
        var bookingId = "booking-id";
        var reservationId = "reservation-id";
        
        var unpaidReservation = GenerateReservation(reservationId, bookingId : bookingId);
        var paidReservation = GenerateReservation(reservationId, price : price, bookingId : bookingId);
        var booking = GenerateBooking(bookingId, price);
        
        // Capture
        bookingRepoMock
            .Setup(repository => repository.Get(new Key(bookingId)))
            .Returns(booking)
            .Verifiable();
        
        reservationRepoMock
            .Setup(repository => repository.Contains(unpaidReservation))
            .Returns(true)
            .Verifiable();

        reservationRepoMock
            .Setup(repository => repository.Update(paidReservation))
            .Returns(true)
            .Verifiable();

        // Act
        Reservation reservation = cut.PayReservation(unpaidReservation, price);
        
        // Assert
        Assert.That(reservation, Is.EqualTo(paidReservation));
        
        // Verify
        Mock.Verify(reservationRepoMock, bookingRepoMock, entityManagerMock);
    }
    
    [Test]
    public void Test02_PayReservation_2()
    {
        var actPrice = 100;
        var wrongPrice = 40;
        var bookingId = "booking-id";
        
        var unpaidReservation = GenerateReservation("reservation-id", bookingId: bookingId);
        var booking = GenerateBooking(bookingId, actPrice);
        
        
        // Capture
        bookingRepoMock
            .Setup(repository => repository.Get(new Key(bookingId)))
            .Returns(booking)
            .Verifiable();
        
        reservationRepoMock
            .Setup(repository => repository.Contains(unpaidReservation))
            .Returns(true)
            .Verifiable();
        
        // Act and Assert
        Assert.Throws<InvalidInputException>(() => cut.PayReservation(unpaidReservation, wrongPrice));
        
        // Verify
        Mock.Verify(reservationRepoMock, bookingRepoMock, entityManagerMock);
    }

    [Test]
    public void Test03_ReserveBooking()
    {
        var bookingId = "booking-id";
        var booking = GenerateBooking(bookingId);
        var unpaidReservation = GenerateReservation("reservation-id", bookingId: bookingId);

        // Capture
        bookingRepoMock
            .Setup(repository => repository.Get(new Key(bookingId)))
            .Returns(booking)
            .Verifiable();

        reservationRepoMock
            .Setup(repository => repository.Update(unpaidReservation));

        reservationRepoMock
            .Setup(repository => repository.GetAll())
            .Returns(ImmutableList<Reservation>.Empty)
            .Verifiable();
        
        // Act
        Reservation reservation = cut.ReserveBooking(bookingId);
        
        // Assert
        Assert.That(reservation.PaidPrice, Is.EqualTo(0));
        Assert.That(reservation.Booking, Is.EqualTo(bookingId));
        Assert.That(reservation.ReservationStatus, Is.EqualTo(ReservationStatus.RESERVED));
        
        // Verify
        Mock.Verify(bookingRepoMock, reservationRepoMock);
    }
    
    [Test]
    public void Test04_ReserveBooking_2()
    {
        var bookingId = "booking-id";

        // Capture
        bookingRepoMock
            .Setup(repository => repository.Get(new Key(bookingId)))
            .Returns((Booking?)null)
            .Verifiable();

        // Act & Assert
        Assert.Throws<InvalidInputException>(() => cut.ReserveBooking(bookingId));
        
        // Verify
        Mock.Verify(bookingRepoMock, reservationRepoMock);
    }
    
    [Test]
    public void Test05_ReserveBooking_3()
    {
        var bookingId = "booking-id";
        var booking = GenerateBooking(bookingId);
        var existingReservation = GenerateReservation("reservation-id", bookingId: bookingId);

        // Capture
        bookingRepoMock
            .Setup(repository => repository.Get(new Key(bookingId)))
            .Returns(booking)
            .Verifiable();
        
        reservationRepoMock
            .Setup(repository => repository.GetAll())
            .Returns(new []{existingReservation}.ToImmutableList())
            .Verifiable();

        // Act & Assert
        Assert.Throws<ElementExistsException>(() => cut.ReserveBooking(bookingId));
        
        // Verify
        Mock.Verify(bookingRepoMock, reservationRepoMock);
    }
    
    [Test]
    public void Test06_CancelBooking()
    {
        var bookingId = "booking-id";
        var reservationId = "reservation-id";
        var existingReservation = GenerateReservation(reservationId, bookingId: bookingId);
        var canceledReservation = GenerateReservation(reservationId, bookingId: bookingId, status: ReservationStatus.CANCELED);

        // Capture
        reservationRepoMock
            .Setup(repository => repository.GetAll())
            .Returns(new [] {existingReservation}.ToImmutableList())
            .Verifiable();
        
        reservationRepoMock
            .Setup(repository => repository.Update(canceledReservation))
            .Verifiable();

        // Act
        cut.CancelReservation(bookingId);
        
        // Assert & Verify
        Mock.Verify(bookingRepoMock, reservationRepoMock);
    }
    
    [Test]
    public void Test07_CancelBooking_2()
    {
        var reservationId = "booking-id";
        
        // Capture
        reservationRepoMock
            .Setup(repository => repository.GetAll())
            .Returns(ImmutableList<Reservation>.Empty)
            .Verifiable();

        // Act & Assert
        Assert.Throws<InvalidInputException>(() => cut.CancelReservation(reservationId));
        
        // Verify
        Mock.Verify(bookingRepoMock, reservationRepoMock);
    }
}