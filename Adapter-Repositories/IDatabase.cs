using Application_Code.Interfaces;
using Domain_Code;

namespace Adapter_Repositories;

public interface IDatabase
{
    public bool Persist<T>(Repository<T> repository)
        where T : IIdentifiable;

    public Repository<T> Load<T>(T obj)
        where T : IIdentifiable;

    public int[] Upsert<T>(Repository<T> repository)
        where T : IIdentifiable;
}