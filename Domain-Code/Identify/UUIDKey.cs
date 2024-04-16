namespace Domain_Code;

public class UUIDKey : Key
{
    public UUIDKey() : base(Guid.NewGuid().ToString())
    {
    }
}