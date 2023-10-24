namespace Database.DbObjects;

public class Entity<T>
    (string id)
    where T : IPersistable
{
    public readonly string Id = id;
    public bool IsRead { get; private set; } = false;
    public T Instance { get; private set; }
}