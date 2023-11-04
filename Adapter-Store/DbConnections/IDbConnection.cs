public interface IDbConnection : IDisposable
{
    public QueryResult<T> Query<T>(Query<T> query);
}