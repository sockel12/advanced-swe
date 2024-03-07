using System.Collections;
using System.Globalization;
using Application_Code.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Domain_Code;

namespace Adapter_Store_CSV;

public class Repository<T> : IRepository<T>
    where T : IIdentifiable
{
    public int Count { get; private set; }
    public bool IsReadOnly => false;
    private static string BaseDir => "data";
    private string DataCsvFile { get; }
    private HashSet<T> Records { get; } = new();

    private CsvConfiguration DefaultConfig { get; } = new(CultureInfo.InvariantCulture)
    {
        NewLine = Environment.NewLine,
        Delimiter = ";"
    };

    public Repository()
    {
        var className = typeof(T).Name;
        DataCsvFile = Path.Join(BaseDir, className + ".csv");
        var csvReader = GetCsvReader(DataCsvFile);
        foreach (var record in csvReader.GetRecords<T>())
        {
            Records.Add(record);
        }

        Count = Records.Count;
    }
    
    public void Accept(IRepositoryVisitor<T> visitor)
    {
        visitor.Visit(this);
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return Records.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private CsvReader GetCsvReader(string path)
    {
        using var streamReader = new StreamReader(path);
        return new CsvReader(streamReader, DefaultConfig);
    }

    private CsvWriter GetCsvWriter(string path)
    {
        using var streamWriter = new StreamWriter(path);
        return new CsvWriter(streamWriter, DefaultConfig);
    }
}