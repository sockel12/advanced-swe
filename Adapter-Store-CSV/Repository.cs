using System.Collections;
using System.Collections.Immutable;
using System.Globalization;
using System.Reflection;
using System.Text;
using Application_Code.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Domain_Code;

namespace Adapter_Store_CSV;

public class Repository<T> : IRepository<T>
    where T : Identifiable
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

    public void Add(params T[] items)
    {
        foreach (var item in items)
        {
            Records.Add(item);
        }
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
    private static string BaseDir => Path.Join(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", "..", "Adapter-Store-CSV", "data") ?? "";
    private string DataCsvFile { get; }
    private HashSet<T> Records { get; } = new();
    public Repository()
    {
        var className = typeof(T).Name;

        if (BaseDir == "")
        {
            throw new DirectoryNotFoundException("The directory could not be found or is not accessible");
        }
        
        DataCsvFile = Path.Join(BaseDir, className + ".csv");
        
        if (!File.Exists(DataCsvFile))
        {
            // Not only is the file not found, but the directory could also be missing or is not accessible
            if(!Directory.Exists(BaseDir))
                Directory.CreateDirectory(BaseDir);
            File.Create(DataCsvFile).Close();
        }
        
        LoadCsv();
    }

    private CsvConfiguration DefaultConfig { get; } = new(CultureInfo.InvariantCulture)
    {
        NewLine = Environment.NewLine,
        Delimiter = ";",
        Encoding = Encoding.UTF8,
        PrepareHeaderForMatch = args => args.Header.ToLower()
    };
    private void LoadCsv()
    {
        try
        {
            using var streamReader = new StreamReader(DataCsvFile);
            using var reader = new CsvReader(streamReader, DefaultConfig);

            reader.Read();
            reader.ReadHeader();
            
            Records.Clear();
            foreach (T record in reader.GetRecords<T>())
            {
                Records.Add(record);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to load csv file: '" + DataCsvFile + "':\n" + e.Message);
        }
        finally
        {
            Count = Records.Count;
        }
    }

    private void WriteCsv()
    {
        using var streamWriter = new StreamWriter(DataCsvFile);
        using var writer = new CsvWriter(streamWriter, DefaultConfig);
        // Create the header for the csv file and make an empty record so that the 
        // next record is in the 2nd line
        writer.WriteHeader<T>();
        writer.NextRecord();
        
        foreach (var record in Records)
        {
            try
            {
                writer.WriteRecord(record);
                writer.NextRecord();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }

    public bool Update(T item)
    {
        var isSuccess = Records.Remove(item);
        isSuccess &= Records.Add(item);
        WriteCsv();
        return isSuccess;
    }

    public bool Delete(Key key)
    {
        var item = Records.First(identifiable => identifiable.GetId() == key);
        var isSuccess = Records.Remove(item);
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