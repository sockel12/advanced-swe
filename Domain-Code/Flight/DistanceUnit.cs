namespace Domain_Code;

public class DistanceUnit : Identifiable
{
    public Key Unit { get; set; }
    public string Name { get; set; }
    public override Key GetId()
    {
        return Unit;
    }
}