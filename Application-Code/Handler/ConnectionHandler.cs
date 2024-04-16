using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class ConnectionHandler(IEntityManager entityManager)
{
    private readonly IRepository<Connection> _connectionRepository = entityManager.GetRepository<Connection>();
    
    public bool CreateConnection(Connection connection)
    {
        _connectionRepository.Add(connection);
        return true;
    }
}