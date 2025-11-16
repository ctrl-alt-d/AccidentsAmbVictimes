using System.Reflection.Metadata;
using Microsoft.Extensions.Primitives;

namespace importa;

public class Parametres
{

    public const string POSTGRES = "PostgreSQL";
    public const string MYSQL = "MySQL";
    public const string SQLSERVER = "SQLServer";
    public const string FitxerCSV = "Data/Accidents_de_tr_nsit_amb_morts_o_ferits_greus_a_Catalunya.csv";
    public static string ConnectionStringParam => 
        Environment.GetEnvironmentVariable("ConnectionStringParam") 
        ?? "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=victimes";
    public static string DbBrandParam => 
        Environment.GetEnvironmentVariable("DbBrandParam") 
        ?? POSTGRES;
}