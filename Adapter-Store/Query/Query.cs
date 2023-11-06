using Adapter_Store.StoreObjects;

public enum QueryType
{
    SELECT,
    UPDATE,
    DELETE
}

public class Query<T>(QueryType queryType)
{
    public readonly QueryType queryType = queryType;
    public string GetCmd(){
        return "SELECT * FROM user;";
    }
}

