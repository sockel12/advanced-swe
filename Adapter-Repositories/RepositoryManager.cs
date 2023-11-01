namespace Adapter_Respositories;

class RepositoryManager
{
    protected Dictionary<string, Repository<IDomain>> _repositories = new();
    protected RepositoryFactory _repoFactory = new();

    public Repository<IDomain>  GetRepository(string className){
        if(!_repositories.ContainsKey(className)){
            _repositories.Add(
                className,
                _repoFactory.GetRepository(className)
            );
        }
        return _repositories[className];
    }
}

internal interface IDomain{

}