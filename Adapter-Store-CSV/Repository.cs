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
    #region ICollectable
    public int Count { get; private set; }
    public bool IsReadOnly => false;
    public IEnumerator<T> GetEnumerator()
    {
        return Records.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    #endregion ICollectable
    
    #region ICollection
    
    public void Add(T item)
    {
        Records.Add(item);
        GetCsvWriter(DataCsvFile).WriteRecords(Records);
    }

    public void Clear()
    {
        Records.Clear();
        GetCsvWriter(DataCsvFile).Flush();
    }

    public bool Contains(T item)
    {
        return Records.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        Records.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        var isRemoved = Records.Remove(item);
        GetCsvWriter(DataCsvFile).WriteRecords(Records);
        return isRemoved;
    }
    
    #endregion ICollection
    
    private static string BaseDir => "data";
    private string DataCsvFile { get; }
    private HashSet<T> Records { get; } = new();
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

    private CsvConfiguration DefaultConfig { get; } = new(CultureInfo.InvariantCulture)
    {
        NewLine = Environment.NewLine,
        Delimiter = ";"
    };
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

    public bool Update(T item)
    {
        var isSuccess = Records.Remove(item);
        isSuccess &= Records.Add(item);
        GetCsvWriter(DataCsvFile).WriteRecords(Records);
        return isSuccess;
    }

    public T? Get(Key key)
    {
        return Records.First(identifiable => identifiable.GetId() == key);
    }
}