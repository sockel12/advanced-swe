using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public abstract class BaseHandler<T>(IEntityManager entityManager)
    where T : Identifiable
{
    protected readonly IRepository<T> Repository = entityManager.GetRepository<T>();

    public virtual T? Get(string id) => Repository.Get(new Key(id));

    public virtual T[] GetAll() => Repository.GetAll().ToArray();

    public virtual bool Delete(string id) => Repository.Delete(new Key(id));
}