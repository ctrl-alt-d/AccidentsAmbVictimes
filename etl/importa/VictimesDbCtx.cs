using Microsoft.EntityFrameworkCore;
namespace importa;

public class VictimesDbCtx : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(Parametres.ConnexioPostgres);
    }

    public DbSet<Accident> Accidents { get; set; } = null!;
}