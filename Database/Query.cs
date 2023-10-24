using System.Collections.Immutable;
using System.Data.Odbc;

namespace Database;


// SELECT-QUERY | INSERT | UPDATE |
// FROM | INTO  SELECT("").FROM(Customer).Join()
// Q
// SELECT("").FROM(this.class)
public class Query()
{
    
    private readonly Dictionary<string, string> _fieldList = new(); // { alias : fieldExpression }
    private readonly Dictionary<string, string> _fromList = new();
    private readonly List<string> _whereList = new();
    
    public Query Select(string columnName, string sourceTable, string? alias)
    {
        _fieldList.Add(alias ?? sourceTable + "." + columnName, sourceTable + "." + columnName);
        return this;
    }

    public Query From(string tableName, string? alias)
    {
        _fromList.Add(alias ?? tableName, tableName);
        return this;
    }

    public Query Where(string expr)
    {
        _whereList.Add(expr);
        return this;
    }

    public OdbcCommand GetOdbcCommand()
    {
        return new OdbcCommand("SELECT * FROM TABLE");
    }
}