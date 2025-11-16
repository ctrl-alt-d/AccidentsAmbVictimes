using System.Reflection.Metadata;
using Microsoft.Extensions.Primitives;

namespace importa;

public class Parametres
{
    public const string POSTGRES = "postgres";
    public const string MYSQL = "mysql";
    public const string SQLSERVER = "sqlserver";
    public const string FitxerCSV = "Data/Accidents_de_tr_nsit_amb_morts_o_ferits_greus_a_Catalunya.csv";

    public static string DbBrandParam =>
        (Environment.GetEnvironmentVariable("DbBrandParam") ?? POSTGRES).Trim().ToLowerInvariant();

    public static string ConnectionStringParam
    {
        get
        {
            var custom = Environment.GetEnvironmentVariable("ConnectionStringParam");
            if (!string.IsNullOrWhiteSpace(custom)) return custom;

            // Construïm per defecte segons el gestor seleccionat
            return DbBrandParam switch
            {
                POSTGRES => "Host=postgres;Port=5432;Username=postgres;Password=123456;Database=victimes",
                MYSQL => "Server=mysql;Port=3306;User=root;Password=123456;Database=victimes",
                SQLSERVER => "Server=sqlserver,1433;User Id=sa;Password=Str0ngPass!;TrustServerCertificate=True;Database=victimes",
                _ => "Host=postgres;Port=5432;Username=postgres;Password=123456;Database=victimes"
            };
        }
    }
}