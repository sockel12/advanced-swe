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

    private Reservation GenerateReservation(string id, int price = 0, string bookingId = "booking-id")
    {
        return new Reservation()
        {
            Id = new Key(id),
            Booking = bookingId,
            Customer = "customer-id",
            PaidPrice = price,
            ReservationStatus = ReservationStatus.RESERVED,
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
        
        var unpaidReservation = GenerateReservation("reservation-id", bookingId : bookingId);
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
        Assert.Throws<Exception>(() => cut.PayReservation(unpaidReservation, wrongPrice));
        // Verify
        Mock.Verify(reservationRepoMock, bookingRepoMock, entityManagerMock);
    }
}