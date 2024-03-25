namespace Domain_Code;

public abstract class Identifiable
{
    public abstract Key GetId();

    public string GetIdString()
    {
        return this.GetId().GetId();
    }
    
    public static bool operator ==(Identifiable? a, Identifiable? b)
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
    
    public static bool operator !=(Identifiable? a, Identifiable? b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        if (obj is not Identifiable identifiable)
        {
            return false;
        }
        return GetId().Equals(identifiable.GetId());
    }
    
    public override int GetHashCode()
    {
        return GetId().GetHashCode();
    }

    public override string ToString()
    {
        return GetId().ToString();
    }
}