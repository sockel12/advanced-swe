namespace Database.DbObjects;

public class Association<T>
    (string[] idStrings)
    where T : IPersistable
{
    private T[] _instances = new T [idStrings.Length];
    public readonly string[] Id = idStrings;
    public bool IsRead { get; private set; } = false;
}