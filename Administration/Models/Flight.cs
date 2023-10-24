using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Administration.Models;

public record Flight
{
    public string FlightNumber { get; private set; }
    public FlightConnection FlightConnection { get; private set; }
    public DateOnly Date { get; private set; }
    
    
    public Flight(string flightNumber, FlightConnection flightConnection, DateOnly date)
    {
        FlightNumber = flightNumber;
        FlightConnection = flightConnection;
        Date = date;
    }
}