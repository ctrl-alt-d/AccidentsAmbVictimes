using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace importa;

public class CSVReader : IDisposable
{
    private StreamReader? _reader;
    private CsvReader? _csvReader;
    
    // Método auxiliar para verificar si un valor debe tratarse como null
    private static bool IsNullValue(string? text)
    {
        return string.IsNullOrWhiteSpace(text) || text == "NA" || text == "999999";
    }
    
    // Convertidor personalizado para tratar 999999 como null
    public class NullableIntConverter : DefaultTypeConverter
    {
        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (IsNullValue(text))
            {
                return null;
            }
            
            if (int.TryParse(text, out int result))
            {
                return result;
            }
            
            return null;
        }
    }
    
    // Convertidor personalizado para decimales que trata 999999 como null
    public class NullableDecimalConverter : DefaultTypeConverter
    {
        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (IsNullValue(text))
            {
                return null;
            }
            
            // Reemplazar coma por punto para el separador decimal
            text = text?.Replace(',', '.');
            
            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            
            return null;
        }
    }
    
    // Convertidor personalizado para TimeOnly desde formato h.m o hh.mm
    public class TimeOnlyConverter : DefaultTypeConverter
    {
        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return TimeOnly.MinValue;
            }
            
            // Dividir por el punto para separar horas y minutos
            var parts = text.Split('.');
            if (parts.Length != 2)
            {
                return TimeOnly.MinValue;
            }
            
            if (int.TryParse(parts[0], out int hours) && int.TryParse(parts[1], out int minutes))
            {
                // Validar rangos
                if (hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59)
                {
                    return new TimeOnly(hours, minutes);
                }
            }
            
            return TimeOnly.MinValue;
        }
    }

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
        
        // Registrar convertidores personalizados
        _csvReader.Context.TypeConverterCache.AddConverter<int?>(new NullableIntConverter());
        _csvReader.Context.TypeConverterCache.AddConverter<decimal?>(new NullableDecimalConverter());
        _csvReader.Context.TypeConverterCache.AddConverter<TimeOnly>(new TimeOnlyConverter());
        
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