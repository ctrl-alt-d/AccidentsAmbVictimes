using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace importa;


public class Orquestrador
{
    protected CSVReader reader;
    protected VictimesDbCtx context;
    protected Cleaner cleaner;
    protected string rutaFitxer;
    protected ILogger<Orquestrador> logger;

    public Orquestrador(CSVReader reader, Cleaner cleaner, VictimesDbCtx context, string rutaFitxer, ILogger<Orquestrador> logger)
    {
        this.reader = reader;
        this.cleaner = cleaner;
        this.context = context;
        this.rutaFitxer = rutaFitxer;
        this.logger = logger;
    }

    public void Go()
    {
        var stopwatch = Stopwatch.StartNew();

        logger.LogInformation("No hi ha dades. Iniciant procés d'importació...");

        // Llegir el fitxer CSV
        logger.LogInformation("Llegint fitxer CSV: {RutaFitxer}", rutaFitxer);
        var accidents = reader.ReadCSV(rutaFitxer);
        logger.LogInformation("S'han llegit {NumAccidents} accidents del fitxer CSV", accidents.Count());

        // Netejar les dades
        logger.LogInformation("Netejant les dades...");
        cleaner.CleanDataset(accidents);
        logger.LogInformation("Les dades s'han netejat correctament.");

        // Crear la base de dades i la taula
        logger.LogInformation("Recreant la base de dades i la taula ...");
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        logger.LogInformation("Inserint les dades a la base de dades...");
        // Inserir les dades a la base de dades
        var numAccidents = accidents.Count();
        context.AddRange(accidents);
        context.SaveChanges();
        
        stopwatch.Stop();
        logger.LogInformation("S'han inserit {NumAccidents} registres correctament a la base de dades en {TempsTrigat:F2} segons", 
            numAccidents, stopwatch.Elapsed.TotalSeconds);
    }
}