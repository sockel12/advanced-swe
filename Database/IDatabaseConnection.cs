namespace Database;

public interface IDatabaseConnection
{
    public int Query(Query query);
}