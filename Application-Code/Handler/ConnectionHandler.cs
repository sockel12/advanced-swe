using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class ConnectionHandler(IEntityManager entityManager) : BaseHandler<Connection>(entityManager)
{
    public Connection CreateConnection(string id, string airportFrom, string airportTo, double flightDuration, double distance, DistanceUnit distanceUnit)
    {
        Connection connection = new Connection()
        {
            Id = new Key(id),
            AirportFrom = airportFrom,
            AirportTo = airportTo,
            FlightDuration = flightDuration,
            Distance = distance,
            DistanceUnit = distanceUnit
        };
        Repository.Add(connection);
        return connection;
    }

    public bool UpdateConnection(string id, string airportFrom, string airportTo, double flightDuration,
        double distance, DistanceUnit distanceUnit)
    {
        Connection? connection = Repository.Get(new Key(id));
        if (connection is null) return false;
        connection.AirportFrom = airportFrom;
        connection.AirportTo = airportTo;
        connection.FlightDuration = flightDuration;
        connection.Distance = distance;
        connection.DistanceUnit = distanceUnit;
        return Repository.Update(connection);
    }
}