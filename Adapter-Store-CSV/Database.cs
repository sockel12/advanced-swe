using System.Globalization;
using Adapter_Repositories;
using Application_Code.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Domain_Code;

namespace Adapter_Store.CSV_Store;

public class Database
{
    private readonly string _baseDir = "data";

    private readonly CsvConfiguration _defaultConfig = new(CultureInfo.InvariantCulture)
    {
        NewLine = Environment.NewLine,
        Delimiter = ";",
        HasHeaderRecord = true
    };
    
    public bool Persist<T>(IRepository<T> repository) where T : IIdentifiable
    {
        string path = Path.Join(_baseDir, typeof(T).Name);
        using var csv = GetCsvWriter(path);
        
        csv.WriteHeader<T>();
        
        return true;
    }

    public IRepository<T> Load<T>(T obj) where T : IIdentifiable
    {
        throw new NotImplementedException();
    }

    public int[] Upsert<T>(IRepository<T> repository) where T : IIdentifiable
    {
        throw new NotImplementedException();
    }

    private CsvReader GetCsvReader(string path)
    {
        using var reader = new StreamReader(path);
        return new CsvReader(reader, this._defaultConfig);
    }
    private CsvWriter GetCsvWriter(string path)
    {
        using var writer = new StreamWriter(path);
        return new CsvWriter(writer, this._defaultConfig);
    }
    
}