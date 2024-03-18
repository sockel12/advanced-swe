using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Interfaces;

public interface IRepositoryFactory
{
    public bool HasRecords<T>() where T : Identifiable;
    public IRepository<T> GetRepository<T>() where T : Identifiable;
    public IRepository<T> CreateRepository<T>() where T : Identifiable;
}