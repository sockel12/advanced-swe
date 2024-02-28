using Adapter_Store;
using Adapter_Store.DbConnections;
using Domain_Code;
using Moq;
using NHibernate;

namespace Tests.Adapter_Store;

public class Integration
{
    private DbController cut;
    private Flight testFlight = new Flight() { FlightNumber = "1", Connection = new Connection() };
    private List<Flight> returnFlights;
    [SetUp]
    public void Setup()
    {
        returnFlights = new List<Flight>() { testFlight };
        
        var criteriaMock = new Mock<ICriteria>();
        criteriaMock.Setup(x => x.List<Flight>()).Returns(new List<Flight>() { testFlight });
        
        var sessionMock = new Mock<ISession>();
        sessionMock.Setup(x => x.CreateCriteria(typeof(Flight))).Returns(criteriaMock.Object);
        sessionMock.Setup(x => x.Dispose());
        
        var factoryMock = new Mock<ISessionFactory>();
        factoryMock.Setup(x => x.OpenSession()).Returns(sessionMock.Object);
        
        cut = new DbController(
            new OdbcConnector("DSN=mysql"),
            factoryMock.Object
        );
    }

    [Test]
    public void Test1()
    {
        IList<Flight> flights = cut.QueryAll<Flight>();
        Assert.That(flights.Count, Is.EqualTo(1));
        Assert.That(flights, Is.EquivalentTo(returnFlights));
    }

    [Test]
    public void MockTest(){
        
    }
}