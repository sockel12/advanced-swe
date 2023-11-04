using System.Data;
using Adapter_Store.DbConnections;

public interface IDbConnector
{
    public IDbConnection GetConnection();
}