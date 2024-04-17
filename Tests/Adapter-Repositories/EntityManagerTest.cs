using Adapter_Repositories;
using Application_Code.Interfaces;
using Moq;

namespace Tests.Adapter_Repositories;


internal class EntityManagerTest
{
    private IEntityManager cut;

    [SetUp]
    public void Setup()
    {
        // ARRANGE
        cut = new EntityManager();
    }

    private Mock<IRepositoryFactory> GenerateFactory(bool doesContain = false)
    {
        var repositoryFactoryMock = new Mock<IRepositoryFactory>();
        
        repositoryFactoryMock
            .Setup(factory => factory.HasRecords<TestObject>())
            .Returns(doesContain);

        if (!doesContain) 
            return repositoryFactoryMock;
        
        var repositoryMock = new Mock<IRepository<TestObject>>();
        
        repositoryFactoryMock
            .Setup(factory => factory.GetRepository<TestObject>())
            .Returns(repositoryMock.Object);

        return repositoryFactoryMock;
    }


    [Test]
    public void Test1()
    {
        
        // Capture
        var repositoryFactoryMockContain = GenerateFactory(true);
        var repositoryFactoryMockNotContain = GenerateFactory();
        
        // ARRANGE
        cut.RegisterRepositoryFactory(repositoryFactoryMockContain.Object);
        cut.RegisterRepositoryFactory(repositoryFactoryMockNotContain.Object);

        // ACT
        IRepository<TestObject> resultRepository = cut.GetRepository<TestObject>();
        
        // ASSERT
        Assert.That(resultRepository.GetType(), Is.EqualTo(typeof(Repository<TestObject>)));
        Assert.That(resultRepository.Count, Is.EqualTo(1));
        
        // Verify
        Mock.VerifyAll(repositoryFactoryMockContain, repositoryFactoryMockNotContain);
    }
    
    [Test]
    public void Test2()
    {
        // Capture
        var repositoryFactoryMockContain = GenerateFactory(true);
        var repositoryFactoryMockContain2 = GenerateFactory(true);
        
        // ARRANGE
        cut.RegisterRepositoryFactory(repositoryFactoryMockContain.Object);
        cut.RegisterRepositoryFactory(repositoryFactoryMockContain2.Object);

        // ACT
        IRepository<TestObject> resultRepository = cut.GetRepository<TestObject>();
        
        // ASSERT
        Assert.That(resultRepository.GetType(), Is.EqualTo(typeof(Repository<TestObject>)));
        Assert.That(resultRepository.Count, Is.EqualTo(2));
        
        // Verify
        Mock.VerifyAll(repositoryFactoryMockContain, repositoryFactoryMockContain2);
    }
    
    [Test]
    public void Test3()
    {
        // Capture
        var repositoryFactoryMockNotContain = GenerateFactory();
        var repositoryFactoryMockNotContain2 = GenerateFactory();
        
        // ARRANGE
        cut.RegisterRepositoryFactory(repositoryFactoryMockNotContain.Object);
        cut.RegisterRepositoryFactory(repositoryFactoryMockNotContain2.Object);

        // ACT
        IRepository<TestObject> resultRepository = cut.GetRepository<TestObject>();
        
        // ASSERT
        Assert.That(resultRepository.GetType(), Is.EqualTo(typeof(Repository<TestObject>)));
        Assert.That(resultRepository.Count, Is.EqualTo(0));
        
        // Verify
        Mock.VerifyAll(repositoryFactoryMockNotContain, repositoryFactoryMockNotContain2);
    }
    
    
}
