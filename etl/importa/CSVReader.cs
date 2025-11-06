using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace importa;

public class CSVReader : IDisposable
{
    private StreamReader? _reader;
    private CsvReader? _csvReader;

    public List<Accident> ReadCSV(string filePath)
    {
        _reader = new StreamReader(filePath);
        
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            HasHeaderRecord = true,
            MissingFieldFound = null,
            BadDataFound = null,
            PrepareHeaderForMatch = args => args.Header.ToLower(),
            HeaderValidated = null
        };

        _csvReader = new CsvReader(_reader, config);
        
        _csvReader.Context.TypeConverterOptionsCache.GetOptions<int?>().NullValues.Add("NA");
        _csvReader.Context.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = ["dd/MM/yyyy"];
        
        var records = _csvReader.GetRecords<Accident>().Select(a =>
        {
            // Convert DateTime.Kind to UTC for PostgreSQL compatibility
            a.Dat = DateTime.SpecifyKind(a.Dat, DateTimeKind.Utc);
            return a;
        }).ToList();
        
        return records;
    }

    public void Dispose()
    {
        _csvReader?.Dispose();
        _reader?.Dispose();
    }
}