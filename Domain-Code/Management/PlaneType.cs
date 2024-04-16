namespace Domain_Code.Management;

public class PlaneType : Identifiable
{
    public Key Id { get; set; }
    public uint Capacity { get; set; }
    public uint MaxRange { get; set; }
    
    public override Key GetId()
    {
        return Id;
    }
}