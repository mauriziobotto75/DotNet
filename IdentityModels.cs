using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext() : base("DefaultConnection") { }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }

    public DbSet<T_Anagrafica> Anagrafiche { get; set; }
    public DbSet<T_Lista> Liste { get; set; }
    public DbSet<T_Liste_Corpo> ListeCorpo { get; set; }
    public DbSet<T_Sicurezza> Sicurezza { get; set; }
    public DbSet<T_Presenze> Presenze { get; set; }
    public DbSet<T_Presenze_Corpo> PresenzeCorpo { get; set; }
}
