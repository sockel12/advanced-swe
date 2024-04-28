using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class ConnectionHandler(IEntityManager entityManager)
{
    private readonly IRepository<Connection> _connectionRepository = entityManager.GetRepository<Connection>();
    
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
        _connectionRepository.Add(connection);
        return connection;
    }
    
    public bool DeleteConnection(string id)
    {
        return _connectionRepository.Delete(new Key(id));
    }

    public bool UpdateConnection(string id, string airportFrom, string airportTo, double flightDuration,
        double distance, DistanceUnit distanceUnit)
    {
        Connection? connection = _connectionRepository.Get(new Key(id));
        if (connection is null) return false;
        connection.AirportFrom = airportFrom;
        connection.AirportTo = airportTo;
        connection.FlightDuration = flightDuration;
        connection.Distance = distance;
        connection.DistanceUnit = distanceUnit;
        return _connectionRepository.Update(connection);
    }
    
    public Connection GetConnection(string id)
    {
        return _connectionRepository.Get(new Key(id))!;
    }
    
    public Connection[] GetAllConnections()
    {
        return _connectionRepository.GetAll().ToArray();
    }
}