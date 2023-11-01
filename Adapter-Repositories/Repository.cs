namespace Adapter_Respositories;

class Repository<T>
{
    List<T> _values = new ();

    
}

class RepositoryFactory{
    public Repository<IDomain> GetRepository(string className){
        return new Repository<IDomain>();
    }
}