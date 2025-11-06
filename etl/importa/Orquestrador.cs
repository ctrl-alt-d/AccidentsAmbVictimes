namespace importa;


public class Orquestrador
{
    protected CSVReader reader;
    protected VictimesDbCtx context;
    protected string rutaFitxer;
    public Orquestrador(CSVReader reader, VictimesDbCtx context, string rutaFitxer)
    {
        this.reader = reader;
        this.context = context;
        this.rutaFitxer = rutaFitxer;
    }
    public void Go(
        )
    {
        // Llegir el fitxer CSV
        var accidents = reader.ReadCSV(rutaFitxer);

        // Crear la base de dades i la taula si no existeixen
        context.Database.EnsureCreated();

        // Inserir les dades a la base de dades
        context.AddRange(accidents);
        context.SaveChanges();
    }
}