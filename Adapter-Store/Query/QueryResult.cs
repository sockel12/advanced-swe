public class QueryResult<T>
{
    public readonly List<string> records = new();
    public void AddRecord(string record){
        records.Add(record);
    }
}