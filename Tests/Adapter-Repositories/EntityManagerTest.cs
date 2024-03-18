using Adapter_Repositories;
using Application_Code.Interfaces;
using Domain_Code;
using System.Collections;

namespace Tests.Adapter_Repositories;


internal class EntityManagerTest
{
    private IEntityManager cut;
    private IRepositoryFactory repositoryFactoryContainingRepository;
    private IRepositoryFactory repositoryFactoryNotContainingRepository;

    [SetUp]
    public void Setup()
    {
        cut = new EntityManager();
        repositoryFactoryContainingRepository = new RepositoryFactoryMock(true);
        repositoryFactoryNotContainingRepository = new RepositoryFactoryMock();
    }


    [Test]
    public void Test()
    {
        cut.RegisterRepositoryFactory(repositoryFactoryContainingRepository);
        cut.RegisterRepositoryFactory(repositoryFactoryNotContainingRepository);

        IRepository<TestObject> resultRepository = cut.GetRepository<TestObject>();
        Assert.That(resultRepository.GetType(), Is.EqualTo(typeof(Repository<TestObject>)));
    }
}
