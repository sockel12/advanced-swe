namespace Adapter_Respositories;

public class RepositoryManager
{
    protected Dictionary<Type, object> _repositories = new();

    public Repository<T> GetRepository<T>(){
        Type type = typeof(T);
        if(!_repositories.ContainsKey(type)){
            _repositories.Add(
                type,
                new Repository<T>()
            );
        }
        return _repositories[type] as Repository<T>;
    }
}