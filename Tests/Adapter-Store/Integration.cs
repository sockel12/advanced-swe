using Adapter_Store;
using Adapter_Store.DbConnections;
using Moq;
using NHibernate;

namespace Tests;

public class Integration : DbController
{
    public Integration() : base(new OdbcConnector("DSN=mysql")) {}
    [SetUp]
    public void Setup()
    {
        var factoryMock = new Mock<ISessionFactory>();
        factoryMock.Setup(x => x.OpenSession()).Returns(new Mock<ISession>().Object);
    }

    [Test]
    public void Test1()
    {
        QueryAll();
        Assert.Pass("Is Queryable");
    }

    [Test]
    public void MockTest(){
        
    }
}