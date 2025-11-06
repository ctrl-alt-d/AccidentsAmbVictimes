using Microsoft.EntityFrameworkCore;
namespace importa;

public class VictimesDbCtx : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(Parametres.ConnexioPostgres);
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