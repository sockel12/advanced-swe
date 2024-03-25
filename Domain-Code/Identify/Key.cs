namespace Domain_Code;

public class Key
{
    
    public string Id { get; private set; }
    
    
    public Key(string id)
    {
        Id = id;
    }
    
    public string GetId()
    {
        return Id;
    }
    
    public static bool operator ==(Key? a, Key? b)
    {
        if (a is null && b is null)
        {
            return true;
        }
        if (a is null || b is null)
        {
            return false;
        }
        return a.GetId().Equals(b.GetId());
    }
    
    public static bool operator !=(Key? a, Key? b)
    {
        return !(a == b);
    }
    
    public override string ToString()
    {
        return GetId();
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        if (obj is not Key key)
        {
            return false;
        }
        return GetId().Equals(key.GetId());
    }
    
    public override int GetHashCode()
    {
        return GetId().GetHashCode();
    }
}