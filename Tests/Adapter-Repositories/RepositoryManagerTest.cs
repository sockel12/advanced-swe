using Adapter_Respositories;

namespace Tests;

public class RepositoryManagerTest : RepositoryManager
{
    [SetUp]
    public void Setup()
    {
        _repositories = new Dictionary<Type, object>();
    }

    [Test]
    public void GetNonExistent()
    {
        // Assert.That(GetRepository<string>(), IsIns)
        Assert.That(GetRepository<string>(), Is.InstanceOf<Repository<string>>());
        Assert.That(_repositories.Count, Is.EqualTo(1));
    }
    [Test]
    public void GetExisting()
    {
        _repositories.Add(typeof(string), new Repository<string>());
        Assert.That(GetRepository<string>(), Is.InstanceOf<Repository<string>>());
        Assert.That(_repositories.Count, Is.EqualTo(1));
    }
}
