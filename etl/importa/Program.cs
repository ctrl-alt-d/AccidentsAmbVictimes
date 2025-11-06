namespace importa;

class Program
{
    static void Main(string[] args)
    {
        // Orquestrar el procés d'importació
        using var reader = new CSVReader();
        using var context = new VictimesDbCtx();

        var orquestrador = new Orquestrador(reader, context,Parametres.FitxerCSV);

        // Iniciar el procés
        orquestrador.Go();
    }
}
