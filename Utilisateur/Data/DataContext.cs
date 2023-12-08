using Microsoft.EntityFrameworkCore;

namespace utilisateur.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {

            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connexion a la base sqlite
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }
        // On déclare que notre base aura une table Utilisateurs qui contiendra des objets de type Utilisateur
        public DbSet<Entities.Utilisateur> Utilisateurs { get; set; }
    }
}