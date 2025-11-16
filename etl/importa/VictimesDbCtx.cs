using Microsoft.EntityFrameworkCore;

namespace importa;

public class VictimesDbCtx : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        switch (Parametres.DbBrandParam)
        {
            case Parametres.POSTGRES:
                optionsBuilder.UseNpgsql(Parametres.ConnectionStringParam);
                break;
            case Parametres.MYSQL:
                optionsBuilder.UseMySql(Parametres.ConnectionStringParam, ServerVersion.AutoDetect(Parametres.ConnectionStringParam));
                break;
            case Parametres.SQLSERVER:
                optionsBuilder.UseSqlServer(Parametres.ConnectionStringParam);
                break;
            default:
                var msg = $"El tipus de base de dades '{Parametres.DbBrandParam}' no és compatible, vols afegir-lo? https://github.com/ctrl-alt-d/AccidentsAmbVictimes";
                throw new NotSupportedException(msg);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configurar explícitamente que la columna pk sea nullable
        modelBuilder.Entity<Accident>()
            .Property(a => a.Pk)
            .IsRequired(false);
    }

    public DbSet<Accident> Accidents { get; set; } = null!;
}