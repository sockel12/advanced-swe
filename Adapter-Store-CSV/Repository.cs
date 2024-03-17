using System.Collections;
using System.Collections.Immutable;
using System.Globalization;
using Adapter_Repositories;
using Application_Code.Interfaces;
using AutoMapper;
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
        WriteCsv();
    }

    public void Clear()
    {
        Records.Clear();
        WriteCsv();
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
        WriteCsv();
        return isRemoved;
    }
    
    #endregion ICollection
    
    private static string BaseDir => @"/Users/I550939/Documents/Code/SWE/Adapter-Store-CSV/data";
    private string DataCsvFile { get; }
    private HashSet<T> Records { get; } = new();
    private readonly IConverter _converter;
    public Repository(IConverter converter)
    {
        _converter = converter;
        var className = typeof(T).Name;
        DataCsvFile = Path.Join(BaseDir, className + ".csv");

        if (!File.Exists(DataCsvFile))
        {
            File.Create(DataCsvFile);
        }
        
        LoadCsv();
    }

    private CsvConfiguration DefaultConfig { get; } = new(CultureInfo.InvariantCulture)
    {
        NewLine = Environment.NewLine,
        Delimiter = ";"
    };
    private void LoadCsv()
    {
        using var streamReader = new StreamReader(DataCsvFile);
        using var reader = new CsvReader(streamReader, DefaultConfig);
        Records.Clear();
        foreach (IDTO record in reader.GetRecords(_converter.GetIdtoType()))
        {
            Records.Add(
                (T)_converter.ToDomain(record)
            );
        }

        Count = Records.Count;
    }

    private void WriteCsv()
    {
        using var streamWriter = new StreamWriter(DataCsvFile);
        using var writer = new CsvWriter(streamWriter, DefaultConfig);
        foreach (var record in Records)
        {
            writer.WriteRecord(
                _converter.FromDomain(record)
            );
        }
    }

    public bool Update(T item)
    {
        var isSuccess = Records.Remove(item);
        isSuccess &= Records.Add(item);
        WriteCsv();
        return isSuccess;
    }

    public ImmutableList<T> GetAll()
    {
        return Records.ToImmutableList();
    }

    public T? Get(Key key)
    {
        return Records.First(identifiable => identifiable.GetId() == key);
    }
}